using Newtonsoft.Json;

namespace Core
{
    public class Asset
    {
        [JsonProperty("asset_id")]
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        [JsonProperty("change_7d")]
        public decimal Changed7D { get; set; }
    }
}
