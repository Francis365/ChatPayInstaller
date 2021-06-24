using System;
using ChatPay.AppInstallHelper;

namespace ChatPayInstaller.Interfaces
{
    public interface IAuthService
    {
        void AuthenticateUser(UserDetails userDetails);
    }
}
