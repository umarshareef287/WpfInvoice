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
    /// Interaction logic for InvoiceWindow.xaml
    /// </summary>
    public partial class InvoiceWindow : Window
    {
        public List<CustomerDTO> lstCustomers = new List<CustomerDTO>();
        public CustomerDTO _Customer = null;
        public InvoiceDTO _newInvoice = new InvoiceDTO();
        public InvoiceWindow()
        {
            InitializeComponent();
            lblInvoiceDate.Content = _newInvoice.InvoiceDate.ToString("dd-MMM-yyyy");

            lstCustomers = BusinessLogicLayer.InvoiceBLL.LoadCustomers();
        }

        private void ButtonNewInvoice_Click(object sender, RoutedEventArgs e)
        {
            CustomerPopUp windowCustoemr = new CustomerPopUp();
            windowCustoemr.lstCustomers = lstCustomers;

            windowCustoemr.ShowDialog();

            _Customer = windowCustoemr.selectedCustomer;
            
            _newInvoice.CustomerId = _Customer.Id;

            RenderCustomerDetails();
        }

        private void RenderCustomerDetails()
        {
            CustomerDTO _thisCustomer = lstCustomers.Where(i => i.Id == _newInvoice.CustomerId).FirstOrDefault();
            if (_thisCustomer != null)
            {
                lblCustomerId.Content = _thisCustomer.Id.ToString();
                lblCustomerName.Content = _thisCustomer.CustomerName.ToString();
                lblCustomerAddress.Content = _thisCustomer.CustomerAddress.ToString();
            }
            else
            {
                lblCustomerId.Content = String.Empty;
                lblCustomerName.Content = String.Empty;
                lblCustomerAddress.Content = String.Empty;
            }
        }
        private void ButtonNewItem_Click(object sender, RoutedEventArgs e)
        {
            if (_newInvoice.CustomerId > 0)
            {


                InvoiceItem _NewItemForm = new InvoiceItem();
                _NewItemForm.ShowDialog();

                InvoiceItemDTO _newItem = new InvoiceItemDTO();
                _newItem = _NewItemForm._item;

                _newItem.Id = _newInvoice.items.Count + 1;
                _newInvoice.InvoiceDate = DateTime.Now;
                _newInvoice.items.Add(_newItem);

                RenderInvoiceCalc();
            }
            else
            {
                MessageBox.Show("Please select customer first by Pressing New Invoice button");
            }
        }

        private void RenderInvoiceCalc()
        {
            txtInvNo.Text = _newInvoice.InvNo.ToString();
            foreach (InvoiceItemDTO _loopingItem in _newInvoice.items)
            {
                _newInvoice.Total += _loopingItem.Price * _loopingItem.Qty;
            }

            _newInvoice.DiscPercentage = (txtDiscP.Text.Trim() != "" ? (Convert.ToInt32(txtDiscP.Text.Trim())) : 0);
            if (_newInvoice.DiscPercentage > 0)
            {
                _newInvoice.DiscValue = _newInvoice.Total * (_newInvoice.DiscPercentage / 100.00);
            }

            _newInvoice.GrandTotal = _newInvoice.Total - _newInvoice.DiscValue;


            InvoiceItemsGrid.ItemsSource = _newInvoice.items;
            InvoiceItemsGrid.Items.Refresh();

            lblTotal.Content = _newInvoice.Total.ToString("N2");
            lblDiscountValue.Content = _newInvoice.DiscValue.ToString("N2");
            lblGrandTotal.Content = _newInvoice.GrandTotal.ToString("N2");

        }

        private void TxtDiscP_TextChanged(object sender, TextChangedEventArgs e)
        {
            RenderInvoiceCalc();
        }

        private void ButtonSaveInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (_newInvoice.Id > 0)
            {
                MessageBox.Show("This invoice is already saved");
            }
            else
            {
                if (_newInvoice.CustomerId > 0)
                {
                    if(_newInvoice.items.Count>0)
                    {
                        bool status = BusinessLogicLayer.InvoiceBLL.SaveInvoice(_newInvoice);
                        if (status)
                        {
                            MessageBox.Show("invoice Saved Successfully!!");
                        }
                        else
                        {
                            MessageBox.Show("Counld not save the invoice");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please add atleast one item in invoice");
                    }
                }
                else
                {
                    MessageBox.Show("please select Customer by tapping New Invoice button and start preparing invoice");
                }
            }
        }

        private void ButtonClearInvoice_Click(object sender, RoutedEventArgs e)
        {
            clearScreen();
        }

        private void clearScreen()
        {
            _newInvoice = new InvoiceDTO();
            RenderCustomerDetails();
            RenderInvoiceCalc();
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _newInvoice.InvNo = txtInvNo.Text.Trim() != "" ? Convert.ToInt32(txtInvNo.Text.Trim()) : 0;
        }

        private void ButtonHistory_Click(object sender, RoutedEventArgs e)
        {
            InvoiceHistory _histoy = new InvoiceHistory();
            _histoy.ShowDialog();


            _newInvoice = _histoy._oldInvoice;
            RenderCustomerDetails();
            RenderInvoiceCalc();

        }
    }
}
