using Praktika1_DataSet.praktika1_datasetDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace Praktika1_DataSet
{
    public partial class Fourth : Page
    {
        INFOBARSTableAdapter INFOBARS = new INFOBARSTableAdapter();
        SUSHIBARSTableAdapter SUSHIBARS = new SUSHIBARSTableAdapter();
        SUSHISETSTableAdapter SUSHISETS = new SUSHISETSTableAdapter();
        CLIENTSTableAdapter CLIENTS = new CLIENTSTableAdapter();

        public Fourth()
        {
            InitializeComponent();
            SushiDataGrid.ItemsSource = INFOBARS.GetData();
            SUSHIBARSComboBox.DisplayMemberPath = "ID_SUSHIBARS";
            SUSHIBARSComboBox.ItemsSource = SUSHIBARS.GetData();
            SUSHISETSComboBox.DisplayMemberPath = "ID_SUSHISETS";
            SUSHISETSComboBox.ItemsSource = SUSHISETS.GetData();
            CLIENTSSComboBox.DisplayMemberPath = "ID_CLIENTS";
            CLIENTSSComboBox.ItemsSource = CLIENTS.GetData();

        }

        private void Dobavlenie_Click(object sender, RoutedEventArgs e)
        {

            int SUSHIBARS = int.Parse(idbar.Text);
            int SUSHISETS = int.Parse(idset.Text);
            int CLIENTS = int.Parse(idcl.Text);

            INFOBARS.InsertQuery(SUSHIBARS, SUSHISETS, CLIENTS);
            SushiDataGrid.ItemsSource = INFOBARS.GetData();
        }

        private void Udalenie_Click(object sender, RoutedEventArgs e)
        {
            object ID_INFOBARS = (SushiDataGrid.SelectedItem as DataRowView).Row[0];
            INFOBARS.DeleteQuery(Convert.ToInt32(ID_INFOBARS));
            SushiDataGrid.ItemsSource = INFOBARS.GetData();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            int SUSHIBARS = int.Parse(idbar.Text);
            int SUSHISETS = int.Parse(idset.Text);
            int CLIENTS = int.Parse(idcl.Text);

            object ID_INFOBARS = (SushiDataGrid.SelectedItem as DataRowView).Row[0];
            INFOBARS.UpdateQuery(SUSHIBARS, SUSHISETS, CLIENTS, Convert.ToInt32(ID_INFOBARS));
            SushiDataGrid.ItemsSource = INFOBARS.GetData();
        }

        private void SUSHIBARSComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object Fircell = (SUSHIBARSComboBox.SelectedItem as DataRowView).Row[1];
            MessageBox.Show(Fircell.ToString());
        }
        private void SUSHISETSComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object SECcell = (SUSHISETSComboBox.SelectedItem as DataRowView).Row[1];
            MessageBox.Show(SECcell.ToString());
        }
        private void CLIENTSSComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object TREcell = (CLIENTSSComboBox.SelectedItem as DataRowView).Row[3];
            MessageBox.Show(TREcell.ToString());
        }
        private void ShowMainButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }
    }
}
