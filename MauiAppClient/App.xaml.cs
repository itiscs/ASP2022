namespace MauiAppClient;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

        //Preferences.Set("apiUrl", @"http://localhost:8081/");

        Preferences.Set("apiUrl", @"https://0c89-178-204-88-254.eu.ngrok.io/");

        //ngrok http --host-header=rewrite http://localhost:8081 
    }
}
