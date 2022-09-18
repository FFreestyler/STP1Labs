using System;
using System.Collections.Generic;
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

namespace TYAP1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
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

        private int _sequenceLength = 3;

        private int SequenceLength
        {
            get => _sequenceLength;
            set
            {
                _sequenceLength = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(SequenceLength)));
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public List<string> chains_list;
        private Dictionary<string, string[]> rules_dictionary;

        public uint max_chain_length = 0;
        public uint min_chain_length = 0;

        public string term = "";
        public string non_term = "";
        public string start_non_term = "S";

        public const string EMPTY_STR = "λ";
        private const int MAX_RECURSION = 10000;

        public bool is_first_launch = false;
        public bool is_changed_start = false;
        public string old_text_box;
        public string res;
        public string Grammar;
        public char is_start;
        private Dictionary<string, string> non_term_dictionary;
        public void Init()
        {
            chains_list = new List<string>();
            rules_dictionary = new Dictionary<string, string[]>();
        }
        public void AddRuleDescription(string key, string description)
        {
            rules_dictionary[key] = description.Split('|');
        }
        public void RemoveAllRules()
        {
            chains_list.Clear();
            rules_dictionary.Clear();
        }
        public void GenerateChains()
        {
            string res;
            int recursion = 0;
            string chain_prefix;
            List<string> non_term_chains = new List<string>();

            foreach (string rule_right_part in rules_dictionary[start_non_term])
            {
                if (0 == Is_valid(rule_right_part) && rule_right_part.Length >= min_chain_length)
                {
                    chains_list.Add(rule_right_part == "" ? EMPTY_STR : rule_right_part);
                }
                else if (-2 == Is_valid(rule_right_part))
                {
                    non_term_chains.Add(rule_right_part);
                }
            }

            while (recursion < MAX_RECURSION && chains_list.Count < 50000)
            {
                recursion++;
                List<string> sub_non_term_chains = new List<string>();
                foreach (string non_term_chain in non_term_chains)
                {
                    chain_prefix = "";
                    for (int i = 0; i < non_term_chain.Length; i++)
                    {
                        if (!rules_dictionary.ContainsKey(non_term_chain[i].ToString()))
                        {
                            chain_prefix += non_term_chain[i];
                        }
                        else
                        {
                            foreach (string rule_right_part in rules_dictionary[non_term_chain[i].ToString()])
                            {
                                res = chain_prefix + rule_right_part + non_term_chain.Substring(i + 1);

                                if (0 == Is_valid(res))
                                {
                                    if (chains_list.Contains(res == "" ? EMPTY_STR : res) || res.Length < min_chain_length)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        chains_list.Add(res == "" ? EMPTY_STR : res);
                                    }
                                }
                                else if (-2 == Is_valid(res))
                                {
                                    sub_non_term_chains.Add(res);
                                }
                            }
                            break;
                        }
                    }
                }
                non_term_chains.Clear();
                non_term_chains = sub_non_term_chains.Distinct().ToList();
            }
            //foreach(ValidateValueCallback )
            MessageBox.Show(chains_list.Count.ToString());
        }
        private int Is_valid(string line)
        {
            int term_sym = 0;
            int non_term_sym = 0;
            foreach (char ch in line)
            {
                if (!rules_dictionary.ContainsKey(ch.ToString()))
                {
                    term_sym++;
                }
                else
                {
                    non_term_sym++;
                }
            }

            if (term_sym > max_chain_length)
            {
                return -1;
            }
            if ((term_sym + non_term_sym - 5) > max_chain_length)
            {
                return -1;
            }
            return (non_term_sym > 0) ? -2 : 0;
        }

        private void ShowChains()
        {
            var sequencesOut = new StringBuilder();

            foreach (var key in chains_list)
            {
                //var line = Regex.Replace(sequence, "[A-Z]", "");
                sequencesOut.AppendLine(key);
            }

            Output = sequencesOut.ToString();
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

        private void ResultButton(object sender, RoutedEventArgs e)
        {
            string key;
            bool is_term;
            bool is_correct = true;
            string fail_message = "";

            non_term_dictionary = new Dictionary<string, string>();
            Init();
            RemoveAllRules();

            Grammar = RawGrammar;
            var lines = RawGrammar.Replace(" ", "").Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            foreach(var line in lines)
            {
                var grammar = line.Split(':');
                non_term_dictionary[grammar[0]] = grammar[1];
            }

            term = TextBox1.ToString();
            //non_term = TextBox2.ToString();
            start_non_term = "S";
            max_chain_length = (uint)SequenceLength;
            min_chain_length = (uint)SequenceLength;

            for (int i = 0; i < non_term_dictionary.Keys.Count; i++)
            {
                key = non_term_dictionary.Keys.ElementAt(i);
                string value = non_term_dictionary[key];
                for (int er = 0; er < value.Length; er++)
                {
                    is_term = false;
                    for (int k = 0; k < term.Length; k++)
                    {
                        if (value[er] == term[k])
                        {
                            is_term = true;
                        }
                    }
                    if (is_term == false)
                    {
                        if ((value[er] != 'A' && value[er] != 'B'
                            && value[er] != 'C' && value[er] != 'D' && value[er] != 'E' && value[er] != 'F' && value[er] != 'G'
                            && value[er] != 'H' && value[er] != 'I' && value[er] != 'J' && value[er] != 'K' && value[er] != 'L'
                            && value[er] != 'M' && value[er] != 'N' && value[er] != 'O' && value[er] != 'P' && value[er] != 'Q'
                            && value[er] != 'R' && value[er] != 'S' && value[er] != 'T' && value[er] != 'U' && value[er] != 'V'
                            && value[er] != 'W' && value[er] != 'X' && value[er] != 'Y' && value[er] != 'Z' && value[er] != '|'))
                        {
                            is_correct = false;
                            fail_message = "ОШИБКА!\nТЕРМИНАЛЬНОГО СИМВОЛА " + value[er] + " НЕТ В АЛФАВИТЕ";
                            break;
                        }
                    }
                }
                for (int j = 0; j < value.Length; j++)
                {
                    if (!non_term_dictionary.ContainsKey(value[j].ToString()) && (value[j] == 'A' || value[j] == 'B'
                        || value[j] == 'C' || value[j] == 'D' || value[j] == 'E' || value[j] == 'F' || value[j] == 'G'
                        || value[j] == 'H' || value[j] == 'I' || value[j] == 'J' || value[j] == 'K' || value[j] == 'L'
                        || value[j] == 'M' || value[j] == 'N' || value[j] == 'O' || value[j] == 'P' || value[j] == 'Q'
                        || value[j] == 'R' || value[j] == 'S' || value[j] == 'T' || value[j] == 'U' || value[j] == 'V'
                        || value[j] == 'W' || value[j] == 'X' || value[j] == 'Y' || value[j] == 'Z'))
                    {
                        is_correct = false;
                        fail_message = "ОШИБКА!\nНЕТЕРМИНАЛЬНОГО СИМВОЛА " + value[j] + " НЕТ В СПИСКЕ НЕТЕРМИНАЛОВ";
                        break;
                    }
                }
                if (non_term_dictionary[key] != null)
                {
                    var val = non_term_dictionary[key];
                    AddRuleDescription(key, val);
                }
                else
                {
                    AddRuleDescription(key, "");
                }
            }

            if (is_correct == true)
            {
                GenerateChains();
                ShowChains();
            }
            else
            {
                MessageBox.Show(fail_message);
            }
        }

        private string RawGrammar
        {
            get;set;
        }

        private void ManualInputTextChanged(object sender, TextChangedEventArgs e)
        {
            RawGrammar = ((TextBox)sender).Text;
        }

        private void PreviewTextImput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private string TextBox1
        {
            get;set;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox1 = ((TextBox)sender).Text;
        }

        private string TextBox2
        {
            get; set;
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            TextBox2 = ((TextBox)sender).Text;
        }
    }
}
