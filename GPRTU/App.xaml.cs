namespace GPRTU;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        Routing.RegisterRoute(route: "MainPage", typeof(MainPage));
        Routing.RegisterRoute(route:"LocationSheet", typeof(LocationSheet));
        MainPage = new AppShell();
	}
}

