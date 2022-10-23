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

namespace lab4
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private const string GRAMMAR_REGEXP = @"\[[^]]*]|\{[^}]*}|[^,]+";
        private const string DELETE_SYMBOL = "!";
        private const string EXIT_SYMBOL = "@";
        private const string EMPTY_SYMBOL = "^";

        private string[] _default_alphabet = { DELETE_SYMBOL, EXIT_SYMBOL, EMPTY_SYMBOL };

        private string _rules_count = "1";
        public string RulesCount
        {
            get => _rules_count;
            set
            {
                _rules_count = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RulesCount)));
            }
        }

        private string[] _rules = new[] { "" };
        private string[] _alphabet = new[] { "" };
        private string[] _stack_alphabet = new[] { "" };
        private string _start_rule = "";
        private string _start_stack_symbol = "";
        private string[] _end_rules = new[] { "" };

        private Stack<char> stack = new Stack<char>();

        private string _current_rule = "";

        public string Chain
        {
            get; set;
        } = "";

        public static StackPanel CreateStackPanelRowHeader(string[] cells)
        {
            var r = 4;
            var stackPanel = new StackPanel() { Orientation = Orientation.Horizontal };

            if(cells.Length > 0)
            {
                stackPanel.Children.Add(CreateHeaderCell(cells[0]));
                for(var i = 1; i < cells.Length - 1; i++)
                {
                    stackPanel.Children.Add(CreateHeaderCell(cells[i]));
                }
                stackPanel.Children.Add(CreateHeaderCell(cells[cells.Count() - 1]));
            }
            return stackPanel;
        }

        public static Border CreateHeaderCell(string label)
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

        private readonly Dictionary<string, string> _graph = new Dictionary<string, string>();

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
                Output = "";
                var grm = (from Match m in Regex.Matches(_grammar.Replace(" ", ""), GRAMMAR_REGEXP) select m.Value).ToArray();
                _rules = ParseGrammarSetPart(grm[0]).Distinct().ToArray();
                _alphabet = ParseGrammarSetPart(grm[1]).Distinct().ToArray();
                _stack_alphabet = ParseGrammarSetPart(grm[2]).Distinct().ToArray();
                _start_rule = grm[3];
                _start_stack_symbol = grm[4];
                _end_rules = ParseGrammarSetPart(grm[5]).Distinct().ToArray();

                var extAlphabet = new List<string>();
                extAlphabet.AddRange(_default_alphabet);
                extAlphabet.AddRange(_alphabet);
                _alphabet = extAlphabet.ToArray();

                extAlphabet = new List<string>();
                extAlphabet.AddRange(_default_alphabet);
                extAlphabet.AddRange(_stack_alphabet);
                _stack_alphabet = extAlphabet.ToArray();

                stack.Clear();
                stack.Push(_start_stack_symbol[0]);

                var newItems = new List<ListViewItem>();

                var headerLabels = new List<string>() { "id", "Состояние", "Символ", "Стэк", "Состояние", "Стэк" };
                newItems.Add(new ListViewItem()
                {
                    Padding = new Thickness(0),
                    Content = CreateStackPanelRowHeader(headerLabels.ToArray()),
                });

                //var handles = new List<EventHandler<TextBox, EventArgs>?>() { null, RuleChangingAsync, };

                var rulesCount = int.Parse(RulesCount);

                for(var rc = 0; rc < rulesCount; rc++)
                {
                    var row = new StackPanel() { Orientation = Orientation.Horizontal };
                    for(var i = 0; i < headerLabels.Count; i++) 
                    {
                        var header_ = (Border)((StackPanel)newItems[0].Content).Children[i];
                        header_.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                        FrameworkElement cellContent;
                        if(i == 0)
                        {
                            cellContent = new TextBlock()
                            {
                                Width = header_.DesiredSize.Width,
                                Text = (rc + 1).ToString(),
                                TextAlignment = TextAlignment.Center,
                            };
                        }
                        else
                        {
                            cellContent = new TextBox()
                            {
                                Width = header_.DesiredSize.Width,
                                Text = "",
                                TextAlignment = TextAlignment.Center,
                            };
                            if(i == 1)
                            {
                                ((TextBox)cellContent).TextChanged += RuleChangingAsync;
                            }
                            if(i == 2)
                            {
                                ((TextBox)cellContent).TextChanged += SequenceChangingAsync;
                            }
                            if (i == 3)
                            {
                                ((TextBox)cellContent).TextChanged += StackChangingAsync;
                            }
                            if (i == 4)
                            {
                                ((TextBox)cellContent).TextChanged += RuleChangingAsync;
                            }
                            if (i == 5)
                            {
                                ((TextBox)cellContent).TextChanged += StackMultiplyChangingAsync;
                            }
                        }

                        row.Children.Add(CreateRowCell(cellContent));
                    }
                    newItems.Add(new ListViewItem()
                    {
                        Padding = new Thickness(0),
                        Content = row,
                    });
                }

                grammarRules.ItemsSource = newItems;
            }
            catch
            {

            }
        }

        private async void RuleChangingAsync(object sender, TextChangedEventArgs e)
        {
            async Task<bool> UsersKeepTyping()
            {
                var txt = ((TextBox)sender).Text;
                await Task.Delay(500);
                return txt != ((TextBox)sender).Text;
            }

            if(await UsersKeepTyping())
            {
                return;
            }

            var textBox = (TextBox)sender;

            if(!_rules.Contains(textBox.Text))
            {
                textBox.Text = "";
            }
        }

        private async void SequenceChangingAsync(object sender, TextChangedEventArgs e)
        {
            async Task<bool> UsersKeepTyping()
            {
                var txt = ((TextBox)sender).Text;
                await Task.Delay(500);
                return txt != ((TextBox)sender).Text;
            }

            if (await UsersKeepTyping())
            {
                return;
            }

            var textBox = (TextBox)sender;

            if (!_alphabet.Contains(textBox.Text))
            {
                textBox.Text = "";
            }
        }

        private async void StackChangingAsync(object sender, TextChangedEventArgs e)
        {
            async Task<bool> UsersKeepTyping()
            {
                var txt = ((TextBox)sender).Text;
                await Task.Delay(500);
                return txt != ((TextBox)sender).Text;
            }

            if (await UsersKeepTyping())
            {
                return;
            }

            var textBox = (TextBox)sender;

            if (!_stack_alphabet.Contains(textBox.Text))
            {
                textBox.Text = "";
            }
        }

        private async void StackMultiplyChangingAsync(object sender, TextChangedEventArgs e)
        {
            async Task<bool> UsersKeepTyping()
            {
                var txt = ((TextBox)sender).Text;
                await Task.Delay(500);
                return txt != ((TextBox)sender).Text;
            }

            if (await UsersKeepTyping())
            {
                return;
            }

            var textBox = (TextBox)sender;

            foreach(var s in textBox.Text) 
            {
                if (!_stack_alphabet.Contains(s.ToString()))
                {
                    textBox.Text = "";
                    break;
                }
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

                    var stackPanelRow = (StackPanel)((ListViewItem)row).Content;
                    var children = new List<TextBox>();

                    for(var i = 1; i < stackPanelRow.Children.Count; i++)
                    {
                        children.Add(((TextBox)((Border)stackPanelRow.Children[i]).Child));
                    }

                    //if (_end_rules.Contains(children[3].Text) && children[4].Text != EXIT_SYMBOL)
                    //{
                    //    try
                    //    {
                    //        _graph.Clear();
                    //        MessageBox.Show("Не найден символ выхода в конечном состоянии", "Ошибка", MessageBoxButton.OK);
                    //    } catch { }
                    //}

                    if (!_end_rules.Contains(children[3].Text) && children[4].Text == EXIT_SYMBOL)
                    {
                        try
                        {
                            _graph.Clear();
                            MessageBox.Show("Символ выхода не в конечном состоянии", "Ошибка", MessageBoxButton.OK);
                        }
                        catch { }
                    }
                    var ruleString = $"{children[0].Text},{children[1].Text},{children[2].Text}";
                    var transitionString = $"{children[3].Text} {children[4].Text}";

                    _graph.Add(ruleString, transitionString);
                }
            }
            catch
            {
                try
                {
                    MessageBox.Show("Одно или несколько состояний не заданы", "Ошибка", MessageBoxButton.OK);
                } catch { }
            }
        }

        private void CheckClicked(object sender, RoutedEventArgs e)
        {
            CreateGraph();

            Output = "";
            _current_rule = _start_rule;
            var prev_rule = "";
            var current_symbol = "";
            var process_chain = $"{Chain}^";

            try
            {
                for(var i = 0; i < process_chain.Length; i++)
                {
                    var symbol = process_chain[i];

                    prev_rule = _current_rule;
                    current_symbol = symbol.ToString();
                    var assembled_rule = $"{_current_rule},{current_symbol},{stack.Peek()}";
                    var sequence = _graph[assembled_rule].Split(' ');

                    _current_rule = sequence[0];
                    if(sequence[1].Length > 1)
                    {
                        stack.Push(sequence[1][0]);
                    } 
                    else if (sequence[1] == DELETE_SYMBOL)
                    {
                        stack.Pop();
                    }

                    Output += $"({assembled_rule}) |- ({string.Join(",", sequence)})\n";

                    if(current_symbol == EMPTY_SYMBOL && 
                        !_end_rules.Contains(sequence[0]) && 
                        sequence[1] != EXIT_SYMBOL)
                    {
                        i--;
                        continue;
                    }
                }
            } 
            catch
            {
                try
                {
                    if (current_symbol == "^")
                    {
                        MessageBox.Show("Цепочка не принадлежит ДМПА", "Ошибка", MessageBoxButton.OK);
                        return;
                    }
                    else
                    {
                        MessageBox.Show($"Цепочка не принадлежит ДМПА. Не существует перехода из {(prev_rule == "" ? "Ничего" : prev_rule)} по символу {current_symbol} при верхнем символе стека {stack.Peek()}", "Ошибка", MessageBoxButton.OK);
                        //return;
                    }
                }
                catch { }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;

            RulesCount = textBox.Text;
        }
    }
}
