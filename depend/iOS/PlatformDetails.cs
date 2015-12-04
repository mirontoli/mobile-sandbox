using System;
using depend.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(PlatformDetails))]
namespace depend.iOS
{
	public class PlatformDetails : IMyInterface
	{
		public PlatformDetails ()
		{
		}
		public string GetPlatformName() {
			return "I am iPhone";
		}
	}
}

