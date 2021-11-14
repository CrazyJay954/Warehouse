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
    /// Логика взаимодействия для Add2.xaml
    /// </summary>
    public partial class Add2 : Window
    {
        public Add2()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConn.myConn))
            {
                connection.Open();
                if (String.IsNullOrEmpty(TB_Dep.Text) || String.IsNullOrEmpty(TB_Name.Text) || String.IsNullOrEmpty(TB_Prod.Text))
                {
                    MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var Dep = TB_Dep.Text;
                    var Name = TB_Name.Text;
                    var Prod = TB_Prod.Text;

                    string query = $@"INSERT INTO Warehouse(ID_Depar,Name,ID_Prod) values ('{Dep}',{Name},'{Prod}');";
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
            Window2 win2 = new Window2();
            win2.Show();
            Close();
        }
    }
}
