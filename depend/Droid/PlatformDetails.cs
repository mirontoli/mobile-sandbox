using System;

namespace depend.Droid
{
	public class PlatformDetails : IMyInterface
	{
		public PlatformDetails ()
		{
		}
		public string GetPlatformName() {
			return "I am Android!";
		}
	}
}

