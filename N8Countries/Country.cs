using System.Collections.Generic;
using Newtonsoft.Json;

namespace CountriesRESTApiApplication.Models
{
    public class Country
    {
        [JsonProperty("name")]
        public CountryNameDetail Name { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("subregion")]
        public string SubRegion { get; set; }
        [JsonProperty("latlng")]
        public IEnumerable<double> Coordinates { get; set; }
        [JsonProperty("area")]
        public double Area { get; set; }
        [JsonProperty("population")]
        public int Population { get; set; }
    }


    public class CountryNameDetail
    {
        [JsonProperty("common")]
        public string Common { get; set; }
        [JsonProperty("official")]
        public string Official { get; set; }
    }
}