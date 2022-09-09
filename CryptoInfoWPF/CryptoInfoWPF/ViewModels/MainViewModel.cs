using BLL.Abstractions;
using Core;
using Core.CryptingUp;
using CryptoInfoWPF.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoInfoWPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private static int _from = 0;

        #region Fields

        private readonly IGetAssetsService _getAssetsService;

        private readonly List<int> _history = new List<int>() { 0 };

        private int _next = 0;

        #endregion

        #region Properties

        private List<Asset> _listOfCourencies = new List<Asset>();
        public List<Asset> ListOfCourencies
        {
            get => _listOfCourencies;
            set
            {
                _listOfCourencies = value;

                OnPropertyChanged(nameof(ListOfCourencies));
            }
        }

        private bool _isLoading;
        private bool IsLoadingBool
        {
            get => _isLoading;
            set 
            {
                _isLoading = value;

                OnPropertyChanged(nameof(IsLoading));
                OnPropertyChanged(nameof(IsLoadingReverted));
            }
        }
        public Visibility IsLoading 
        {
            get => IsLoadingBool ? Visibility.Collapsed : Visibility.Visible;
        }

        public Visibility IsLoadingReverted
        {
            get => IsLoadingBool ? Visibility.Visible : Visibility.Collapsed;
        }

        #endregion

        #region Events
        public event Action<Asset> OnAssetChoosed;
        #endregion

        #region Commands

        public CommandWithoutParameters NextCommand { get; set; }
        public CommandWithoutParameters PrevCommand { get; set; }

        #endregion

        public MainViewModel(IGetAssetsService getAssetsService)
        {
            _getAssetsService = getAssetsService;

            NextCommand = new CommandWithoutParameters(NextPage);
            PrevCommand = new CommandWithoutParameters(PrevPage);
        }

        public void AssetSelected(object asset)
        {
            Asset actualAsset = asset as Asset;

            if (asset != null)
            {
                OnAssetChoosed?.Invoke(actualAsset);
            }
        }

        public async Task GetAssetsFromApi()
        {
            IsLoadingBool = true;

            Task<AssetsResponse> task = _getAssetsService.GetAssets(_from.ToString());

            await task.ContinueWith(assets =>
            {
                AssetsResponse response = assets.Result;

                ListOfCourencies = response.Assets;

                _next = int.Parse(response.Next);

                IsLoadingBool = false;
            });
        }

        private async void NextPage()
        {
            _history.Add(_next);

            _from = _next;

            await GetAssetsFromApi();
        }

        private async void PrevPage()
        {
            if (_history.Count != 1)
            {
                _next = _history[_history.Count - 2];

                _from = _history[_history.Count - 3];

                _history.RemoveAt(_history.Count - 1);

                await GetAssetsFromApi();
            }
        }
    }
}
