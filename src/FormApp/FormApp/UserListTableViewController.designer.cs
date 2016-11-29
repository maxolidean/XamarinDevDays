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

namespace FormApp
{
    [Register ("UserListTableViewController")]
    partial class UserListTableViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView MainTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (MainTableView != null) {
                MainTableView.Dispose ();
                MainTableView = null;
            }
        }
    }
}