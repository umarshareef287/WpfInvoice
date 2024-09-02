using Models;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for CustomerPopUp.xaml
    /// </summary>
    public partial class CustomerPopUp : Window
    {
        public List<CustomerDTO> lstCustomers = new List<CustomerDTO>();
        public CustomerDTO selectedCustomer = new CustomerDTO();
        public CustomerPopUp()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            dataGridCustomers.ItemsSource = lstCustomers;
            dataGridCustomers.Items.Refresh();
        }

        private void DataGridCustomers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(dataGridCustomers.SelectedItem!=null)
            {
                var seleteditem = dataGridCustomers.SelectedItem as CustomerDTO;
                selectedCustomer.Id = seleteditem.Id;
                selectedCustomer.CustomerName = seleteditem.CustomerName;
                selectedCustomer.CustomerAddress= seleteditem.CustomerAddress;

                this.Close();
            }
        }
    }
}
