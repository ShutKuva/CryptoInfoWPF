using BLL.Abstractions;
using CryptoInfoWPF.Enums;
using CryptoInfoWPF.Pages;
using System.Windows.Controls;

namespace CryptoInfoWPF.ViewModels
{
    public class NavigationManager
    {
        private readonly Frame _frame;
        private readonly IGetAssetsService _assetsService;

        public NavigationManager(Frame frame, IGetAssetsService assetsService)
        {
            _frame = frame;
            _assetsService = assetsService;
        }

        public void NavigateTo(PageEnum page)
        {
            switch (page)
            {
                case PageEnum.Main:
                    if(_frame.Navigate(new MainPage(new MainViewModel(_assetsService)))){
                        int i = 42;
                    }
                    break;
            }
        }
    }
}
