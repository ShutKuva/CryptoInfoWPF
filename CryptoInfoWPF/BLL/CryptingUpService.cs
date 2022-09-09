using BLL.Abstractions;
using Core;
using Core.CryptingUp;
using Newtonsoft.Json;

namespace BLL
{
    public class CryptingUpService : IGetAssetsService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://cryptingup.com/api";

        public CryptingUpService()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress= new Uri(_apiUrl)
            };
        }

        public async Task<AssetsResponse> GetAssets(string from)
        {
            try
            {
                var queries = new Dictionary<string, string>
                {
                    ["size"] = 10.ToString()
                };

                if (int.Parse(from) != 0)
                {
                    queries["start"] = from;
                }

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, GetUriWithQueries($"{_apiUrl}/assets", queries));

                HttpResponseMessage response = await _httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
                }

                string responseContent = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<AssetsResponse>(responseContent);
            }
            catch
            {
                throw;
            }
        }

        public async Task<MarketsResponse> GetAssetsMarkets(string assetId, string from)
        {
            var queries = new Dictionary<string, string>
            {
                ["size"] = 10.ToString()
            };

            if(int.Parse(from) != 0)
            {
                queries["start"] = from;
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, GetUriWithQueries($"{_apiUrl}/assets/{assetId}/markets", queries));

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
            }

            return JsonConvert.DeserializeObject<MarketsResponse>(await response.Content.ReadAsStringAsync());
        }

        private Uri GetUriWithQueries(string absoluteUrl, IDictionary<string, string> queries)
        {
            var uriBuilder = new UriBuilder(new Uri(absoluteUrl));

            uriBuilder.Query = QueryHandler.GetQueriesFromDictionary(queries);

            return uriBuilder.Uri;
        }
    }
}
