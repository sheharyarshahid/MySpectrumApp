using System;
using System.ComponentModel;
using CodingChallenge.iOS.Effects;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Spectrum")]
[assembly: ExportEffect(typeof(DisabledButtonEffect), nameof(DisabledButtonEffect))]
namespace CodingChallenge.iOS.Effects
{
    public class DisabledButtonEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            try
            {
                if (args.PropertyName == "IsEnabled")
                {
                    var transparentCyan = CGColor.CreateSrgb(0, 139, 139, 20);
                    Control.BackgroundColor = new UIColor(transparentCyan);
                    Control.TintColor = UIColor.Gray;
                }
            }
            catch (Exception) { }
        }
    }
}

