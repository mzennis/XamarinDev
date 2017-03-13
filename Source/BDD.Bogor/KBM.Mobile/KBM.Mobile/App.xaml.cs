using KBM.Mobile.Helper;
using KBM.Mobile.Models;
using KBM.Mobile.Views;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace KBM.Mobile
{
    public partial class App : Application
    {
        //MUST use HTTPS, kalau pake iOS
      

        public App()
        {
            InitializeComponent();
            //kalau mau pake database sqlite
            //DependencyService.Register<LocalDB<UserPerKelas>>();
            //DependencyService.Register<LocalDB<UserProfile>>();
            //kalau mau pake rest api
            DependencyService.Register<RestApi<UserPerKelas>>();
            DependencyService.Register<RestApi<UserProfile>>();

            SetMainPage();
            if (!CrossConnectivity.Current.IsConnected)
            {
                Current.MainPage.DisplayAlert("Warning", "Hape antum tidak terkoneksi dengan jaringan internet", "OK");
            }
            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                Current.MainPage.DisplayAlert("Connectivity Changed", "IsConnected: " + args.IsConnected.ToString(), "OK");
            };
        }

        public static void SetMainPage()
        {

            GoToMainPage();

        }

        public static void GoToMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new UserProfilesPage())
                    {
                        Title = "Browse",
                        Icon =  Device.OnPlatform("tab_feed.png",null,null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Device.OnPlatform("tab_about.png",null,null)
                    },
                }
            };
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
    }
}
