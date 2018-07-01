using EFCore.EF_CORE;
using EFCore.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace EFCore
{
	public partial class App : Application
	{
        public static readonly string DbName = "adsdb.db";
        static AdsNoteDbContext context;
        public static AdsNoteDbContext Database
        {
            get
            {
                if (context==null)
                {
                    var dbpath = DependencyService.Get<ISQLLiteConnection>().GetDbPath("AdsDb.db");
                    context = AdsNoteDbContext.CreateDB(dbpath);
                }
                return context;
            }
        }
		public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new ListPage()) { Title="Ads Notes"};
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
