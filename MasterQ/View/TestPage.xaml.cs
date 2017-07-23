﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterQ
{
	public partial class TestPage : ContentPage
	{
		public TestPage()
		{
			InitializeComponent();
			//register();
			//login();
			editProfile();
            //forgetpassword();

            // MetaData
            getBranch();
            getProvince();
            getDistrict();
		}
        private void editProfile(){
			Member member = new Member();
			member.email = "firt@gmail.com";
			member.password = "1234";
			member.confirmPassword = "1234";
			member.firstname = "Sirapop";
			member.lastname = "Fungfuang";
			member.birthdate = "12/12/1990";
            UIReturn result = EditProfileController.getInstance().editProfile(member);

        }
		private void login()
		{
            Login m = new Login();
            m.username = "first@gmail.com";
			m.password = "editPassword";
            UIReturn result = LoginController.getInstance().Authenuser(m);

		}
		private void register()
		{
            Member member = new Member();
			member.email = "a@gmail.com";
			member.password = "1234";
			member.confirmPassword = "1234";
			member.firstname = "Sirapop";
            member.lastname = "Fungfuang";
			member.birthdate = "12/12/1990";
            UIReturn result = RegisterController.getInstance().register(member);

		}
		private void forgetpassword()
		{
			Login m = new Login();
			m.username = "first@gmail.com";
			m.password = "editPassword";
            UIReturn result = ForgetPasswordController.getInstance().getPassword(m);

		}
		private void getBranch()
		{
			Login m = new Login();
			m.username = "first@gmail.com";
			m.password = "editPassword";
			UIReturn result = ForgetPasswordController.getInstance().getPassword(m);

		}
		private void getProvince()
		{
			Login m = new Login();
			m.username = "first@gmail.com";
			m.password = "editPassword";
			UIReturn result = ForgetPasswordController.getInstance().getPassword(m);

		}
		private void getDistrict()
		{
			Login m = new Login();
			m.username = "first@gmail.com";
			m.password = "editPassword";
			UIReturn result = ForgetPasswordController.getInstance().getPassword(m);

		}
	}
}
