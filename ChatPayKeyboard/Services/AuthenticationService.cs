using System;
using ChatPay.AppInstallHelper;
using ChatPayInstaller.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(KeyboardExtension.Services.AuthenticationService))]
namespace KeyboardExtension.Services
{
    public class AuthenticationService : IAuthService
    {
        public void AuthenticateUser(UserDetails userDetails)
        {
            throw new NotImplementedException();
        }
    }
}
