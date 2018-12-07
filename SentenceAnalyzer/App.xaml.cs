using System.Windows;
using SentenceAnalyzer.BusinessLogic.Abstraction;
using SentenceAnalyzer.BusinessLogic.Implementation;
using SimpleInjector;

namespace SentenceAnalyzer
{
    public partial class App : Application
    {
        private Container _container;

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            _container = CreateContainer();
            var mainView = _container.GetInstance<MainWindow>();
            mainView.Show();            
        }

        private Container CreateContainer()
        {
            var container = new Container();
            container.Register<ITextSplitter, TextSplitter>();
            container.Register<IWordCounter, WordCounter>();
            container.Register<ITextAnalyzer, TextAnalyzer>();
            container.Register<MainWindow>();

            return container;
        }
    }
}
