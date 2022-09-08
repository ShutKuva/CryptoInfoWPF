using BLL.Abstractions;
using CryptoInfoWPF.Enums;
using CryptoInfoWPF.ViewModels;
using System.Windows;

namespace CryptoInfoWPF
{
    public partial class MainWindow : Window
    {
        private readonly NavigationManager _navigationManager;
        private readonly MainWindowViewModel _viewModel;

        public MainWindow(IGetAssetsService getAssetsService, MainWindowViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;

            DataContext = viewModel;

            _navigationManager = new NavigationManager(MainFrame, getAssetsService);

            _navigationManager.NavigateTo(PageEnum.Main);
        }
    }
}
