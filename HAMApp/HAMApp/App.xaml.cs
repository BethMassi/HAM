using System;
using HAMApp.Services;
using HAMApp.Views;
using Xamarin.Forms;

namespace HAMApp
{
	public partial class App : Application
	{
        public static bool UseMockDataStore = false;
        //public static string AzureServiceUrl = "https://[CONFIGURE-THIS-URL].azurewebsites.net";
        public static string AzureServiceUrl = "http://192.168.0.101:62087";

        public App ()
		{
			InitializeComponent();

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<AzureDataStore>();

            MainPage = new MainPage();
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
