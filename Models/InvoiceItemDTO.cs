using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{

    public class InvoiceItemDTO
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public double ItemPrice { get; set; }
        public String ItemCode { get; set; }
        public String ItemName { get; set; }
        public String ItemDescription { get; set; }
        
    }

    public class InvoiceDTO
    {
        public int Id { get; set; }
        public int InvNo { get; set; }
        public int CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public double Total { get; set; } = 0;
        public double DiscPercentage { get; set; } = 0;
        public double DiscValue { get; set; } = 0;
        public double GrandTotal { get; set; } = 0;
        public String GrandTotalText { get; set; }
        public List<InvoiceItemDTO> items = new List<InvoiceItemDTO>();
    }

    public class InvoiceListDTO
    {
        public int Id { get; set; }
        public int InvNo { get; set; }
        public string Customername { get; set; }
        public string InvoiceDate { get; set; } 
        public double Total { get; set; } = 0;
        public double DiscPercentage { get; set; } = 0;
        public double DiscValue { get; set; } = 0;
        public double GrandTotal { get; set; } = 0;
    }
}
