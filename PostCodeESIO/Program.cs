using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace PostCodeESIO
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglePostCode singlePostCode = new SinglePostCode();
            string postcode = "EC2y 5AS";
            singlePostCode.GetSinglePostcode(postcode);
        }
    }

    public class AppConfigReader
    {
        public static string BaseUri = ConfigurationManager.AppSettings.Get("base_uri");
    }

    public class SinglePostCode
    {
        public string base_uri = ConfigurationManager.AppSettings.Get("base_uri");
        public RestClient restClient { get; set; }

        public JObject PostCodeSingleResponseContent { get; set; }
        public string PostcodeSelected { get; set; }
        //public SinglePostCode() => restClient = new RestClient { BaseUrl = new Uri(base_uri) };
        public SinglePostCode() => restClient = new RestClient();

        public void GetSinglePostcode(string postcode)
        {
            RestRequest request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            PostcodeSelected = postcode;
            request.Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}";
            IRestResponse response = restClient.Execute(request);
            PostCodeSingleResponseContent = JObject.Parse(response.Content);
            string str = PostCodeSingleResponseContent["status"].ToString();
        }
    }
}
