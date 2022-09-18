using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using CodingChallenge.Controls;
using CodingChallenge.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(KeyPassEntry), typeof(KeyPassEntryRenderer))]
namespace CodingChallenge.Droid.Renderers
{
    public class KeyPassEntryRenderer : EntryRenderer
    {
        public KeyPassEntryRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                SetColor(Android.Graphics.Color.Transparent);
            }

            void SetColor(Android.Graphics.Color color)
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                {
                    Control.BackgroundTintList = ColorStateList.ValueOf(color);
                }
                else
                {
                    Control.Background.SetColorFilter(color, PorterDuff.Mode.SrcAtop);
                }
            }

        }
    }
}

