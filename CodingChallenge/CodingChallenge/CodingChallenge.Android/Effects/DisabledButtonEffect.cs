using System;
using System.ComponentModel;
using CodingChallenge.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using Color = Android.Graphics.Color;
using View = Android.Views.View;

[assembly: ResolutionGroupName("Spectrum")]
[assembly: ExportEffect(typeof(DisabledButtonEffect), nameof(DisabledButtonEffect))]
namespace CodingChallenge.Droid.Effects
{
    public class DisabledButtonEffect : PlatformEffect
    {
        protected override void OnAttached() { }

        protected override void OnDetached() { }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            try
            {
                if (args.PropertyName == "IsEnabled")
                {
                    var transparentCyan = new Color(0, 139, 139, 20);
                    (Control as View).SetBackgroundColor(transparentCyan);
                }
            }
            catch (Exception) { }
        }
    }
}

