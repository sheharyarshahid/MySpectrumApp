using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using CodingChallenge.ViewModels;

namespace CodingChallenge.Behaviors
{
    public class KeyPassValidator : Behavior<Entry>
    {
        LoginViewModel LoginVM;

        public KeyPassValidator()
        {
            var loginVM = DependencyService.Get<LoginViewModel>();
            this.LoginVM = loginVM;
        }

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += KeyPassEntry_TextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= KeyPassEntry_TextChanged;
            base.OnDetachingFrom(entry);
        }

        void KeyPassEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex regx = new Regex("[0-9]");
            bool isValid = LoginVM.IsKeyPassValid = regx.IsMatch(e.NewTextValue) && e.NewTextValue.Length >= 4;

            ((Entry)sender).TextColor = isValid ? Color.DarkGreen : Color.Red;
            ((Entry)sender).BackgroundColor = isValid ? Color.DarkSeaGreen : Color.FromHex("#FBC5D0");
        }
    }
}

