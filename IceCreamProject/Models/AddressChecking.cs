using IceCreamProject.Models.project.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IceCreamProject.Models
{
    public class AddressChecking
    {
        public Boolean CheckAddress(string city, string street)
        {
            var response = new WebClient().DownloadString("https://data.gov.il/api/3/action/datastore_search?resource_id=bf185c7f-1a4e-4662-88c5-fa118a244bda&&limit=130000");
            Root3 TheTags = JsonConvert.DeserializeObject<Root3>(response);
            if (city == "תל אביב")
                city = "תל אביב - יפו";
            foreach (var item in TheTags.result.records)
                if (item.city_name.Trim() == city && item.street_name.Trim() == street)
                    return true;
            return false;
        }

    }
}
