using System;

namespace depend
{
	public interface IMyLocation
	{
		void ObtainMyLocation();
		event EventHandler<ILocationEventArgs> locationObtained;
	}
	public interface ILocationEventArgs {
		double lat { get; set;}
		double lng { get; set;}
	}
}

