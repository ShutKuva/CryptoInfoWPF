using CryptoInfoWPF.Commands;
using System;
using System.Windows;

namespace CryptoInfoWPF.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public CommandWithParameter ThemeChanged { get; set; }

        public MainWindowViewModel()
        {
            ThemeChanged = new CommandWithParameter(ChangeTheme);
        }

        private void ChangeTheme(object parameter)
        {
            if (parameter as string == null)
            {
                return;
            }

            bool itsTheme = false;

            foreach (ResourceDictionary resource in Application.Current.Resources.MergedDictionaries)
            {
                foreach (object key in resource.Keys)
                {
                    if (key as string == "Theme")
                    {
                        itsTheme = true;
                        break;
                    }
                }

                if (itsTheme)
                {
                    try
                    {
                        ResourceDictionary newTheme = new ResourceDictionary();
                        newTheme.Source = new Uri($"Styles/Themes/{(string)parameter}Scheme.xaml", UriKind.Relative);

                        Application.Current.Resources.MergedDictionaries.Remove(resource);

                        Application.Current.Resources.MergedDictionaries.Add(newTheme);
                    }
                    catch
                    {
                        break;
                    }
                    break;
                }
            }
        }
    }
}
