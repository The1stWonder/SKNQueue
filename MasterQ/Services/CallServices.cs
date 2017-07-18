using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MasterQ
{
    public class CallServices
    {
        public static String callPost(String url, Object input)
        {
            Debug.WriteLine("Request Url : " + url);
            Debug.WriteLine("Request: " + JObject.FromObject(input).ToString());
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            var client = new HttpClient();
            var response = client.PostAsync(url, content);

            var result = response.Result.Content.ReadAsStringAsync().Result;
            Debug.WriteLine("Response: " + JObject.Parse(result).ToString());
            return result;
        }
        public static String callGet(String url)
        {
            Debug.WriteLine("Request Url : " + url);
            var http = new HttpClient();
            var result = http.GetStringAsync(url);

            Debug.WriteLine("Response: " + JObject.Parse(result.Result).ToString());
            return result.Result;
        }
    }

}
