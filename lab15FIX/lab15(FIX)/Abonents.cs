using lab15_FIX_;
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
    public class Abonents
    {
        public ObservableCollection<Abonent> Abonent = new();

        public void AbonentAdd()
        {
            using (var connection = new SqliteConnection("Data source=phonebook.db"))
            {
                connection.Open();
                AbonentAdd abonentAdd = new AbonentAdd();

                if (abonentAdd.ShowDialog() == true)
                {

                    string Name = abonentAdd.Name;
                    string Number = abonentAdd.Number;

                    for (var i = 0; i < Abonent.Count(); i++)
                    {
                        if (Abonent[i].Name == Name)
                        {
                            MessageBox.Show("Контакт с данным именем уже добавлен в телефонную книгу");
                            return;
                        }
                    }

                    SqliteCommand AddingCommand = new SqliteCommand($"INSERT INTO Phones (Name, Phone) VALUES ('{Name}', '{Number}')", connection);
                    AddingCommand.ExecuteNonQuery();
                }
            }
        }

        public void AbonentDel()
        {
            using (var connection = new SqliteConnection("Data source=phonebook.db"))
            {
                connection.Open();
                AbonentDelete abonentDelete = new();

                if (abonentDelete.ShowDialog() == true)
                {

                    var Name = abonentDelete.Name;

                    SqliteCommand DeletingCommand = new SqliteCommand($"DELETE FROM Phones WHERE Name = '{Name}'", connection);
                    DeletingCommand.ExecuteNonQuery();
                }
            }
        }

        public void AbonentFind()
        {
            AbonentFind abonentFind = new();

            if (abonentFind.ShowDialog() == true)
            {

                var Name = abonentFind.Name;

                for (var i = 0; i < Abonent.Count(); i++)
                {
                    if (Abonent[i].Name == Name)
                    {
                        MessageBox.Show($"Абонент был найден!\n ИМЯ: {Abonent[i].Name}\n НОМЕР: {Abonent[i].Number}");
                        return;
                    }
                }
                MessageBox.Show($"Абонент с данным именем не был найден");
            }
        }

        public void AbonentClean()
        {
            using (var connection = new SqliteConnection("Data source=phonebook.db"))
            {
                connection.Open();

                if (MessageBox.Show("Данное действие полностью удалит все записи, без возможности восстановления!",
                    "Внимание!",
                    MessageBoxButton.OKCancel,
                    MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    SqliteCommand ClearCommand = new SqliteCommand("DELETE FROM Phones", connection);
                    ClearCommand.ExecuteNonQuery();
                }
            }

        }
    }
}
