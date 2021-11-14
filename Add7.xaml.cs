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
using System.Data.SQLite;
using Warehouse.Connection;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO;
using Microsoft.Win32;

namespace Warehouse
{
    /// <summary>
    /// Логика взаимодействия для Add7.xaml
    /// </summary>
    public partial class Add7 : Window
    {
        public Add7()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConn.myConn))
            {
                connection.Open();
                if (String.IsNullOrEmpty(TB_FIO.Text) || String.IsNullOrEmpty(TB_Phone.Text) || String.IsNullOrEmpty(TB_Rights.Text))
                {
                    MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var FIO = TB_FIO.Text;
                    var Phone = TB_Phone.Text;
                    var Rights = TB_Rights.Text;

                    string query = $@"INSERT INTO Manager(FIO,Phone,Rights) values ('{FIO}',{Phone},'{Rights}');";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Информация добавленна");
                        Window1 win1 = new Window1();
                        win1.Show();
                        Close();
                    }

                    catch (SQLiteException)
                    {

                    }
                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Window7 win7 = new Window7();
            win7.Show();
            Close();
        }
    }
}
