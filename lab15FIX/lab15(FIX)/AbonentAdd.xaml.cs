using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace lab15_FIX_
{
    /// <summary>
    /// Логика взаимодействия для AbonentAdd.xaml
    /// </summary>
    public partial class AbonentAdd : Window
    {
        public AbonentAdd()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Length == 0 || Number.Length == 0)
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
            else
            {
                this.DialogResult = true;
            }
        }

        public string Name
        {
            get
            {
                return NameBox.Text;
            }
            set { }
        }

        public string Number
        {
            get
            {
                return NumberBox.Text;
            }
            set { }
        }

        private void NumberBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            var prevSelectionPos = textBox.SelectionStart;

            if (textBox.Text.Length == 0)
            {
                return;
            }

            if (!Regex.IsMatch(textBox.Text, @"[0-9]+") || Regex.IsMatch(textBox.Text, "[a-zA-Z]+"))
            {
                textBox.Text = textBox.Text.Remove(textBox.SelectionStart - 1, 1);
                textBox.SelectionStart = prevSelectionPos - 1;
                return;
            }
        }
    }
}
