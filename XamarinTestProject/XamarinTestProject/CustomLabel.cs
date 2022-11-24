using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinTestProject
{
    public class CustomLabel : Label
    {
        public CustomLabel()
        {
            
        }

        public static readonly BindableProperty FontWeightProperty = BindableProperty.Create(
            nameof(FontWeight),
            typeof(string),
            typeof(CustomLabel),
            "Regular",
            propertyChanged: OnFontWeightChanged);

        public string FontWeight
        {
            get => (string)GetValue(FontWeightProperty);
            set => SetValue(FontWeightProperty, value);
        }

        private static void OnFontWeightChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var label = (CustomLabel)bindable;
            label.FontWeightChanged(label, newValue as string);
        }

        public event EventHandler<string> FontWeightChanged;

    }
}
