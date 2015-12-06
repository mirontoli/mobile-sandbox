// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace tollesandbox
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnOK { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtAge { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtName { get; set; }

		[Action ("BtnOK_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnOK_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnOK != null) {
				btnOK.Dispose ();
				btnOK = null;
			}
			if (txtAge != null) {
				txtAge.Dispose ();
				txtAge = null;
			}
			if (txtName != null) {
				txtName.Dispose ();
				txtName = null;
			}
		}
	}
}
