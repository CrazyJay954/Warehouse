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
    /// Логика взаимодействия для Add3.xaml
    /// </summary>
    public partial class Add3 : Window
    {
        public Add3()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConn.myConn))
            {
                connection.Open();
                if (String.IsNullOrEmpty(TB_Name.Text) || String.IsNullOrEmpty(TB_Price.Text) || String.IsNullOrEmpty(TB_Type.Text) || String.IsNullOrEmpty(TB_Spec.Text))
                {
                    MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var Name = TB_Name.Text;
                    var Price = TB_Price.Text;
                    var Type = TB_Type.Text;
                    var Spec = TB_Spec.Text;

                    string query = $@"INSERT INTO Product(Name,Price,Type,Spec) values ('{Name}',{Price},'{Type}','{Spec}');";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Информация добавленна");
                        Window3 win3 = new Window3();
                        win3.Show();
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
            Window3 win3 = new Window3();
            win3.Show();
            Close();
        }
    }
}
