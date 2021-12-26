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
using System.Data;
using System.IO;
using System.Drawing;
using System.Net.Mail;
using System.Net;

namespace Warehouse
{
    /// <summary>
    /// Логика взаимодействия для Aunt.xaml
    /// </summary>
    public partial class Aunt : Window
    {
        public Aunt()
        {
            InitializeComponent();

        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnLog_Click(object sender, RoutedEventArgs e)
        {
            if (TbLogin.Text == "ad" && TbPass.Password == "666")
            {
                MainWindow win7 = new MainWindow();
                win7.Show();
                Close();
            }
            else if (TbLogin.Text == "TitZP" && TbPass.Password == "12345")
            {
                MainWindow win7 = new MainWindow();
                win7.Show();
                Close();
            }
            else if (TbLogin.Text == "SinMA" && TbPass.Password == "23456")
            {
                MainWindow win7 = new MainWindow();
                win7.Show();
                Close();
            }
            else if (TbLogin.Text == "BelLD" && TbPass.Password == "34567")
            {
                MainWindow win7 = new MainWindow();
                win7.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
        }
    }
}
