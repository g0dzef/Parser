using Parser.WPF.Commands.MainWindowCommands;
using Parser.WPF.MVVM.ViewModel.Base;
using Parser.WPF.Services.HTML;
using System.Windows.Input;

namespace Parser.WPF.MVVM.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Services
        private readonly Loader _loader;
        #endregion

        #region Commands
        public ICommand LoadContentCommand { get; set; }
        #endregion

        #region Params
        private string _siteUrl = "";
        public string SiteUrl
        {
            get => _siteUrl;
            set => Set(ref _siteUrl, value);
        }

        private string _siteContent = "";
        public string SiteContent
        {
            get => _siteContent;
            set => Set(ref _siteContent, value);
        }
        #endregion

        public MainWindowViewModel(Loader loader)
        {
            _loader = loader;

            LoadContentCommand = new LoadContentCommand(this, _loader);
        }
    }
}
