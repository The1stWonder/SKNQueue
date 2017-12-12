using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
    public partial class BranchPickupCard : ContentPage
    {
        public BranchPickupCard()
        {
            InitializeComponent();

            if (App.Thai == true)
            {
                Utils.changeAppLanguageToThai();
                LanguageThai.IsVisible = false;
                LanguageThai.IsEnabled = false;

                LanguageEng.IsVisible = true;
                LanguageEng.IsEnabled = true;

                picup1.IsVisible = false;
                picup2.IsVisible = true;
            }
            else
            {
                Utils.changeAppLanguageToEng();
                LanguageThai.IsVisible = true;
                LanguageThai.IsEnabled = true;

                LanguageEng.IsVisible = false;
                LanguageEng.IsEnabled = false;

                picup1.IsVisible = true;
                picup2.IsVisible = false;
            }
        }

        public void OnImagePicUp(object sender, System.EventArgs args)
        {
            Navigation.InsertPageBefore(new BranchChooseServiceQueuePage(), this);
            Navigation.PopAsync();
        }

        async void OnImageMainExit(object sender, System.EventArgs args)
        {
            var answer = await DisplayAlert(Utils.getLabel(LabelConstants.MAIN_PAGE_LOGOUT), Utils.getLabel(LabelConstants.MAIN_PAGE_CONFIRMLOGOUT), "Yes", "No");
            if (answer == true)
            {
                UIReturn Chklogout = BranchLoginController.getInstance().LogutBranch();
                if (!Chklogout.isSuccess)
                {
                    await DisplayAlert("", Chklogout.getDescription(), "Close");
                }
                else
                {
                    Navigation.InsertPageBefore(new BranchLoginPage(), this);
                    await Navigation.PopAsync();
                }
            }
        }

        public void OnImageMainchangeAppLanguageThai(object sender, System.EventArgs args)
        {
            Utils.changeAppLanguageToThai();
            App.Thai = true;

            Navigation.InsertPageBefore(new BranchPickupCard(), this);
            Navigation.PopAsync();

        }

        public void OnImageMainchangeAppLanguageEng(object sender, System.EventArgs args)
        {
            Utils.changeAppLanguageToEng();
            App.Thai = false;

            Navigation.InsertPageBefore(new BranchPickupCard(), this);
            Navigation.PopAsync();

        }
    }
}
