using System.Collections.ObjectModel;
using MultiLanguageApp.Services;
using MultiLanguageApp.Resources.Localization;

namespace MultiLanguageApp;

public partial class MainPage : ContentPage
{
    public class LanguageItem
    {
        public string Title { get; set; }
        public string DescriptionKey { get; set; }
        public string ImageUrl { get; set; }
        public string CommandText { get; set; }

        public string Description =>
            AppResources.ResourceManager.GetString(DescriptionKey, AppResources.Culture);
    }

    private ObservableCollection<LanguageItem> items;
    private int position = 0;

    public MainPage()
    {
        InitializeComponent();

        items = new ObservableCollection<LanguageItem>
        {
            new() { Title="C#", DescriptionKey="CSharpDesc", ImageUrl="csharp.png", CommandText="Console.WriteLine(\"Tere! See on Martin\");" },
            new() { Title="Python", DescriptionKey="PythonDesc", ImageUrl="python.png", CommandText="print(\"Python programmeerimiskeel\")" },
            new() { Title="JavaScript", DescriptionKey="JSDesc", ImageUrl="javascript.png", CommandText="console.log('JS Tere!');" },
            new() { Title="Java", DescriptionKey="JavaDesc", ImageUrl="java.png", CommandText="System.out.println(\"Hello World!\");" },
            new() { Title="C++", DescriptionKey="CppDesc", ImageUrl="cpp.png", CommandText="std::cout << \"Martin töö\";" }
        };

        LanguageCarousel.ItemsSource = items; //items carousel
        LanguageCarousel.IndicatorView = Indicator; // indicator pages

        LanguageService.LanguageChanged += () =>
        {
            LanguageCarousel.ItemsSource = null; //reload language desc
            LanguageCarousel.ItemsSource = items;
        };

        Device.StartTimer(TimeSpan.FromSeconds(4), () =>
        {
            if (items.Count == 0) return false;

            position = (position + 1) % items.Count; // next page -> nachalo 
            LanguageCarousel.Position = position;

            return true;
        });
    }

    private async void OnCardTapped(object sender, EventArgs e)
    {
        if (LanguageCarousel.CurrentItem is LanguageItem item)
            await DisplayAlertAsync(item.Title, item.CommandText, "OK");
    }

    private void SetEnglish(object sender, EventArgs e)
        => LanguageService.ChangeLanguage("en");

    private void SetEstonian(object sender, EventArgs e)
        => LanguageService.ChangeLanguage("et");
}