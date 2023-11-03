using AAS2237A2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AAS2237A2.Models
{
    public class TrackBaseViewModel
    {
        public TrackBaseViewModel() { }

        [Key]
        public int TrackId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Track Name")]
        public string Name { get; set; }

        [Display(Name = "Composer Name(s)")]
        [StringLength(220)]
        public string Composer { get; set; }

        [Display(Name = "Length(ms)")]
        public int Milliseconds { get; set; }

        [Display(Name = "Size(bytes)")]
        public int? Bytes { get; set; }

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]

        public decimal UnitPrice { get; set; }

        public Album Album { get; set; }

        public Genre Genre { get; set; }

        public MediaType MediaType { get; set; }
    }

    public class TrackWithDetailViewModel : TrackBaseViewModel
    {
      
    }
}