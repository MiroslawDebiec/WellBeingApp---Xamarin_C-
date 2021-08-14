using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WellBeingApp.Views;
using WellBeingApp.Data;
using System.IO;

namespace WellBeingApp
{
    public partial class App : Application
    {
        static WellBeingDatabase database;

        public static WellBeingDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new WellBeingDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WellBeing.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new ProfilePage());
            //MainPage = new NavigationPage(new EntryPage());
            //MainPage = new LoginPage();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
