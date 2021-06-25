using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Binding;

namespace ChatPayInstaller.iOS.Helper
{
    public class KeyboardHelper
    {

        class callback : KeyboardControllerCallback
        {

            UIInputViewController controller;

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
            var proxy = new KeyboardProxy();

            proxy.OnLaunchKeyboardWithViewController(inputViewController, new callback(inputViewController));
        }
    }
}