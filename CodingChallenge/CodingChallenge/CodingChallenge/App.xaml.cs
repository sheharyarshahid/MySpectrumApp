using CodingChallenge.ViewModels;
using CodingChallenge.Views;
using Xamarin.Forms;

namespace CodingChallenge
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.RegisterSingleton<LoginViewModel>(new LoginViewModel());

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
