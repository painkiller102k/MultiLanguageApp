using Microsoft.Extensions.DependencyInjection;

namespace MultiLanguageApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

    }
}