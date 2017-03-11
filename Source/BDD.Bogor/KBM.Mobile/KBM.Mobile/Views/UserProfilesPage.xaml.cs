using KBM.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KBM.Mobile.Models;
namespace KBM.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfilesPage : ContentPage
    {
        UserProfilesViewModel viewModel;

        public UserProfilesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new UserProfilesViewModel();
        }

        async void OnUserProfileselected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as UserProfile;
            if (item == null)
                return;

            await Navigation.PushAsync(new UserProfileDetailPage(new UserProfileDetailViewModel(item)));

            // Manually deselect UserProfile
            
            UserProfilesListView.SelectedItem = null;
        }

        async void AddUserProfile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewUserProfilePage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.UserProfiles.Count == 0)
                viewModel.LoadUserProfilesCommand.Execute(null);
        }
    }

    
}
