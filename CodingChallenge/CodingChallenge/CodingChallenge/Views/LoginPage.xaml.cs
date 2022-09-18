using System;
using System.Collections.Generic;
using CodingChallenge.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodingChallenge.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginViewModel ViewModel { get; private set; }

        public LoginPage()
        {
            InitializeComponent();

            var loginVM = DependencyService.Get<LoginViewModel>();
            BindingContext = ViewModel = loginVM;
        }

        async void LoginBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new PersonsPage());
                Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
            }
            catch (Exception) { }
        }
    }
}

