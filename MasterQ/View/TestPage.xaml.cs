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
            //editProfile();
            //forgetpassword();

            // MetaData
            getBranch();
            getProvince();
            getDistrict();
			//getBranchQ();
			List<CodeDescription> list1 = TempDB.codeDescriptions;
			List<Province> list2 = TempDB.provinces;
			List<District> list3 = TempDB.districts;
			List<Branch> list4 = TempDB.branches;
            List<Service> list5 = TempDB.services;
		}
        private void editProfile(){
			Member member = new Member();
            member.email = "firt@gmail.com";
			member.password = "1234";
            member.confirmPassword = "1234";
            member.firstName = "Sirapop";
            member.lastName = "Fungfuang";
            member.birthDate = "12/12/1990";
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
            member.firstName = "Sirapop";
            member.lastName = "Fungfuang";
            member.birthDate = "12/12/1990";
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
            UIReturn result = SearchController.getInstance().getBranches("01","01");
			UIReturn result1 = SearchController.getInstance().getBranches("test");

		}
		private void getProvince()
		{
			UIReturn result = SearchController.getInstance().getProvinces();

		}
		private void getDistrict()
		{
            UIReturn result = SearchController.getInstance().getDistricts("01");

		}
		private void getBranchQ()
		{
            UIReturn result = SearchController.getInstance().getBranchQueue("01");

		}
	}
}
