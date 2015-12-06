using System;

using UIKit;

namespace tollesandbox
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.txtName.EditingDidEndOnExit += (object sender, EventArgs e) => {
				this.txtName.ResignFirstResponder();
			};
			this.txtAge.KeyboardType = UIKeyboardType.NumberPad;
			//dismiss soft keyboard when tapping outside text boxes
			//https://forums.xamarin.com/discussion/5934/ios-newb-how-do-you-get-rid-of-the-keyboard
			View.AddGestureRecognizer(new UITapGestureRecognizer(() => View.EndEditing(true)));
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void BtnOK_TouchUpInside (UIButton sender)
		{
			var alert = UIAlertController.Create("Hello World", "Welcome to Xamarin, " + txtName.Text, UIAlertControllerStyle.Alert);
			alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, UIAlertAction => {
			}));
			alert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Default, UIAlertAction => {}));
			this.PresentViewController(alert, true, null);
		}
	}
}

