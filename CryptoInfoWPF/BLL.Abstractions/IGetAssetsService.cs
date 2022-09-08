using Core;

namespace BLL.Abstractions
{
    public interface IGetAssetsService
    {
        public Task<List<Asset>> GetAssets(string from);
        public Task<List<Market>> GetAssetsMarkets(string assetId, string from);
    }
}
