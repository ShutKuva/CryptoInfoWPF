using Core;
using Newtonsoft.Json;

namespace BLL
{
    public class CryptingUpService
    {
        private readonly HttpClient _httpClient;

        public CryptingUpService()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress= new Uri("https://cryptingup.com/api/")
            };
        }

        public async Task<List<Asset>> GetAssets(string from)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(
                GetUri(
                    relativeUrl: "assets",
                    queries: new Dictionary<string, string>
                    {
                        ["size"] = 10.ToString(),
                        ["start"] = from
                    }
                )
            );

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
            }

            return JsonConvert.DeserializeObject<List<Asset>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<Market>> GetAssetsMarkets(string assetId, string from)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(
                GetUri(
                    relativeUrl: $"assets/{assetId}/markets",
                    queries: new Dictionary<string, string>
                        {
                            ["size"] = 10.ToString(),
                            ["start"] = from
                        }
                )
            );

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
            }

            return JsonConvert.DeserializeObject<List<Market>>(await response.Content.ReadAsStringAsync());
        }

        private Uri GetUri(string relativeUrl, IDictionary<string, string> queries)
        {
            var uriBuilder = new UriBuilder(new Uri(relativeUrl, UriKind.Relative));

            uriBuilder.Query = QueryHandler.GetQueriesFromDictionary(queries);

            return uriBuilder.Uri;
        }
    }
}
