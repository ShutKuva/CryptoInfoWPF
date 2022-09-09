using BLL.Abstractions;
using Core;
using CryptoInfoWPF.Enums;
using CryptoInfoWPF.Pages;
using System.Windows.Controls;
using System.Windows.Input;

namespace CryptoInfoWPF.ViewModels
{
    public class NavigationManager
    {
        private readonly Frame _frame;
        private readonly IGetAssetsService _assetsService;

        private object parameter;

        public NavigationManager(Frame frame, IGetAssetsService assetsService)
        {
            _frame = frame;
            _assetsService = assetsService;
        }

        public void NavigateTo(PageEnum page)
        {
            switch (page)
            {
                case PageEnum.Details:
                    DetailsViewModel detailsViewModel = new DetailsViewModel(_assetsService, (Asset)parameter);
                    detailsViewModel.BackEvent += () => NavigateTo(PageEnum.Main);
                    _frame.Navigate(new DetailsPage(detailsViewModel));
                    break;
                case PageEnum.Main:
                    MainViewModel viewModel = new MainViewModel(_assetsService);
                    viewModel.OnAssetChoosed += (asset) => { parameter = asset; NavigateTo(PageEnum.Details); };
                    _frame.Navigate(new MainPage(viewModel));
                    break;
            }
        }
    }
}
