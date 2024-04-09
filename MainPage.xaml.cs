using AndroidX.Annotations;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;

namespace MauiAppOg
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        ScrollView scrollView;
        VerticalStackLayout stackLayout;

        public MainPage()
        {
            InitializeComponent();

            CarouselView carousel = new CarouselView
            {
                VerticalOptions = LayoutOptions.Center,
            };
            carousel.ItemsSource = new List<List<string>>
            {
                new List<string>{"Name1", "Description1", "dotnet_bot.svg"},
                new List<string>{"Name2", "Description2", "dotnet_bot.svg"},
                new List<string>{"Name3", "Description3", "dotnet_bot.svg"}
            };
            carousel.ItemTemplate = new DataTemplate(() =>
            {
                Label header = new Label
                {
                    FontAttributes = FontAttributes.Bold,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = 18
                };

                Label description = new Label
                {
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = 14
                };

                Image image = new Image();

                header.SetBinding(Label.TextProperty, ".", converter: new HeaderConverter());
                description.SetBinding(Label.TextProperty, ".", converter: new DescriptionConverter());
                image.SetBinding(Image.SourceProperty, new Binding(".", converter: new ImageConverter()));

                StackLayout layout = new StackLayout
                {
                    Children = { header, description, image }
                };

                return layout;
            });
            Content = carousel;
        }

        class HeaderConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                List<string> data = value as List<string>;
                if (data != null && data.Count > 0)
                    return data[0];
                return "";
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        class DescriptionConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                List<string> data = value as List<string>;
                if (data != null && data.Count > 1)
                    return data[1];
                return "";
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        class ImageConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                List<string> data = value as List<string>;
                if (data != null && data.Count > 2)
                    return data[2];
                return "";
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
}
