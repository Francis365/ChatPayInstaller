using Binding;
using Foundation;

using ObjCRuntime;
using System;
using UIKit;

namespace ChatPayKeyboard
{
    public partial class KeyboardViewController : UIInputViewController
    {

        public KeyboardViewController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void UpdateViewConstraints()
        {
            base.UpdateViewConstraints();

            // Add custom view sizing constraints here
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        class callback : KeyboardControllerCallback
        {

            KeyboardViewController controller;

            public callback(KeyboardViewController controller)
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

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            //show view from binding library
            var proxy = new KeyboardProxy();

            proxy.OnLaunchKeyboardWithViewController(this, new callback(this));
        }

        public override void TextWillChange(IUITextInput textInput)
        {
            // The app is about to change the document's contents. Perform any preparation here.
        }

        public override void TextDidChange(IUITextInput textInput)
        {

        }
    }
}
