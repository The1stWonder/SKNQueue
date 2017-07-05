using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MasterQ
{
	public class SampleService
	{
		public SampleService()
		{
		}


		public static List<SampleJSONService> CallGet()
		{
			var http = new HttpClient();
            var result = http.GetStringAsync(ServiceURL.ipServer+ServiceURL.sampleUrlGet);

			Debug.WriteLine("Result: " + result);
			return JArray.Parse(result.Result).ToObject<List<SampleJSONService>>();
		}


		public async static Task<List<SampleJSONService>> CallGetAsync()
		{
			var http = new HttpClient();
			var result = await http.GetStringAsync(ServiceURL.ipServer + ServiceURL.sampleUrlGet);

			Debug.WriteLine("Result: " + result);
			return JArray.Parse(result).ToObject<List<SampleJSONService>>();
		}

        public static SampleJSONService CallPost(Login input)
		{
            string kUrl = ServiceURL.ipServer+ServiceURL.sampleUrlPost;

            SampleJSONService postData = new SampleJSONService();
            postData.UserName = input.username;
            postData.Password = input.password;

            var json = JsonConvert.SerializeObject(postData);
			var content = new StringContent(json, Encoding.UTF8, "application/json");


			var client = new HttpClient();
			var response = client.PostAsync(kUrl, content);

            var result = response.Result.Content.ReadAsStringAsync().Result;
			Debug.WriteLine("Result: " + result);
            return JObject.Parse(result).GetValue("member").ToObject<SampleJSONService>();

		}

		public static async Task<SampleJSONService> CallTest()
		{
			var http = new HttpClient();
			var result = await http.GetStringAsync("http://jsonplaceholder.typicode.com/posts/1");

			Debug.WriteLine("Result: " + result);
			return JObject.Parse(result).ToObject<SampleJSONService>();
		}
		public async static Task<SampleJSONService> CallPostAsync()
		{
			const string kUrl = "http://jsonplaceholder.typicode.com/posts/";

			var postData = new List<KeyValuePair<string, string>>();
			postData.Add(new KeyValuePair<string, string>("UserId", "120"));
			postData.Add(new KeyValuePair<string, string>("Title", "My First Post"));
			postData.Add(new KeyValuePair<string, string>("Content", "Macoratti .net - Quase tudo para .NET!"));

			//postData.Add(new KeyValuePair<string, string>("password", userbean.Password));
			//postData.Add(new KeyValuePair<string, string>("type", "foods")); //foods, superhero, training, songs

			var content = new System.Net.Http.FormUrlEncodedContent(postData);


			var client = new HttpClient();
			var response = await client.PostAsync(kUrl, content);
			//var msg = response.Content.ReadAsStringAsync().Result;
			//var result = JObject.Parse(msg).ToObject<JSonRest>();
			//Debug.WriteLine("Result: " + result.body);
			//return result;

			var result = response.Content.ReadAsStringAsync().Result;
			Debug.WriteLine("Result: " + result);
			return JObject.Parse(result).ToObject<SampleJSONService>();

		}
	}
}
