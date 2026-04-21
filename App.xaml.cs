using MultiLanguageApp.Services;

namespace MultiLanguageApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        LanguageService.Init(); // 🔥 восстановление языка

        MainPage = new AppShell();
    }
}