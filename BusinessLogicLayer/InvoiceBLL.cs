using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class InvoiceBLL
    {
        public static List<CustomerDTO> LoadCustomers()
        {

            DbCommand comm = GenericDataAccess.CreateCommand("LoadCustomers");
            DataTable dtableResults = GenericDataAccess.ExecuteSelectCommand(comm);
            List<CustomerDTO> lstCustomers = new List<CustomerDTO>();
            for (int i = 0; i < dtableResults.Rows.Count; i++)
            {
                lstCustomers.Add(new CustomerDTO
                {
                    Id = dtableResults.Rows[i]["Id"] != DBNull.Value ? (Convert.ToInt32(dtableResults.Rows[i]["Id"])) : 0,
                    CustomerName = dtableResults.Rows[i]["CustomerName"] != DBNull.Value ? dtableResults.Rows[i]["CustomerName"].ToString() : string.Empty,
                    CustomerAddress = dtableResults.Rows[i]["CustomerAddress"] != DBNull.Value ? dtableResults.Rows[i]["CustomerAddress"].ToString() : string.Empty              
                });
            }

            return lstCustomers;
        }

        public static InvoiceDTO LoadSingleInvoice(int id)
        {
            InvoiceDTO _thisinv = new InvoiceDTO();

            System.Data.SqlClient.SqlCommand comm = SQLDataAccess.CreateCommand("loadOneInvoice");
            comm.AddParameter("@Id", id, System.Data.SqlDbType.Int);

            DataSet dsetReturn = SQLDataAccess.ExecuteDataset(comm);
            List<InvoiceListDTO> lstinvoices = new List<InvoiceListDTO>();

            DataTable dtableResults = dsetReturn.Tables[0];
            for (int i = 0; i < dtableResults.Rows.Count; i++)
            {
                _thisinv = (new InvoiceDTO
                {
                    Id = dtableResults.Rows[i]["Id"] != DBNull.Value ? (Convert.ToInt32(dtableResults.Rows[i]["Id"])) : 0,
                    GrandTotal = Convert.ToDouble(dtableResults.Rows[i]["GrandTotal"]),
                    DiscValue = Convert.ToInt32(dtableResults.Rows[i]["Discount"]),
                    DiscPercentage = Convert.ToInt32(dtableResults.Rows[i]["DiscPercentage"]),
                    Total = Convert.ToInt32(dtableResults.Rows[i]["Total"]),
                    InvoiceDate = Convert.ToDateTime(dtableResults.Rows[i]["CreatedOn"].ToString()),
                    CustomerId = Convert.ToInt32(dtableResults.Rows[i]["CustomerId"].ToString()),
                    InvNo = Convert.ToInt32(dtableResults.Rows[i]["InvNo"])

                });
            }

            /*
             * CreatedOn
2024-09-01 23:43:08.427
             * */

            DataTable dtItems = dsetReturn.Tables[1];
            for (int i = 0; i < dtItems.Rows.Count; i++)
            {
                InvoiceItemDTO _item = (new InvoiceItemDTO
                {
                    Id = dtItems.Rows[i]["Id"] != DBNull.Value ? (Convert.ToInt32(dtItems.Rows[i]["Id"])) : 0,
                    ItemCode = dtItems.Rows[i]["Code"].ToString(),
                    ItemDescription = dtItems.Rows[i]["Desc"].ToString(),
                    Price = Convert.ToDouble(dtItems.Rows[i]["Price"].ToString()),
                    ItemPrice = Convert.ToDouble(dtItems.Rows[i]["Total"].ToString()),
                    Qty = Convert.ToInt32(dtItems.Rows[i]["Qty"].ToString()),
                    
                });

                _thisinv.items.Add(_item);
            }

            return _thisinv;
        }

        public static List<InvoiceListDTO> LoadAllInvoices()
        {//
            DbCommand comm = GenericDataAccess.CreateCommand("listInvoices");
            DataTable dtableResults = GenericDataAccess.ExecuteSelectCommand(comm);
            List<InvoiceListDTO> lstinvoices = new List<InvoiceListDTO>();
            for (int i = 0; i < dtableResults.Rows.Count; i++)
            {
                lstinvoices.Add(new InvoiceListDTO
                {
                    Id = dtableResults.Rows[i]["Id"] != DBNull.Value ? (Convert.ToInt32(dtableResults.Rows[i]["Id"])) : 0,
                    GrandTotal= Convert.ToDouble(dtableResults.Rows[i]["GrandTotal"]),
                    DiscValue = Convert.ToInt32(dtableResults.Rows[i]["Discount"]),
                    DiscPercentage = Convert.ToInt32(dtableResults.Rows[i]["DiscPercentage"]),
                    Total = Convert.ToInt32(dtableResults.Rows[i]["Total"]),
                    InvoiceDate = dtableResults.Rows[i]["InvoiceDate"].ToString(),
                    Customername = dtableResults.Rows[i]["CustomerName"].ToString() ,
                    InvNo = Convert.ToInt32(dtableResults.Rows[i]["InvNo"])

                });
            }

            return lstinvoices;
        }

        public static bool SaveInvoice(InvoiceDTO _invoice)
        {
            DataTable dtItems = BulkResources.CreateEmptyInvoiceItemsDataTable();
            for (int i = 0; i < _invoice.items.Count; i++)
            {
                DataRow drowResultItem = dtItems.NewRow();
                drowResultItem["Id"] = i + 1;
                drowResultItem["Code"] = _invoice.items[i].ItemCode;
                drowResultItem["Description"] = _invoice.items[i].ItemDescription;
                drowResultItem["Qty"] = _invoice.items[i].Qty;
                drowResultItem["Total"] = _invoice.items[i].Price*_invoice.items[i].Qty;
                drowResultItem["Price"] = _invoice.items[i].Price;

                dtItems.Rows.Add(drowResultItem);

            }
            try
            {

                System.Data.SqlClient.SqlCommand comm = SQLDataAccess.CreateCommand("CreateInvoice");
                comm.AddParameter("@items", dtItems, System.Data.SqlDbType.Structured);
                comm.AddParameter("@GrandTotal", _invoice.GrandTotal, System.Data.SqlDbType.Decimal);
                comm.AddParameter("@CustomerId", _invoice.CustomerId, System.Data.SqlDbType.Int);
                comm.AddParameter("@dPercentage", _invoice.DiscPercentage, System.Data.SqlDbType.Int);
                comm.AddParameter("@Discount", _invoice.DiscValue, System.Data.SqlDbType.Decimal);
                comm.AddParameter("@invNo", _invoice.InvNo, System.Data.SqlDbType.Int);
                comm.AddParameter("@Total", _invoice.Total, System.Data.SqlDbType.Decimal);

                DataSet dsetReturn = SQLDataAccess.ExecuteDataset(comm);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        


    }
}
