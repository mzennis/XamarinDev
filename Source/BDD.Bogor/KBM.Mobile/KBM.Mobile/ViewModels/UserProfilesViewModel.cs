using KBM.Mobile.Helper;
using KBM.Mobile.Models;
using KBM.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KBM.Mobile.ViewModels
{
    class UserProfilesViewModel:BaseViewModel
    {
        public IDataRepository<UserProfile> DataStore => DependencyService.Get<IDataRepository<UserProfile>>();
        public ObservableRangeCollection<UserProfile> UserProfiles { get; set; }
        public Command LoadUserProfilesCommand { get; set; }

        public UserProfilesViewModel()
        {
            //just to init kelas table
            var x = DependencyService.Get<IDataRepository<UserPerKelas>>();

            Title = "Browse";
            UserProfiles = new ObservableRangeCollection<UserProfile>();
            LoadUserProfilesCommand = new Command(async () => await ExecuteLoadUserProfilesCommand());

            MessagingCenter.Subscribe<NewUserProfilePage, UserProfile>(this, "AddUserProfile", async (obj, item) =>
            {
                var _UserProfile = item as UserProfile;
                UserProfiles.Add(_UserProfile);
                await DataStore.InsertData(_UserProfile);
            });
        }

        async Task ExecuteLoadUserProfilesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                UserProfiles.Clear();
                var datas = await DataStore.GetDatas("UserProfile");
                UserProfiles.ReplaceRange(datas.Data as IEnumerable<UserProfile>);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load UserProfiles.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
