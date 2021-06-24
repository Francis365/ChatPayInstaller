using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatPay.AppInstallHelper;
using ChatPayInstaller.Interfaces;
using Xamarin.Forms;

namespace ChatPayInstaller
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            AskForPermission();
        }
        private async void AskForPermission()
        {

            var res = ChatPay.AppInstallHelper.InstallationHelper.IsChatPayInstalled();
            bool allowed = await ChatPay.AppInstallHelper.InstallationHelper.AskForRequiredPermission();
            if (!allowed)
            {
                await DisplayAlert("Alert", "You should allow the permission for download apk", "Ok");
            }
            else
            {
                //await DisplayAlert("Congra!", "You have permission to do the next step", "OK");
            }
        }
        private async void EnableKeyBoardBtn_Clicked(object sender, EventArgs e)
        {
            ChatPay.AppInstallHelper.InstallationHelper.ShowKeyboardSettings();

        }
        private async void ForceUpdateBtn_Clicked(object sender, EventArgs e)
        {
            ChatPay.AppInstallHelper.InstallationHelper.ChangeKeyboard();
        }
        private async void LaunchBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                var userdetails = new UserDetails()
                {
                    SMUsername = "segzwealth",
                    appversion = 0,
                    LoginMethod = "Password",
                    SMPassword = "Jehovah1$",
                    SMToken = "6670",
                    logDetails = new LogDetails() { DeviceIMEI = "web", DeviceOS = "web", HardwareIMEI = "Web", IPAddress = "" }
                };

                //Authenticate user through dependency service
                DependencyService.Get<IAuthService>().AuthenticateUser(userdetails);

                //ChatPay.AppInstallHelper.InstallationHelper.ToggleKeyboard();
                var res = await ChatPay.AppInstallHelper.InstallationHelper.LaunchChatPay(userdetails);
                if (res)
                {
                    await Task.Delay(2000);
                    ChatPay.AppInstallHelper.InstallationHelper.ToggleKeyboard();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert", ex.Message, "Ok");
            }

        }

        private async void downloadBtn_Clicked(object sender, EventArgs e)
        {
            bool allowed = await ChatPay.AppInstallHelper.InstallationHelper.AskForRequiredPermission();
            if (!allowed)
            {
                await DisplayAlert("Alert", "You should allow the permission for download apk", "Ok");
            }
            else
            {
                //await DisplayAlert("Congra!", "You have permission to do the next step", "OK");
                var res = await ChatPay.AppInstallHelper.InstallationHelper.InstallChatPayEmbedded();

                // ChatPay.AppInstallHelper.InstallationHelper.InstallApp("375380948", ChatPay.AppInstallHelper.InstallMode.AppStore);
                //await Task.Run(() => InstallAppAutomatically());
            }


        }
        private void AskForPermissionBtn_Clicked(object sender, EventArgs e)
        {
            AskForPermission();
        }
        private async void uninstallBtn_Clicked(object sender, EventArgs e)
        {
            ChatPay.AppInstallHelper.InstallationHelper.UninstallChatPay();

        }
    }
}
