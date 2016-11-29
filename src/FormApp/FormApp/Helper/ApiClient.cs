using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FormApp.Helper
{
	public class ApiClient
	{
		protected readonly static HttpClient Client = new HttpClient();
		public string BaseUri { get; private set; }

		public ApiClient(string baseUri)
		{
			BaseUri = baseUri;
		}


		public async Task<T> PostAsync<T>(string relativeUri, object message)
		{
			var request = new HttpRequestMessage(HttpMethod.Post, String.Concat(BaseUri, relativeUri));
			request.Content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
			var response = await Client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			var responseContent = await response.Content.ReadAsStringAsync();
			var output = JsonConvert.DeserializeObject<T>(responseContent);
			return output;
		}

		public async Task<T> GetAsync<T>(string relativeUri)
		{
			var request = new HttpRequestMessage(HttpMethod.Get, String.Concat(BaseUri, relativeUri));
			var response = await Client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			var responseContent = await response.Content.ReadAsStringAsync();
			var output = JsonConvert.DeserializeObject<T>(responseContent);
			return output;
		}
	}
}
