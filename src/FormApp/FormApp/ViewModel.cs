using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using FormApp.Helper;
using FormApp.Model;
using GalaSoft.MvvmLight;

namespace FormApp
{
	public class ViewModel : ViewModelBase
	{
		
		public const string BASE_URI = "http://lagash-xamarindevdays.azurewebsites.net/";
		public static ApiClient Client { get; private set; }
		public User User { get; set; }
		public List<User> Users { get; set; }

		public Action<string> OnFirstNameValidation { get; set; }
		public Action<string> OnLastNameValidation { get; set; }
		public Action<string> OnEmailNameValidation { get; set; }
		public Action<string> OnUnexpectedError { get; set; }
		public Action<string> OnError { get; set; }

		public ViewModel()
		{
			Client = new ApiClient(BASE_URI);
			User = new User();
			Users = new List<User>();
		}

		public async Task<bool> LoadUsers()
		{
			try
			{
				this.Users = (await Client.GetAsync<IEnumerable<User>>("api/form")).ToList();

				/*
				var output = new List<User>() {
					new User() {Name="Sergio", LastName="Carreño", Email="sergioc@lagash.com"},
					new User() {Name="John", LastName="Doe", Email="john@lagash.com"}
				};


				this.Users = output;
				*/
			}
			catch (Exception ex)
			{
				OnUnexpectedError(ex.Message);
				return false;
			}

			return true;
		}

		public async Task<bool> CreateUser()
		{
			if (!(Validate()))
				return false;

			try
			{
				var response = await Client.PostAsync<string>("api/form", this.User);
			}
			catch (Exception ex)
			{
				OnUnexpectedError(ex.Message);
				return false;
			}

			return true;
		}

		private bool Validate()
		{
			if (String.IsNullOrWhiteSpace(User.Name))
			{
				OnFirstNameValidation("First Name required!");
				return false;
			}

			if (String.IsNullOrWhiteSpace(User.LastName))
			{
				OnLastNameValidation("Last Name required!");
				return false;
			}

			if (String.IsNullOrWhiteSpace(User.Email))
			{
				OnEmailNameValidation("Email required!");
				return false;
			}
			if (!User.Email.Contains("@"))
			{
				OnEmailNameValidation("Email address doesn't seems to be correct...");
				return false;
			}

			return true;
		}

	}
}
