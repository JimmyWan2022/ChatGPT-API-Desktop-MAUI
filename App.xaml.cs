namespace MauiBatchChatGPT;

public partial class App : Application
{
    public static string APIKEY { get; set; } = "";
    public App()
	{
		InitializeComponent();

        MainPage = new AppShell();
        
    }
}
