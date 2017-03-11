using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KBM.Mobile.Helper;
using Xamarin.Forms;
using KBM.Mobile.Droid;
using KBM.Mobile.Models;
[assembly: Dependency(typeof(RestService))]
namespace KBM.Mobile.Droid
{
    class RestService : IRestUrl
    {
        public string GetServiceName(string NameOfClass)
        {
            switch (NameOfClass)
            {
                case nameof(UserProfile):
                    return "UserProfilesSvc";
                   
                default:
                    return "";
                    
            }
        }
    }
}