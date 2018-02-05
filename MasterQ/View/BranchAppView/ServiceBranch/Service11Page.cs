using System;

using Xamarin.Forms;

namespace MasterQ.View.BranchAppView.ServiceBranch
{
    public class Service11Page : ContentPage
    {
        public Service11Page()
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

