using BLL.Abstractions;
using Core;
using Core.CryptingUp;
using CryptoInfoWPF.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoInfoWPF.ViewModels
{
    public class DetailsViewModel : BaseViewModel
    {
        private readonly IGetAssetsService _assetsService;

        public Asset Asset { get; set; }

        public List<string> Markets { get; set; } = new List<string>();

        public event Action BackEvent;

        public CommandWithoutParameters Back { get; set; }

        public DetailsViewModel(IGetAssetsService assetsService, Asset asset)
        {
            _assetsService = assetsService;
            Asset = asset;

            Back = new CommandWithoutParameters(BackMethod);
        }

        public async Task GetMarkets()
        {
            MarketsResponse marketsResponse = await _assetsService.GetAssetsMarkets(Asset.Id, 0.ToString());

            List<string> marketsIds = new List<string>();

            foreach (Market market in marketsResponse.Markets)
            {
                if (!marketsIds.Contains(market.Id))
                {
                    marketsIds.Add(market.Id);
                }
            }

            Markets = marketsIds;

            OnPropertyChanged(nameof(Markets));
        }

        private void BackMethod()
        {
            BackEvent?.Invoke();
        }
    }
}
