using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BindablePropertyDemo.Custom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyCustomControl : ContentView
    {
        public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(
                                                         propertyName: "TitleText",
                                                         returnType: typeof(string),
                                                         declaringType: typeof(MyCustomControl),
                                                         defaultValue: "",
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: TitleTextPropertyChanged);

        public string TitleText
        {
            get { return base.GetValue(TitleTextProperty).ToString(); }
            set { base.SetValue(TitleTextProperty, value); }
        }

        private static void TitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MyCustomControl)bindable;
            control.title.Text = newValue.ToString();
        }

        public static readonly BindableProperty ImageProperty = BindableProperty.Create(
                                                        propertyName: "Image",
                                                        returnType: typeof(string),
                                                        declaringType: typeof(MyCustomControl),
                                                        defaultValue: "",
                                                        defaultBindingMode: BindingMode.TwoWay,
                                                        propertyChanged: ImageSourcePropertyChanged);

        public string Image
        {
            get { return base.GetValue(ImageProperty).ToString(); }
            set { base.SetValue(ImageProperty, value); }
        }

        private static void ImageSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MyCustomControl)bindable;
            control.image.Source = ImageSource.FromFile(newValue.ToString());
        }

        public MyCustomControl()
        {
            InitializeComponent();
        }


    }
}