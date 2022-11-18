using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для AbonentFind.xaml
    /// </summary>
    public partial class AbonentFind : Window
    {
        public AbonentFind()
        {
            InitializeComponent();
        }

        public string Name
        {
            get
            {
                return NameBox.Text;
            }
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
