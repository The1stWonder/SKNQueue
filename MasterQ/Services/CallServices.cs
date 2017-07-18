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
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            var client = new HttpClient();
            var response = client.PostAsync(url, content);

            var result = response.Result.Content.ReadAsStringAsync().Result;
            Debug.WriteLine("Result: " + result);
            return result;
        }
        public static String callGet(String url)
        {
            var http = new HttpClient();
            var result = http.GetStringAsync(url);

            Debug.WriteLine("Result: " + result);
            return result.Result;
        }
    }

}
