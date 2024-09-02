using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BulkResources
    {
        public static DataTable CreateEmptyDataTable()
        {
            DataTable dtableEmpData = new DataTable();
            dtableEmpData.Columns.Add(new DataColumn("Id", typeof(int)));
            dtableEmpData.Columns.Add(new DataColumn("WebTitle", typeof(string))); 
            dtableEmpData.Columns.Add(new DataColumn("WebAddress", typeof(string))); 
            dtableEmpData.Columns.Add(new DataColumn("SearchDescription", typeof(string))); 
            
            dtableEmpData.PrimaryKey = new DataColumn[] { dtableEmpData.Columns["Id"] };
            return dtableEmpData;
        }

        public static DataTable CreateEmptyInvoiceItemsDataTable()
        {
            DataTable dtInvoiceItems = new DataTable();
            dtInvoiceItems.Columns.Add(new DataColumn("Id", typeof(int)));
            dtInvoiceItems.Columns.Add(new DataColumn("Code", typeof(string)));
            dtInvoiceItems.Columns.Add(new DataColumn("Description", typeof(string)));
            dtInvoiceItems.Columns.Add(new DataColumn("Price", typeof(double)));
            dtInvoiceItems.Columns.Add(new DataColumn("Qty", typeof(int)));
            dtInvoiceItems.Columns.Add(new DataColumn("Total", typeof(double)));

            dtInvoiceItems.PrimaryKey = new DataColumn[] { dtInvoiceItems.Columns["Id"] };

            return dtInvoiceItems;

        }
    }
    
}
