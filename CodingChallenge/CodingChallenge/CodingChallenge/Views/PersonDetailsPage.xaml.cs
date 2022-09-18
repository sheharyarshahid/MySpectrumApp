using System;
using System.IO;
using System.Threading.Tasks;
using CodingChallenge.Models;
using CodingChallenge.Services.Contracts;
using CodingChallenge.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodingChallenge.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonDetailsPage : ContentPage
    {
        public PersonDetailViewModel ViewModel { get; private set; }

        Person currentPerson;

        public PersonDetailsPage(Person person)
        {
            InitializeComponent();

            BindingContext = ViewModel = new PersonDetailViewModel(person);

            this.currentPerson = person;

            NavigationPage.SetBackButtonTitle(this, person.FirstName);
        }

        async void ChangePersonImageBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (currentPerson != null)
                {
                    string image = await DependencyService.Get<IImagePickerService>()
                        .PickImageAsync();

                    if (image != null)
                    {
                        ViewModel.Person.Avatar = image;
                        PersonAvatarImg.Source = FileImageSource.FromFile(image);
                    }
                }
            }
            catch (Exception) { }
        }
    }
}