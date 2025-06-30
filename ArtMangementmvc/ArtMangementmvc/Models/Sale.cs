using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtMangementmvc.Models
{
	public class Sale
	{
        public Sale()
        {
            this.SaleDetailes = new HashSet<SaleDetaile>();
        }

        public int SaleId { get; set; }
        public string CustomerName { get; set; }
        public int InvoiceNo { get; set; }
        public System.DateTime InvoiceDate { get; set; }
        public bool IsPaid { get; set; }
        public string ImageUrl { get; set; }
        public int CustomerTypeId { get; set; }

        public virtual CustomerType CustomerType { get; set; }

        public virtual ICollection<SaleDetaile> SaleDetailes { get; set; }
    }
}