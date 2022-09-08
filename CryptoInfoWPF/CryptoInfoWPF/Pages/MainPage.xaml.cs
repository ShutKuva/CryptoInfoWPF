using CryptoInfoWPF.ViewModels;
using System;
using System.Windows.Controls;

namespace CryptoInfoWPF.Pages
{
    public partial class MainPage : Page
    {
        private readonly MainViewModel _pageModel;

        public MainPage(MainViewModel pageModel)
        {
            InitializeComponent();

            _pageModel = pageModel;

            DataContext = pageModel;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _pageModel.AssetSelected(((ListBox)sender).SelectedItem);
        }

        private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await _pageModel.GetAssetsFromApi();
        }
    }
}
