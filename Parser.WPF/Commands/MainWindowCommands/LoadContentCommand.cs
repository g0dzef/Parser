using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using AngleSharp.Io;
using Parser.WPF.Commands.Base;
using Parser.WPF.MVVM.ViewModel;
using Parser.WPF.Services.HTML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.WPF.Commands.MainWindowCommands
{
    public class LoadContentCommand : AsyncCommand
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly Loader _loader;

        public LoadContentCommand(MainWindowViewModel mainWindowViewModel, Loader loader)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _loader = loader;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            var content = await _loader.GetContentByUrl(_mainWindowViewModel.SiteUrl);

            HtmlParser parser = new HtmlParser();
            IHtmlDocument document = parser.ParseDocument(content);
            _mainWindowViewModel.SiteContent = document.All[0].TextContent;
            //_mainWindowViewModel.SiteContent = String.Join("\n",document.All);
        }
    }
}
