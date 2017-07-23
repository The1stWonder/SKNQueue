using System;
namespace MasterQ
{
    public class MainPageController
    {
        private static MainPageController instance = new MainPageController();

        MainPageController() { }


        public static MainPageController getInstance()
        {
            return instance;
        }
        public UIReturn logout(){
            UIReturn ret = new UIReturn();
            return ret;
        }
    }
}
