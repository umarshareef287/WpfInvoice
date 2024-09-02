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
    /// Interaction logic for InvoiceHistory.xaml
    /// </summary>
    public partial class InvoiceHistory : Window
    {
        public InvoiceDTO _oldInvoice = new InvoiceDTO();
        public InvoiceHistory()
        {
            InitializeComponent();
            List<InvoiceListDTO> lstInvoices = BusinessLogicLayer.InvoiceBLL.LoadAllInvoices();
            gridInvoices.ItemsSource = lstInvoices;
            gridInvoices.Items.Refresh();
        }

        private void GridInvoices_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (gridInvoices.SelectedItem != null)
            {
                var seleteditem = gridInvoices.SelectedItem as InvoiceListDTO;

                 _oldInvoice = BusinessLogicLayer.InvoiceBLL.LoadSingleInvoice(seleteditem.Id);
                

                this.Close();
            }
        }
    }
}
