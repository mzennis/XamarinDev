using KBM.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBM.Mobile.ViewModels
{
    public class UserProfileDetailViewModel:BaseViewModel
    {
        public UserProfile CurrentProfile { get; set; }
        public UserProfileDetailViewModel(UserProfile userProfile = null)
        {
            Title = userProfile.nama;
            CurrentProfile = userProfile;
        }
        
    }
}
