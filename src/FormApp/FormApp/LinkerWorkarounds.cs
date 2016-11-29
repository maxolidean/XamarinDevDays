using System;
using Foundation;
using UIKit;

namespace FormApp
{
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
