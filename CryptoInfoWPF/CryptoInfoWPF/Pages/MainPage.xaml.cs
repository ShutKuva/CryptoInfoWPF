using CryptoInfoWPF.PageModels;
using System.Windows.Controls;

namespace CryptoInfoWPF.Pages
{
    public partial class MainPage : Page
    {
        public MainPage(MainPageModel pageModel)
        {
            DataContext = pageModel;
        }
    }
}
