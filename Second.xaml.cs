using Praktika1_DataSet.praktika1_datasetDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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


namespace Praktika1_DataSet
{

    public partial class Second : Page
    {
        SUSHISETSTableAdapter SUSHISETS = new SUSHISETSTableAdapter();
        public Second()
        {
            InitializeComponent();
            SushiDataGrid.ItemsSource = SUSHISETS.GetData();
        }
        private void ShowMainButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }
        private void Dobavlenie_Click(object sender, RoutedEventArgs e)
        {
            string TITLESETS = NameTbx.Text;
            int PRICESETS = int.Parse(Prc.Text);
            int QUANTITY = int.Parse(Quant.Text);

            SUSHISETS.InsertQuery(TITLESETS, PRICESETS, QUANTITY);
            SushiDataGrid.ItemsSource = SUSHISETS.GetData();
        }

        private void Udalenie_Click(object sender, RoutedEventArgs e)
        {
            object ID_SUSHISETS = (SushiDataGrid.SelectedItem as DataRowView).Row[0];
            SUSHISETS.DeleteQuery(Convert.ToInt32(ID_SUSHISETS));
            SushiDataGrid.ItemsSource = SUSHISETS.GetData();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            string TITLESETS = NameTbx.Text;
            int PRICESETS = int.Parse(Prc.Text);
            int QUANTITY = int.Parse(Quant.Text);

            object ID_SUSHISETS = (SushiDataGrid.SelectedItem as DataRowView).Row[0];
            SUSHISETS.UpdateQuery(TITLESETS, PRICESETS, QUANTITY, Convert.ToInt32(ID_SUSHISETS));
            SushiDataGrid.ItemsSource = SUSHISETS.GetData();
        }
    }
}
 