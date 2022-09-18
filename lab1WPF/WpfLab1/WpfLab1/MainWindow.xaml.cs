using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfLab1
{

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Dictionary<string, List<string>> _grammar = new Dictionary<string, List<string>>();


        private void PreviewTextImput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private string RawGrammar
        {
            get; set;
        } = "S: aA | bS | ->\r\nA: bS";

        private const string START_TERMINATE_SYMBOL = "S";
        private const string EMPTY_SYMBOL = "->";

        private int _sequenceLength = 2;

        private int SequenceLength
        {
            get => _sequenceLength;
            set
            {
                _sequenceLength = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(SequenceLength)));
            }
        }

        private string _output;

        public string Output
        {
            get => _output;
            set
            {
                _output = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void ResultButton(object sender, RoutedEventArgs e)
        {
            try
            {
                _grammar = ParseGrammar(RawGrammar);
                var sequences = GenerateSequences(_grammar, SequenceLength);

                var sequencesOut = new StringBuilder();
                foreach (var sequence in sequences)
                {
                    var line = Regex.Replace(sequence.Value, "[A-Z]", "");
                    if (line.EndsWith(EMPTY_SYMBOL) && line.Length == SequenceLength + 2)
                    {
                        sequencesOut.AppendLine(line.Replace(EMPTY_SYMBOL, "λ"));
                    }
                }

                Output = sequencesOut.ToString();
            }
            catch (GrammarException)
            {
                MessageBox.Show("Грамматика введена неверно, проверьте правильность ввода", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static Dictionary<string, List<string>> ParseGrammar(string rawGrammar)
        {
            var lines = rawGrammar.Replace(" ", "").Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            var newGrammar = new Dictionary<string, List<string>>();

            try
            {
                foreach (var line in lines)
                {
                    var tokens = line.Split(':');
                    var rule = tokens[0];
                    var variants = tokens[1].Split('|');

                    try
                    {
                        newGrammar.Add(rule, new List<string>());
                    }
                    catch { }
                    foreach (var variant in variants)
                    {
                        newGrammar[rule].Add(variant);
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw new GrammarException("Failed to parse");
            }

            return newGrammar;
        }

        public static Dictionary<int, string> GenerateSequences(Dictionary<string, List<string>> grammar, int sequenceLength)
        {
            var root = new TreeNode<string>(START_TERMINATE_SYMBOL);
            root.AddChildren(grammar[root.Value].ToArray());
            FillTree(root, grammar, sequenceLength);

            Dictionary<int, string> sequences = new Dictionary<int, string>();
            var prevSequence = "";
            var prevLevel = -1;
            var prevIndex = 0;
            var index = 0;
            root.Traverse(new Action<string, int>((nodeValue, level) =>
            {
                try
                {
                    sequences.Add(index, "");
                }
                catch { }

                if (level <= prevLevel)
                {
                    prevIndex = index;
                    index++;
                    prevSequence = sequences[prevIndex].Remove(sequences[prevIndex].Length - (prevLevel - level + 1) * 2);
                    try
                    {
                        sequences.Add(index, prevSequence);
                    }
                    catch { }
                }

                sequences[index] += nodeValue;

                prevLevel = level;
            }));

            return sequences;
        }

        public static void FillTree(TreeNode<string> root, Dictionary<string, List<string>> grammar, int sequenceLength, int count = 0)
        {
            if (count >= sequenceLength)
            {
                return;
            }

            foreach (var node in root.Children)
            {
                if (node.Value.Contains(EMPTY_SYMBOL))
                {
                    return;
                }
                node.AddChildren(grammar[Regex.Replace(node.Value, @"[0-9a-z]", "")].ToArray());
                FillTree(node, grammar, sequenceLength, count + 1);
            }
        }

        private void ManualInputTextChanged(object sender, TextChangedEventArgs e)
        {
            RawGrammar = ((TextBox)sender).Text;
        }

        private void SequenceLengthTextChanged(object sender, TextChangedEventArgs e)
        {
            var prevValue = SequenceLength;

            try
            {
                SequenceLength = int.Parse(((TextBox)sender).Text);
            }
            catch
            {
                SequenceLength = prevValue;
            }
        }

    }

    public class GrammarException : Exception
    {
        public GrammarException()
        {
        }

        public GrammarException(string message)
            : base(message)
        {
        }

        public GrammarException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class TreeNode<T>
    {
        private readonly T _value;
        private readonly List<TreeNode<T>> _children = new List<TreeNode<T>>();

        public TreeNode(T value)
        {
            _value = value;
        }

        public TreeNode<T> this[int i]
        {
            get
            {
                return _children[i];
            }
        }

        public TreeNode<T> Parent
        {
            get; private set;
        }

        public T Value => _value;

        public ReadOnlyCollection<TreeNode<T>> Children => _children.AsReadOnly();

        public TreeNode<T> AddChild(T value)
        {
            var node = new TreeNode<T>(value) { Parent = this };
            _children.Add(node);
            return node;
        }

        public TreeNode<T>[] AddChildren(params T[] values)
        {
            return values.Select(AddChild).ToArray();
        }

        public bool RemoveChild(TreeNode<T> node)
        {
            return _children.Remove(node);
        }

        public void Traverse(Action<T> action)
        {
            action(Value);
            foreach (var child in _children)
            {
                child.Traverse(action);
            }
        }

        public void Traverse(Action<T, int> action, int level = 0)
        {
            action(Value, level);
            foreach (var child in _children)
            {
                child.Traverse(action, level + 1);
            }
        }

        public IEnumerable<T> Flatten()
        {
            return new[] { Value }.Concat(_children.SelectMany(x => x.Flatten()));
        }
    }
}
