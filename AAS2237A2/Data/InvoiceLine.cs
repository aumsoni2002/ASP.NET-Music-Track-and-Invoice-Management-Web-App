using System.ComponentModel.DataAnnotations.Schema;

namespace AAS2237A2.Data
{
    [Table("InvoiceLine")]
    public class InvoiceLine
    {

        #region Columns

        public int InvoiceLineId { get; set; }

        public int InvoiceId { get; set; }

        public int TrackId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        #endregion

        #region Navigation Properties

        public Invoice Invoice { get; set; }

        public Track Track { get; set; }

        #endregion

    }
}
