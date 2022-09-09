using Newtonsoft.Json;

namespace Core
{
    public class Market
    {
        [JsonProperty("exchange_id")]
        public string Id { get; set; }

        [JsonProperty("price_unconverted")]
        public decimal Price { get; set; }
    }
}
