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
    /// Interaction logic for InvoiceItem.xaml
    /// </summary>
    public partial class InvoiceItem : Window
    {
        public InvoiceItemDTO _item = new InvoiceItemDTO();
        public InvoiceItem()
        {
            InitializeComponent();
        }

        private void ButtonAddItem_Click(object sender, RoutedEventArgs e)
        {
            
            _item.ItemCode = txtItemCode.Text.Trim();
            _item.ItemDescription = txtItemDescription.Text.Trim();
            _item.Price = Convert.ToDouble(txtItemPrice.Text.Trim());
            _item.Qty = Convert.ToInt32(txtItemQuantity.Text.Trim());
            _item.ItemPrice = _item.Price * _item.Qty;

            this.Close();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
    }
}
