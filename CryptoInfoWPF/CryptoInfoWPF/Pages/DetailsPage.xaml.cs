using CryptoInfoWPF.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace CryptoInfoWPF.Pages
{
    public partial class DetailsPage : Page
    {
        private readonly DetailsViewModel _viewModel;

        public DetailsPage(DetailsViewModel viewModel)
        {
            _viewModel = viewModel;

            DataContext = viewModel;

            InitializeComponent();
        }

        private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await _viewModel.GetMarkets();
        }
    }
}
