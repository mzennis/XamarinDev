using KBM.Mobile.Helper;
using KBM.Mobile.Models;
using KBM.Mobile.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(RestService))]
namespace KBM.Mobile.UWP
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
