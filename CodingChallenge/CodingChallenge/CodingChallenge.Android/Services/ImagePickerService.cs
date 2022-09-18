using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Android.Content;
using Android.Graphics;
using CodingChallenge.Droid.Services;
using CodingChallenge.Services.Contracts;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImagePickerService))]
namespace CodingChallenge.Droid.Services
{
    public class ImagePickerService : IImagePickerService
    {
        public ImagePickerService() { }

        public async Task<string> PickImageAsync()
        {
            // Define the Intent for getting images
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);

            // Start the picture-picker activity (resumes in MainActivity.cs)
            MainActivity.Instance.StartActivityForResult(
                Intent.CreateChooser(intent, "Select Image"),
                MainActivity.PickImageId);

            // Save the TaskCompletionSource object as a MainActivity property
            MainActivity.Instance.PickImageTaskCompletionSource = new TaskCompletionSource<Stream>();

            // Return Task object
            var stream = await MainActivity.Instance.PickImageTaskCompletionSource.Task;
            var filePath = await StorePersonImage(stream);


            return filePath;
        }

        public async Task<string> StorePersonImage(Stream imageStream)
        {
            Bitmap bm = BitmapFactory.DecodeStream(imageStream);
            string filePath;
            byte[] bitmapData;

            using (var stream = new MemoryStream())
            {
                bm.Compress(Bitmap.CompressFormat.Png, 0, stream);
                bitmapData = stream.ToArray();
            }

            var pictures = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            filePath = System.IO.Path.Combine(pictures, $"ProfilePicture.png");

            try
            {
                System.IO.File.WriteAllBytes(filePath, bitmapData);
                Java.IO.File fl = new Java.IO.File(filePath);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.ToString());
            }

            return await Task.FromResult(filePath);
        }
    }
}

