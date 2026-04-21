using System.Globalization;
using Microsoft.Maui.Storage;
using MultiLanguageApp.Resources.Localization;

namespace MultiLanguageApp.Services;

public static class LanguageService
{
    public static event Action? LanguageChanged;

    public static void ChangeLanguage(string languageCode)
    {
        var culture = new CultureInfo(languageCode);

        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;

        AppResources.Culture = culture;

        Preferences.Set("AppLanguage", languageCode);

        LanguageChanged?.Invoke();
    }

    public static void Init()
    {
        var savedLang = Preferences.Get("AppLanguage", "en");
        ChangeLanguage(savedLang);
    }
}