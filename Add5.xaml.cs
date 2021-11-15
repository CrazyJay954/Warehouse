﻿using System;
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
    /// Логика взаимодействия для Add5.xaml
    /// </summary>
    public partial class Add5 : Window
    {
        public Add5()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConn.myConn))
            {
                connection.Open();
                if (String.IsNullOrEmpty(TB_FIO.Text) || String.IsNullOrEmpty(TB_Phone.Text) || String.IsNullOrEmpty(TB_Prod.Text))
                {
                    MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var FIO = TB_FIO.Text;
                    var Phone = TB_Phone.Text;
                    var Prod = TB_Prod.Text;

                    string query = $@"INSERT INTO Recipient(FIO,Phone,ID_Prod) values ('{FIO}',{Phone},'{Prod}');";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Информация добавленна");
                        Window5 win5 = new Window5();
                        win5.Show();
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
            Window5 win5 = new Window5();
            win5.Show();
            Close();
        }
    }
}
