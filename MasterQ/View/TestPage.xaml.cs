using System;
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
            getBranchQ();
            List<CodeDescription> list1 = TempDB.codeDescriptions;
            List<Province> list2 = TempDB.provinces;
            List<District> list3 = TempDB.districts;
            List<Branch> list4 = TempDB.branches;
            List<Service> list5 = SessionModel.services;
            getHistory();
            reserveQ();
        }
        private void editProfile()
        {
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
            UIReturn result = LoginController.getInstance().LoginMember(m);

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
            Province p = new Province();
            p.provinceID = "01";
            District d = new District();
            d.districtID = "01";
            UIReturn result = SearchController.getInstance().getBranches(p, d);
            //OR
            UIReturn result1 = SearchController.getInstance().getBranches("test");

        }
        private void getProvince()
        {
            UIReturn result = SearchController.getInstance().getProvinces();

        }
        private void getDistrict()
        {
            Province p = new Province();
            p.provinceID = "01";
            UIReturn result = SearchController.getInstance().getDistricts(p);

        }
        private void getBranchQ()
        {
            Branch b = new Branch();
            b.branchID = "01";
            UIReturn result = SearchController.getInstance().getBranchQueue(b);

        }
        private void reserveQ()
        {
            Service s = new Service();
            s.serviceID = "0001";
            s.branchID = "01";
            UIReturn result = ReserveQController.getInstance().reserveQueue(s);
        }
        private void getHistory()
        {
            Member member = new Member();
            member.memberID = "01";
            UIReturn result = ShowHistoryController.getInstance().getHistory(member);
        }
    }
}
