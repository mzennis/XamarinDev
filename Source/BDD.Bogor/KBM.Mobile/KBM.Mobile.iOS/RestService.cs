using System;
using System.Collections.Generic;
using System.Text;
using KBM.Mobile.Models;
using Xamarin.Forms;
using KBM.Mobile.Helper;
namespace KBM.Mobile.iOS
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
