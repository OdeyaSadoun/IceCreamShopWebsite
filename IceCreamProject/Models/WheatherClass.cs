using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamProject.Models
{
    public class WheatherClass
    {
        public Main ConvertToDictionary(string response)
        {
            Root TheTags = JsonConvert.DeserializeObject<Root>(response);
            return TheTags.main;
        }
        public Main CheckWeather(string city)
        {//input city   return the details of the city
            Main result = null;
            string apiKey = "efe83d986e7db538087a0a3355daeff8";
            // ememple https://api.openweathermap.org/data/2.5/weather?q=elad&appid=efe83d986e7db538087a0a3355daeff8           
            var client = new RestClient("https://api.openweathermap.org/data/2.5/weather");
            client.Timeout = -1;

            var request = new RestRequest(Method.GET);
            request.AddParameter("q", city);
            request.AddParameter("appid", apiKey);
            request.AddParameter("units", "metric");
            IRestResponse response = client.Execute(request);//JSON
            result = ConvertToDictionary(response.Content);//string(JSON)
            return result;


        }
    }
}
