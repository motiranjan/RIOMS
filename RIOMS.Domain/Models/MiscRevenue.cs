namespace RIOMS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MiscRevenue
    {
       
        public MiscRevenue()
        {
            DemandMiscRevenues = new HashSet<DemandMiscRevenue>();
            TahReceipts = new HashSet<TahReceipt>();
        }

     
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

       
        [Required]
        public string Father_HusbandName { get; set; }

        public int Year { get; set; }

        [Required]
        [StringLength(100)]
        public string CaseNo { get; set; }

        public decimal Amount { get; set; }

        [Required]
        [StringLength(50)]
        public string FYear { get; set; }

        public int VillageId { get; set; }

        public int TypeId { get; set; }

        public bool? IsPaid { get; set; }

      
        public virtual ICollection<DemandMiscRevenue> DemandMiscRevenues { get; set; }

        public virtual TypesOfMiscRev TypesOfMiscRev { get; set; }

     
        public virtual ICollection<TahReceipt> TahReceipts { get; set; }
        public virtual ICollection<Receipt> Receipts { get;  set; }

        public virtual ICollection<CollectionMiscRevenue> CollectionMiscRevenues { get; set; }
    }
}
