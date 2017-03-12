using System;
using System.Collections.Generic;
using System.Text;
using KBM.Mobile.Models;
using Xamarin.Forms;
using KBM.Mobile.Helper;
using KBM.Mobile.iOS;

[assembly: Dependency(typeof(RestService))]
namespace KBM.Mobile.iOS
{
    class RestService : IRestUrl
    {
        public string GetServiceName(Type NameOfClass)
        {
            if (NameOfClass == typeof(UserProfile))
            {
                return "UserProfilesSvc";
            }
            else if (NameOfClass == typeof(UserPerKelas))
            {
                return "KelasSvc";
            }
            else
                return "";

        }
    }
}
