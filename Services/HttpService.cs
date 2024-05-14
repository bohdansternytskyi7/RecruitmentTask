using Newtonsoft.Json;
using RecruitmentTask.Interfaces;

namespace RecruitmentTask.Services
{
	public class HttpService : IHttpService
	{
		private readonly HttpClient _httpClient;

		public HttpService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<string> GetCatFact()
		{
			string apiUrl = "https://catfact.ninja/fact";
			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage response = await client.GetAsync(apiUrl);
				response.EnsureSuccessStatusCode();
				string responseBody = await response.Content.ReadAsStringAsync();
				dynamic jsonResponse = JsonConvert.DeserializeObject(responseBody);
				return jsonResponse.fact;
			}
		}
	}
}
