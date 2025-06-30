using ArtMangementmvc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtMangementmvc.ViewModels
{
	public class SaleViewModel
	{
        public int SaleId { get; set; }

        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Name Required")]
        [StringLength(30, ErrorMessage = "Name cannot exceed 30 characters")]
        public string CustomerName { get; set; }
        [Display(Name = "Invoice No")]
        [Required(ErrorMessage = "Invoice No Required")]

        public int InvoiceNo { get; set; }

        [Required, Display(Name = "Invoice Date"), DataType(DataType.Date),
            DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]

        public System.DateTime InvoiceDate { get; set; }
        [Display(Name = "IsPaid?")]
        public bool IsPaid { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        [Display(Name = "CustomerType")]
        [Required(ErrorMessage = "CustomerType Id Require")]
        public int CustomerTypeId { get; set; }
        public int SaleDetaileId { get; set; }
        public string ArtName { get; set; }
        public int Quantity { get; set; }
        public string CustomerTypeName { get; set; }
        [Display(Name = "Upload Picture")]
        public HttpPostedFileBase ProfileFile { get; set; }
        public virtual IList<CustomerType> CustomerTypes { get; set; }
       
        public virtual IList<SaleDetaile> SaleDetailes { get; set; } = new List<SaleDetaile>();
    }
}