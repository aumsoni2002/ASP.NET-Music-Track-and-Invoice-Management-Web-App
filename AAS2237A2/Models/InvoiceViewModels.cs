using AAS2237A2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AAS2237A2.Models
{
    public class InvoiceBaseViewModel
    {
        public InvoiceBaseViewModel() { }

        [Key]
        public int InvoiceId { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MMM d, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime InvoiceDate { get; set; }

        [Display(Name = "Billing Address")]
        [StringLength(70)]
        public string BillingAddress { get; set; }

        [Display(Name = "City")]
        [StringLength(40)]
        public string BillingCity { get; set; }

        [Display(Name = "State")]
        [StringLength(40)]
        public string BillingState { get; set; }

        [Display(Name = "Country")]
        [StringLength(40)]
        public string BillingCountry { get; set; }

        [Display(Name = "Postal/Zip")]
        [StringLength(10)]
        public string BillingPostalCode { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Total { get; set; }

        public Customer Customer { get; set; }
    }

    public class InvoiceWithDetailViewModel : InvoiceBaseViewModel
    {
        public InvoiceWithDetailViewModel() 
        {
            InvoiceLines = new List<InvoiceLineWithDetailViewModel>();
        }

        public IEnumerable<InvoiceLineWithDetailViewModel> InvoiceLines { get; set; }

        [Display(Name = "Customer First Name")]
        public string CustomerFirstName { get; set; }

        [Display(Name = "Customer Last Name")]
        public string CustomerLastName { get; set; }

        [Display(Name = "State")]
        public string CustomerState { get; set; }

        [Display(Name = "Country")]
        public string CustomerCountry { get; set; }

        [Display(Name = "Employee First Name")]
        public string CustomerEmployeeFirstName { get; set; }

        [Display(Name = "Employee Last Name")]
        public string CustomerEmployeeLastName { get; set; }
    }
}