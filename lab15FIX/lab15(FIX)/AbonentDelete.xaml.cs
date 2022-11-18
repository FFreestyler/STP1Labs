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
    /// Логика взаимодействия для AbonentDelete.xaml
    /// </summary>
    public partial class AbonentDelete : Window
    {
        public AbonentDelete()
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

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Length == 0)
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
            else
            {
                if (MessageBox.Show("Это действие навсегда удалит данного абонента из телефонной книги!",
                    "Внимание",
                    MessageBoxButton.OKCancel,
                    MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    this.DialogResult = true;
                }
            }
        }
    }
}
