using System;
using CodingChallenge.Controls;
using CodingChallenge.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(KeyPassEntry), typeof(KeyPassEntryRenderer))]
namespace CodingChallenge.iOS.Renderers
{
    public class KeyPassEntryRenderer : EntryRenderer
    {
        public KeyPassEntryRenderer() { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
        }
    }
}

