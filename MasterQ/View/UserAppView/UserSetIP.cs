using System;

using Xamarin.Forms;

namespace MasterQ.View.UserAppView
{
    public class UserSetIP : ContentPage
    {
        public UserSetIP()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

