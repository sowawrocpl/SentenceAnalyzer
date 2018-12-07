using System.Text;
using System.Windows;
using SentenceAnalyzer.BusinessLogic.Abstraction;

namespace SentenceAnalyzer
{
    public partial class MainWindow : Window
    {
        private ITextAnalyzer _analyzer;

        public MainWindow(ITextAnalyzer analyzer)
        {
            InitializeComponent();

            _analyzer = analyzer;
            SentenceTextBox.Text = "This is an example text demonstrate how this analyzer works. Click on button below and check it.";
        }

        private void CountWordsExecute(object sender, RoutedEventArgs e)
        {
            var counts = _analyzer.CountWords(SentenceTextBox.Text);

            var sb = new StringBuilder();
            foreach (var word in counts)
            {
                sb.AppendLine($"{word.Key} - {word.Value}");
            }

            ResultTextBox.Text = sb.ToString();
        }
    }
}
