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
            try
            {
                Debug.WriteLine("Request Url : " + url);
                Debug.WriteLine("Request: " + JObject.FromObject(input).ToString());
                var json = JsonConvert.SerializeObject(input);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var client = new HttpClient();
                var response = client.PostAsync(url, content);

                var result = response.Result.Content.ReadAsStringAsync().Result;
                Debug.WriteLine("Response: " + JObject.Parse(result).ToString());
                return (String.IsNullOrEmpty(result)) ? getDefaultHeader() : result;
            }
            catch
            {
                return getDefaultHeader();
            }
        }
        public static String callGet(String url)
        {
            try
            {
                Debug.WriteLine("Request Url : " + url);
                var http = new HttpClient();
                var result = http.GetStringAsync(url);

                Debug.WriteLine("Response: " + JObject.Parse(result.Result).ToString());
                return (String.IsNullOrEmpty(result.Result)) ? getDefaultHeader() : result.Result;
            }
            catch
            {
                return getDefaultHeader();
            }
        }

        private static String getDefaultHeader()
        {
            GetCodeDescriptionRs ret = new GetCodeDescriptionRs();
            ret.header = JObject.Parse(JsonConvert.SerializeObject(Utils.getCodeDesc(Constants.ERROR_SERVER_DOWN))).ToObject<HeaderResponse>();
            ret.header.isSuccess = false;
            return JsonConvert.SerializeObject(ret);
        }
    }

}
