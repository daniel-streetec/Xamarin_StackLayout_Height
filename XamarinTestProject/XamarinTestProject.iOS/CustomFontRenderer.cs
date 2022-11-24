using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinTestProject;
using XamarinTestProject.iOS;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomFontRenderer))]
namespace XamarinTestProject.iOS
{
    public class CustomFontRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var label = (CustomLabel)e.NewElement;
                label.FontWeightChanged += Label_FontWeightChanged;
            }
        }

        private void Label_FontWeightChanged(object sender, string e)
        {
            var label = (CustomLabel)sender;
            var font = UIFont.FromName(label.FontFamily, (nfloat)label.FontSize);
            Control.Font = font;
        }
    }
}