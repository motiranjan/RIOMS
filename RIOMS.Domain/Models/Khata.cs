namespace RIOMS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    public partial class Khata
    {

        public Khata()
        {
            Plots = new HashSet<Plot>();
            Receipts = new HashSet<Receipt>();
            TahReceipts = new HashSet<TahReceipt>();
            DemandCesses = new HashSet<DemandCess>();
            DemandLandRevenues = new HashSet<DemandLandRevenue>();
            DemandWaterTaxes = new HashSet<DemandWaterTax>();
        }

        public int Id { get; set; }


        public string KhataNo { get; set; }

        public int VillageId { get; set; }

        public string NameOfRT { get; set; }

        public decimal? Khajana { get; set; }

        public decimal? Cess { get; set; }

        public decimal? JalaKara { get; set; }

        [Column(TypeName = "date")]
        public DateTime UpdateOn { get; set; }

        public string Status { get; set; }

        public string SpecialCase { get; set; }

        public bool? HasPlots { get; set; }

        public string DetailOfRentIncrement { get; set; }

       
        public virtual Village Village { get; set; }


        public virtual ICollection<Plot> Plots { get; set; }

        public virtual ICollection<DemandCess> DemandCesses { get; set; }


        public virtual ICollection<DemandLandRevenue> DemandLandRevenues { get; set; }


        public virtual ICollection<DemandWaterTax> DemandWaterTaxes { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }
        public virtual ICollection<TahReceipt> TahReceipts { get; set; }
    }
}
