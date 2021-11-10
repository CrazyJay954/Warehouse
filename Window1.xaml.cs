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
using System.Data.SQLite;
using System.Data;

namespace Warehouse
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            DisplayData();
        }

        public void DisplayData()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=WH.db; Version=3"))
            {
                try
                {
                    connection.Open();
                    string query = $@"SELECT Department.ID_Depar, Department.WH_Num, Department.Rack_Num, Department.Shelf_Num, Department.Box_Num
                                        FROM Department ";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    DataTable DT = new DataTable("Department");
                    SQLiteDataAdapter SDA = new SQLiteDataAdapter(cmd);
                    SDA.Fill(DT);
                    DGAllEmp.ItemsSource = DT.DefaultView;

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        public void UpdateDB()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=WH.db;"))
            {
                try
                {
                    connection.Open();
                    string query = $@"SELECT Department.ID_Depar, Department.WH_Num, Department.Rack_Num, Department.Shelf_Num, Department.Box_Num
                                        FROM Department ";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    DataTable DT = new DataTable("Department");
                    SQLiteDataAdapter SDA = new SQLiteDataAdapter(cmd);
                    SDA.Fill(DT);
                    DGAllEmp.ItemsSource = DT.DefaultView;

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Add win8 = new Add();
            win8.Show();
            Close();
        }

        private void BtnUpd_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=WH.db;"))
            {
                try
                {

                    foreach (var item in DGAllEmp.SelectedItems.Cast<DataRowView>())
                    {
                        string query1 = $@"DELETE FROM Department WHERE ID = " + item["ID"];
                        connection.Open();

                        SQLiteCommand cmd1 = new SQLiteCommand(query1, connection);
                        DataTable DT = new DataTable("Department");
                        cmd1.ExecuteNonQuery();
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            UpdateDB();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win0 = new MainWindow();
            win0.Show();
            Close();
        }
    }
}
