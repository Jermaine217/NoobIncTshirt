using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace NoobIncTshirt
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        static TShirtDatabase database;
        public static TShirtDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TShirtDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TShirtDatabaseSQLite.db3"));
                }
                return database;
            }
        }
        public int ResumeAtPersonName { get; set; }

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
