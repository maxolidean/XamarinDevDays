using System;
using Foundation;
using UIKit;

namespace FormApp
{

	//Woraround class, created to avoid the "Set Method Not Found For 'Text'" error, when the viewmodel is being initialized.
	//Set Method Not Found For 'Text'
	[Preserve]
	static class LinkerWorkarounds
	{
		public static void KeepTheseMethods()
		{
			default(UITextField).Text = "";
			throw new Exception("Don't actually call this!");
		}
	}
}
