using System;
using System.IO;
using System.Threading.Tasks;
using CodingChallenge.iOS.Services;
using CodingChallenge.Services.Contracts;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImagePickerService))]
namespace CodingChallenge.iOS.Services
{
    public class ImagePickerService : IImagePickerService
    {
        TaskCompletionSource<string> taskCompletionSource;
        UIImagePickerController imagePicker;

        public ImagePickerService() { }

        public Task<string> PickImageAsync()
        {
            // Create new UIImagePickerController
            imagePicker = new UIImagePickerController
            {
                SourceType = UIImagePickerControllerSourceType.PhotoLibrary,
                MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary)
            };

            // Event handlers
            imagePicker.FinishedPickingMedia += OnImagePickerFinishedPickingMedia;
            imagePicker.Canceled += OnImagePickerCancelled;

            // Present UIImagePickerController
            UIWindow window = UIApplication.SharedApplication.KeyWindow;
            var viewController = window.RootViewController;
            viewController.PresentViewController(imagePicker, true, null);

            taskCompletionSource = new TaskCompletionSource<string>();
            return taskCompletionSource.Task;
        }

        async void OnImagePickerFinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
        {
            UIImage image = e.EditedImage ?? e.OriginalImage;

            if (image != null)
            {
                NSData data;
                if (e.ReferenceUrl.PathExtension.Equals("PNG") || e.ReferenceUrl.PathExtension.Equals("png"))
                {
                    data = image.AsPNG();
                }
                else
                {
                    data = image.AsJPEG(1);
                }

                Stream stream = data.AsStream();

                string imagePath = await StorePersonImage(image);

                UnregisterEventHandlers();

                taskCompletionSource.SetResult(imagePath);
            }
            else
            {
                UnregisterEventHandlers();
                taskCompletionSource.SetResult(null);
            }
            imagePicker.DismissModalViewController(true);
        }

        void OnImagePickerCancelled(object sender, EventArgs e)
        {
            UnregisterEventHandlers();
            taskCompletionSource.SetResult(null);
            imagePicker.DismissModalViewController(true);
        }

        void UnregisterEventHandlers()
        {
            imagePicker.FinishedPickingMedia -= OnImagePickerFinishedPickingMedia;
            imagePicker.Canceled -= OnImagePickerCancelled;
        }

        async Task<string> StorePersonImage(UIImage img)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fileName = Path.Combine(folderPath, "personimage.jpg");

            NSData image = img.AsJPEG();
            NSError err = null;

            image.Save(fileName, false, out err);
            return await Task.FromResult(fileName);
        }
    }
}

