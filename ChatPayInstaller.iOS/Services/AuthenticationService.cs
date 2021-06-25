using System;
using ChatPay.AppInstallHelper;
using ChatPayInstaller.Interfaces;
using Xamarin.Forms;
using Binding;

[assembly: Dependency(typeof(KeyboardExtension.Services.AuthenticationService))]
namespace KeyboardExtension.Services
{
    public class AuthenticationService : IAuthService
    {
        public void AuthenticateUser(UserDetails userDetails)
        {
            //show view from binding library
            var proxy = new KeyboardProxy();

            proxy.OnLoginWithUsername(userDetails.SMUsername, userDetails.logDetails.DeviceOS, userDetails.logDetails.DeviceIMEI);
        }
    }
}
