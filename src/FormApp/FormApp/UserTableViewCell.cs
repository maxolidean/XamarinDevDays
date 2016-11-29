using Foundation;
using System;
using UIKit;
using FormApp.Model;

namespace FormApp
{
    public partial class UserTableViewCell : UITableViewCell
    {
        public UserTableViewCell (IntPtr handle) : base (handle)
        {
        }

		public void SetValues(User user)
		{
			this.FullNameLabel.Text = string.Format("{0} {1}", user.Name, user.LastName);
			this.EmailLabel.Text = user.Email;
		}

    }
}