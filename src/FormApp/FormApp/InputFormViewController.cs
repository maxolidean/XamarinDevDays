using Foundation;
using System;
using UIKit;
using GalaSoft.MvvmLight.Helpers;
using System.Threading.Tasks;

namespace FormApp
{
	public partial class InputFormViewController : UIViewController
	{
		public ViewModel ViewModel = new ViewModel();
		LoadingOverlay loadingOverlay;

		public InputFormViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			SetButtonStyle();
			InitViewModel();
			SetShouldReturnDelegates();
			Title = "Create User";

			AddUserButton.TouchUpInside += async (sender, e) => await AddUser();
		}

		public async Task AddUser()
		{
			var bounds = UIScreen.MainScreen.Bounds;

			loadingOverlay = new LoadingOverlay(bounds);
			View.Add(loadingOverlay);

			var result = await ViewModel.CreateUser();

			loadingOverlay.Hide();

			if (result)
				ShowMessage("User Added!");
		}

			private void SetShouldReturnDelegates()
		{
			FirstNameTextField.ShouldReturn += (textField) =>
			{
				LastNameTextField.BecomeFirstResponder();
				return true;
			};

			LastNameTextField.ShouldReturn += (textField) =>
			{
				EmailTextField.BecomeFirstResponder();
				return true;
			};

			EmailTextField.ShouldReturn += (textField) =>
			{
				View.EndEditing(true);
				AddUserButton.BecomeFirstResponder();
				return true;
			};
		}

		public void SetButtonStyle()
		{

			this.AddUserButton.BackgroundColor = UIColor.GroupTableViewBackgroundColor;
			this.AddUserButton.Layer.BorderWidth = 2f;
			this.AddUserButton.Layer.BorderColor = UIColor.Gray.CGColor;
			this.AddUserButton.ContentEdgeInsets = new UIEdgeInsets(8, 0, 8, 0);
		}


		private void InitViewModel()
		{
			FirstNameTextField.EditingChanged += (sender, e) => { };
			LastNameTextField.EditingChanged += (sender, e) => { };
			EmailTextField.EditingChanged += (sender, e) => { };

			this.SetBinding(() => ViewModel.User.Name, () => FirstNameTextField.Text, BindingMode.TwoWay).ObserveTargetEvent("EditingChanged");
			this.SetBinding(() => ViewModel.User.LastName, () => LastNameTextField.Text, BindingMode.TwoWay).ObserveTargetEvent("EditingChanged");
			this.SetBinding(() => ViewModel.User.Email, () => EmailTextField.Text, BindingMode.TwoWay).ObserveTargetEvent("EditingChanged");

			ViewModel.OnFirstNameValidation += (string error) =>
			{
				FirstNameTextField.BecomeFirstResponder();
				this.ShowError(error);
			};

			ViewModel.OnLastNameValidation += (string error) =>
			{
				LastNameTextField.BecomeFirstResponder();
				this.ShowError(error);
			};
			ViewModel.OnEmailNameValidation += (string error) =>
			{
				EmailTextField.BecomeFirstResponder();
				this.ShowError(error);
			};
			ViewModel.OnUnexpectedError += (string error) =>
			{
				FirstNameTextField.BecomeFirstResponder();
				this.ShowError(error);
			};

			ViewModel.OnError += (string error) =>
			{
				FirstNameTextField.BecomeFirstResponder();
				this.ShowError(error);
			};
		}

		public void ShowError(string message)
		{
			var alert = new UIAlertView();
			alert.Title = "Ups!";
			alert.AddButton("Ok");
			alert.Message = message;
			alert.AlertViewStyle = UIAlertViewStyle.Default;
			alert.Show();
		}

		public void ShowMessage(string message)
		{
			var alert = new UIAlertView();
			alert.Title = "Message!";
			alert.AddButton("Ok");
			alert.Message = message;
			alert.AlertViewStyle = UIAlertViewStyle.Default;
			alert.Show();
		}

	}
}