﻿using System;
using Xamarin.Forms;

namespace MasterQ
{
	public partial class App : Application
	{
		public static int timercount = 0;
        public static int Recount = 0;
		public static bool timercheck = false;
        public static bool fristtime = true;
        public static bool Massage0 = true;
        public static bool Massage5 = true;
        public static bool Massage15 = true;
        public static string IPAdress;
        static MasterQDatabaseDAO database;

		public App()
		{
			InitializeComponent();
            Initial.init();
            //MainPage = new NavigationPage(new TestPage());
            if (Constants.isAppForMember())
            {
                MainPage = new NavigationPage(new LoginPage());
            }else if(Constants.isAppForUser()){
				MainPage = new NavigationPage(new UserLoginPage());
			}
            else if (Constants.isAppForBranch())
			{
				MainPage = new NavigationPage(new BranchLoginPage());
			}
		}


        public static MasterQDatabaseDAO Database
        {
            get
            {
                if (database == null)
                {
                    database = new MasterQDatabaseDAO(DependencyService.Get<IFileHelper>().GetLocalFilePath(DBConstants.MAIN_DATABASE_DB3_FILE_NAME));
                }
                return database;
            }
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

		public static void timerStart()
		{
			timercheck = true;

			Device.StartTimer(new TimeSpan(0, 0, 1), () => {
                if (timercount > 0)
                {
                    timercount--;
                }
				// do something every 60 seconds
				
				// ItemsPage i = new ItemsPage();

				return timercheck; // runs again, or false to stop
			});
		}


		public static void timerStop()
		{
			//Console.WriteLine("disposing of timer...");
			//s.tmr.Dispose();
			//s.tmr = null;
			timercheck = false;
		}
	}
}
