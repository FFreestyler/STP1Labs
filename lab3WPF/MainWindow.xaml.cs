using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private const string GRAMMAR_REGEXP = @"\[[^]]*]|\{[^}]*}|[^,]+";

        private string[] _rules = new[] { "" };
        private string[] _alphabet = new[] { "" };
        private string _start_rule = "";
        private string[] _end_rules = new[] { "" };

        private string _current_rule = "";

        public string Chain
        {
            get; set;
        } = "";

        public static StackPanel CreateStackPanelRowHeader(string[] cells)
        {
            var r = 4;
            var fullRadius = new CornerRadius(r, r, r, r);
            var leftRadius = new CornerRadius(r, 0, 0, r);
            var rightRadius = new CornerRadius(0, r, r, 0);
            var stackPanel = new StackPanel() { Orientation = Orientation.Horizontal };
            if (cells.Length > 0)
            {
                var isMoreThanOneElement = cells.Length > 1;
                stackPanel.Children.Add(CreateHeaderCell(cells[0], isMoreThanOneElement ? leftRadius : fullRadius));
                for (var i = 1; i < cells.Length - 1; i++)
                {
                    stackPanel.Children.Add(CreateHeaderCell(cells[i]));
                }
                stackPanel.Children.Add(CreateHeaderCell(cells[cells.Length-1], rightRadius));
            }
            return stackPanel;
        }

        public static Border CreateHeaderCell(string label, CornerRadius? cornerRadius = null)
        {
            return new Border()
            {
                Padding = new Thickness(4),
                HorizontalAlignment = HorizontalAlignment.Left,
                Width = 80,
                Child = new TextBlock() { Text = label, HorizontalAlignment = HorizontalAlignment.Center }
            };
        }

        public static Border CreateRowCell(FrameworkElement frameworkElement)
        {
            return new Border()
            {
                Width = 80,
                Child = frameworkElement
            };
        }

        private string _grammar = "";
        public string Grammar
        {
            get => _grammar;
            set
            {
                _grammar = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Grammar)));
            }
        }

        private string _output = "";
        public string Output
        {
            get => _output;
            set
            {
                _output = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Output)));
            }
        }

        private readonly Dictionary<string, List<string>> _graph = new Dictionary<string, List<string>>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void GrammarChanged(object sender, TextChangedEventArgs e)
        {
            async Task<bool> UserKeepsTyping()
            {
                var txt = ((TextBox)sender).Text;
                await Task.Delay(500);
                return txt != ((TextBox)sender).Text;
            }

            if (await UserKeepsTyping())
            {
                return;
            }

            try
            {
                Grammar = ((TextBox)sender).Text;
                var grm = (from Match m in Regex.Matches(_grammar.Replace(" ", ""), GRAMMAR_REGEXP) select m.Value).ToArray();
                _rules = ParseGrammarSetPart(grm[0]).Distinct().ToArray();
                _alphabet = ParseGrammarSetPart(grm[1]).Distinct().ToArray();
                _start_rule = grm[2];
                _end_rules = ParseGrammarSetPart(grm[3]).Distinct().ToArray();

                var newItems = new List<ListViewItem>();

                var headerLabels = new List<string>() { "Правила" };
                headerLabels.AddRange(_alphabet);
                newItems.Add(new ListViewItem()
                {
                    Padding = new Thickness(0),
                    Content = CreateStackPanelRowHeader(headerLabels.ToArray())
                });

                foreach (var rule in _rules)
                {
                    var row = new StackPanel() { Orientation = Orientation.Horizontal };
                    row.Children.Add(CreateRowCell(new TextBlock()
                    {
                        Text = rule,
                        TextAlignment = TextAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        Width = 50
                    })) ;
                    for (var i = 0; i < _alphabet.Length; i++)
                    {
                        var cellContent = new TextBox()
                        {
                            Text = "",
                            TextAlignment = TextAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Width = 50
                        };
                        cellContent.TextChanged += SequenceChanging;
                        row.Children.Add(CreateRowCell(cellContent));
                    }
                    newItems.Add(new ListViewItem()
                    {
                        Padding = new Thickness(0),
                        Content = row
                    });
                }

                grammarRules.ItemsSource = newItems;
            }
            catch
            {

            }
        }

        private void ChainChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;

            if (m_ignoreNextTextChanged)
            {
                m_ignoreNextTextChanged = false;
                return;
            }

            var alphabetRegex = @"[^";
            foreach (var symbol in _alphabet)
            {
                alphabetRegex += symbol;
            }
            alphabetRegex += "]+";

            var selectionStart = textBox.SelectionStart;
            var prevTextLength = textBox.Text.Length;
            textBox.Text = Regex.Replace(textBox.Text, alphabetRegex, "");
            textBox.SelectionStart = selectionStart - (prevTextLength - textBox.Text.Length);

            Chain = textBox.Text;
        }

        private bool m_ignoreNextTextChanged = false;
        private void ChainKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back
                || e.Key == Key.Delete)
            {
                m_ignoreNextTextChanged = true;
            }
        }

        public static List<string> ParseGrammarSetPart(string field)
        {
            return Regex.Replace(field, @"{|}|\s+", "").Split(',').ToList();
        }

        private void SequenceChanging(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;

            if (!_rules.Contains(textBox.Text))
            {
                textBox.Text = "";
            }
        }

        public void CreateGraph()
        {
            try
            {
                _graph.Clear();

                var rowNumber = 1;
                foreach (var row in grammarRules.Items)
                {
                    if (rowNumber == 1)
                    {
                        rowNumber++;
                        continue;
                    }

                    var rowItemNumber = 1;
                    var stackPanelRow = (StackPanel)((ListViewItem)row).Content;
                    var rule = ((TextBlock)(((Border)stackPanelRow.Children[0]).Child)).Text;
                    _graph.Add(rule, new List<string>());
                    foreach (var item in stackPanelRow.Children)
                    {
                        var child = ((Border)item).Child;
                        if (rowItemNumber != 1)
                        {
                            var childText = ((TextBox)child).Text;
                            if (childText == "")
                            {
                                throw new Exception($"Rule sequenc for rule {rule} not defined");
                            }
                            _graph[rule].Add(childText);
                        }
                        rowItemNumber++;
                    }
                    rowNumber++;
                }
            }
            catch
            {
                MessageBox.Show("Одно или несколько правил для состояний не заданы", "Ошибка", MessageBoxButton.OK);
            }
        }

        private void CheckClicked(object sender, RoutedEventArgs e)
        {
            CreateGraph();

            Output = "";
            _current_rule = _start_rule;
            foreach (var symbol in Chain)
            {
                var rule = _graph[_current_rule];
                Output += $"{_current_rule} ";
                for (var i = 0; i < rule.Count; i++)
                {
                    if (symbol == _alphabet[i][0])
                    {
                        _current_rule = rule[i];
                        Output += $"─{symbol}─> ";
                    }
                }
            }
            Output += $"{_current_rule}";

            if (!_end_rules.Contains(_current_rule))
            {
                Output += "!";
                MessageBox.Show("Цепочка не принадлежит ДКА", "Ошибка", MessageBoxButton.OK);
            }
        }
    }
}
