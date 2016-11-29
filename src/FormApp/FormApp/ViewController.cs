using System;

using UIKit;

namespace FormApp
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			SetButtonStyle();

			Title = "Welcome!";
		}



		public void SetButtonStyle()
		{

			this.AddUserButton.BackgroundColor = UIColor.GroupTableViewBackgroundColor;
			this.AddUserButton.Layer.BorderWidth = 2f;
			this.AddUserButton.Layer.BorderColor = UIColor.Gray.CGColor;
			this.AddUserButton.ContentEdgeInsets = new UIEdgeInsets(8, 0, 8, 0);

			this.GoListButton.BackgroundColor = UIColor.GroupTableViewBackgroundColor;
			this.GoListButton.Layer.BorderWidth = 2f;
			this.GoListButton.Layer.BorderColor = UIColor.Gray.CGColor;
			this.GoListButton.ContentEdgeInsets = new UIEdgeInsets(8, 0, 8, 0);
		}
	}
}
