using BLL;
using BLL.Abstractions;
using CryptoInfoWPF.ViewModels;
using System.Windows;

namespace CryptoInfoWPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IGetAssetsService getAssetsService = new CryptingUpService();

            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();

            Window mainWindow = new MainWindow(getAssetsService, mainWindowViewModel);

            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
