using AAS2237A2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AAS2237A2.Models
{
    public class InvoiceLineBaseViewModel
    {
        [Display(Name = "Line Id")]
        public int InvoiceLineId { get; set; }

        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public Invoice Invoice { get; set; }

        public Track Track { get; set; }

        [Display(Name = "Line Total")]
        public decimal LinePrice
        {
            get
            {
                return Quantity * UnitPrice;
            }
        }
    }

    public class InvoiceLineWithDetailViewModel : InvoiceLineBaseViewModel
    {
        [Display(Name = "Name")]
        public string TrackName { get; set; }

        [Display(Name = "Composer(s)")]
        public string TrackComposer { get; set; }

        [Display(Name = "Album")]
        public string TrackAlbumTitle { get; set; }

        [Display(Name = "Artist")]
        public string TrackAlbumArtistName { get; set; }

        [Display(Name = "Genre")]
        public string TrackGenreName { get; set; }

        [Display(Name = "Media Type")]
        public string TrackMediaTypeName { get; set; }

    }

}