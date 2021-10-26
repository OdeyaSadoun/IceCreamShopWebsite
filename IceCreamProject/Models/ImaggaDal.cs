using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// This examples is using RestSharp as a REST client - http://restsharp.org

using RestSharp;
using Newtonsoft.Json;

namespace IceCreamProject.Models
{
    public class ImaggaSampleClass
    {
        public List<string> CheckImage(string imageUrl)
        {
            List<string> Result = null;

            string apiKey = "acc_1d00d8d6739daa2";
            string apiSecret = "6fc5b4f24c1113fbfd52c2d2afcafefb";
            //string imageUrl = "https://docs.imagga.com/static/images/docs/sample/japan-605234_1280.jpg";

            string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));

            var client = new RestClient("https://api.imagga.com/v2/tags");
            client.Timeout = -1;

            var request = new RestRequest(Method.GET);
            request.AddParameter("image_url", imageUrl);
            request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));

            IRestResponse response = client.Execute(request);
            // Console.Write(response.Content);
            // Console.ReadLine();
            Result = ConvertTpDictionary(response.Content);
            return Result;
        }

        public List<string> ConvertTpDictionary(string response)
        {
            List<string> Result = new List<string>();
            Root2 theTags = JsonConvert.DeserializeObject<Root2>(response);

            foreach(Tag item in theTags.result.tags)
            {
                Result.Add(item.tag.en);
            }

            return Result;
        }
    }
}
