using System;
using CodingChallenge.Utils;
using CodingChallenge.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Xamarin.Forms;

namespace CodingChallenge.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        string loginAvatar;

        [ObservableProperty]
        bool isKeyPassValid;

        public LoginViewModel()
        {
            LoginAvatar = Constants.LoginAvatar;
        }

    }
}

