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

namespace Warehouse
{
    /// <summary>
    /// Логика взаимодействия для Help2.xaml
    /// </summary>
    public partial class Help2 : Window
    {
        public Help2()
        {
            InitializeComponent();
        }

        private void bb_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win0 = new MainWindow();
            win0.Show();
            Close();
        }

        private void bn_Click(object sender, RoutedEventArgs e)
        {
            Help win1 = new Help();
            win1.Show();
            Close();
        }
    }
}
