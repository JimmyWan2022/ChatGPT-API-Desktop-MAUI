using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Text.Json;
using Microsoft.Maui;


namespace MauiBatchChatGPT;

public partial class App : Application
{
    public static string APIKEY { get; set; } = "";
    public static bool apiKeyIsChecked { get; set; }
    public App()
	{

		InitializeComponent();
        apiKeyIsChecked = false;
        MainPage = new AppShell();
        LoadMauiAsset();

    }

    private async void LoadMauiAsset()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("Config.json");
        using var reader = new StreamReader(stream);
        var jsonString = reader.ReadToEnd();
        var document = JsonDocument.Parse(jsonString);
        APIKEY = document.RootElement.GetProperty("APIKEY").GetString();
    }
}
