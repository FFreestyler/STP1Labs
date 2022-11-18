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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Data.Sqlite;
using System.Collections.ObjectModel;

namespace lab15_FIX_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Abonent> Abonent = new();
        //MainWindow mainWindow = new MainWindow();
        Abonents abonents = new();

        public MainWindow()
        {
            InitializeComponent();
            SQLConnection();
        }

        public void SQLConnection()
        {
            using (var connection = new SqliteConnection("Data source=phonebook.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "CREATE TABLE IF NOT EXISTS Phones(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Name TEXT NOT NULL, Phone TEXT NOT NULL)";
                command.ExecuteNonQuery();

                SqliteCommand RefreshComand = new SqliteCommand("SELECT * FROM Phones ORDER BY Name", connection);
                using (SqliteDataReader reader = RefreshComand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        int i = 1;
                        while (reader.Read())
                        {
                            var id = i;
                            var name = reader.GetString(1);
                            var phone = reader.GetString(2);

                            Abonent.Add(new Abonent() { ID = id.ToString(), Name = name, Number = phone }); ;
                            i++;
                        }
                    }
                    else
                    {
                        Book.ItemsSource = null;
                        Book.Items.Refresh();
                    }

                    Book.ItemsSource = Abonent;
                }
            }
        }

        public void RefreshTable()
        {
            Abonent.Clear();
            using (var connection = new SqliteConnection("Data source=phonebook.db"))
            {
                connection.Open();
                SqliteCommand RefreshComand = new SqliteCommand("SELECT * FROM Phones ORDER BY Name", connection);
                using (SqliteDataReader reader = RefreshComand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        int i = 1;
                        while (reader.Read())
                        {
                            var id = i;
                            var name = reader.GetString(1);
                            var phone = reader.GetString(2);

                            Abonent.Add(new Abonent() { ID = id.ToString(), Name = name, Number = phone }); ;
                            i++;
                        }
                    }
                    else
                    {
                        Book.ItemsSource = null;
                        Book.Items.Refresh();
                    }

                    Book.ItemsSource = Abonent;
                }
            }
        }

        public void AbonentAdd_Click(object sender, RoutedEventArgs e)
        {
            abonents.AbonentAdd();
            RefreshTable();
        }

        public void AbonentDelete_Click(object sender, RoutedEventArgs e)
        {
            abonents.AbonentDel();
            RefreshTable();
        }

        public void AbonentFind_Click(object sender, RoutedEventArgs e)
        {
            abonents.AbonentFind();
        }

        public void ClearPhoneBook_Click(object sender, RoutedEventArgs e)
        {
            abonents.AbonentClean();
            RefreshTable();
        }
    }
}
