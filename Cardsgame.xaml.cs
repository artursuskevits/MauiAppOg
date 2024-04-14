using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace MauiAppOg
{
    public partial class Cardsgame : ContentPage
    {
        Label translationLabel;

        public Cardsgame()
        {
            InitializeComponent();

            string filePath = "C:\\Users\\artur\\Source\\Repos\\MauiAppOg\\Words.txt";
            List<PageClass> pages = new List<PageClass>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length == 2)
                    {
                        pages.Add(new PageClass(parts[0], parts[1]));
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка в строке: {line}");
                    }
                }
            }

            CarouselView carousel = new CarouselView
            {
                VerticalOptions = LayoutOptions.Center,
                ItemTemplate = new DataTemplate(() =>
                {
                    StackLayout pageLayout = new StackLayout();

                    Label wordLabel = new Label();
                    wordLabel.SetBinding(Label.TextProperty, "Word");
                    

                    Button show = new Button();
                    show.Text = "Show translation";
                    show.Clicked += Show_Clicked;

                    translationLabel = new Label
                    {
                        IsVisible = false
                    };
                    translationLabel.SetBinding(Label.TextProperty, "Translate");
                    pageLayout.Children.Add(wordLabel);
                    pageLayout.Children.Add(translationLabel);
                    pageLayout.Children.Add(show);
                    return pageLayout;
                })
            };

            carousel.ItemsSource = pages;

            Content = carousel;
        }

        private void Show_Clicked(object sender, EventArgs e)
        {
            if (translationLabel.IsVisible == false) 
            {
                translationLabel.IsVisible = true;
            }
        }
    }
}
