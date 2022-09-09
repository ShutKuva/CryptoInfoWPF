using Core.CryptingUp;

namespace BLL.Abstractions
{
    public interface IGetAssetsService
    {
        public Task<AssetsResponse> GetAssets(string from);
        public Task<MarketsResponse> GetAssetsMarkets(string assetId, string from);
    }
}
