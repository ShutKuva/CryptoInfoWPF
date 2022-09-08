using BLL.Abstractions;
using Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoInfoWPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IGetAssetsService _getAssetsService;

        private List<Asset> _listOfCourencies;
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
            }
        }
        public Visibility IsLoading 
        {
            get => IsLoadingBool ? Visibility.Collapsed : Visibility.Visible;
        }

        #region Events
        public event Action<Asset> OnAssetChoosed;
        #endregion

        public MainViewModel(IGetAssetsService getAssetsService)
        {
            _getAssetsService = getAssetsService;
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

            Task<List<Asset>> task = _getAssetsService.GetAssets(0.ToString());

            await task.ContinueWith(assets =>
            {
                ListOfCourencies = assets.Result;

                IsLoadingBool = false;
            });
        }
    }
}
