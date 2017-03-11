using KBM.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KBM.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewUserProfilePage : ContentPage
    {
        public UserProfile userProfile { get; set; }

        public NewUserProfilePage()
        {
            InitializeComponent();

            userProfile = new UserProfile
            {
                nama = "UserProfile name",
                tanggalLahir = DateTime.Now
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddUserProfile", userProfile);
            await Navigation.PopToRootAsync();
        }
    }
}
