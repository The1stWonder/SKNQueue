﻿using System;
using Xamarin.Forms;
using Plugin.Connectivity;

namespace MasterQ
{
	public partial class App : Application
	{
		public static int timercount = 0;
        public static int Recount = 0;
        public static int SearchID = 0;
        public static int SetIPPage = 0;
        public static int TimeReface = 5;
        public static bool CheckSocket = true;
		public static bool timercheck = false;
        public static bool fristtime = true;
        public static bool Massage0 = true;
        public static bool Massage5 = true;
        public static bool Massage15 = true;
        public static string CounterUser;
        public static string IPAdress;
        public static string DeviceName;
        public static string UserGroupID;
        public static string CheckConnectSocket;
        public static string ShowMassageSocket;
        public static string TextSearch = "";
        public static bool Thai = true;
        public static bool RePage = false;
        public static bool RePagelogin = false;
        public static bool RePagemain = false;
        public static bool Initiallogin = false;
        public static bool OfflineMode = false;
        public static string NoSocket = "กรุณาตรวจสอบ IP Ethernet";
        public static string NoInternet = "ไม่มีการเชื่อมต่ออินเตอร์เน็ต";
        public static string NoInternet2 = "No internet connect";
        public static string AppicationName = "SNRU";
        public static string servicename = "";
        public static int NumberServiceBranch = 0;
        static MasterQDatabaseDAO database;

        public App()
        {
            InitializeComponent();

            if (CrossConnectivity.Current.IsConnected)
            {
                Initial.init();
            }
            else
            {
                RePagelogin = true;
                Initiallogin = true;
            }

            Utils.changeAppLanguageToThai();

            if (Constants.isAppForMember())
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else if (Constants.isAppForUser())
            {
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
				return timercheck; // runs again, or false to stop
			});
		}


		public static void timerStop()
		{
			timercheck = false;
		}
	}
}
