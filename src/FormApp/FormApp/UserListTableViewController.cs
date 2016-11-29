using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using FormApp.Model;

namespace FormApp
{
    public partial class UserListTableViewController : UITableViewController
    {
		public ViewModel ViewModel = new ViewModel();

		public UserListTableViewController (IntPtr handle) : base (handle)
        {
        }

		public async override void ViewDidLoad()
		{
			base.ViewDidLoad();
			await ViewModel.LoadUsers();

			Title = "User List";

			this.MainTableView.Source = new UserTableSource(ViewModel.Users);
			this.MainTableView.ReloadData();
		}
    }


	public partial class UserTableSource : UITableViewSource
	{
		const string identifier = "UserTableViewCell";
		List<User> list;
		public UserTableSource(List<User> list)
		{
			this.list = list;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return list.Count;
		}

		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 68f;
		}
		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(identifier, indexPath) as UserTableViewCell;
			var item = list[indexPath.Row];

			cell.SetValues(item);

			return cell;
		}
	}
}