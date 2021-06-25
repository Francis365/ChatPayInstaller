using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Binding;
using ChatPay.AppInstallHelper;

namespace ChatPayInstaller.iOS.Helper
{
    public class KeyboardHelper
    {
        private static KeyboardProxy proxy = new KeyboardProxy();

        class callback : KeyboardControllerCallback
        {
            private UIInputViewController controller;

            public callback(UIInputViewController controller)
            {
                this.controller = controller;
            }
            public override void OnKeyPadPressedWithText(string text)
            {
                controller.TextDocumentProxy.InsertText(text);

            }

            public override void TextLeftOfCusorWithText(string text)
            {

            }

            public override void TextRightOfCusorWithText(string text)
            {

            }
        }

        public static void LaunchKeyboard(UIInputViewController inputViewController)
        {

            //show view from binding library

            proxy.OnLaunchKeyboardWithViewController(inputViewController, new callback(inputViewController));
        }

        public static void AuthenticateUser(UserDetails userDetails)
        {

            proxy.OnLoginWithUsername(userDetails.SMUsername, userDetails.logDetails.DeviceOS, userDetails.logDetails.DeviceIMEI);
        }
    }
}