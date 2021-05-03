namespace RIOMS.Domain.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class MiscRevenue
    {

        public MiscRevenue()
        {
            DemandMiscRevenues = new HashSet<DemandMiscRevenue>();
            TahReceipts = new HashSet<TahReceipt>();
            Receipts = new HashSet<Receipt>();
            //CollectionMiscRevenues = new HashSet<CollectionMiscRevenue>();

            //TahCollectionMiscRevenues = new HashSet<TahCollectionMiscRevenue>();
        }


        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        [Required]
        public string Father_HusbandName { get; set; }

        public int Year { get; set; }

        
        public int? CaseNo { get; set; }

        public decimal Amount { get; set; }

        [Required]
        [StringLength(50)]
        public string FYear { get; set; }

        public int VillageId { get; set; }

        public int TypeId { get; set; }

        public bool? IsPaid { get; set; }


        public virtual ICollection<DemandMiscRevenue> DemandMiscRevenues { get; set; }

        public virtual TypesOfMiscRev TypesOfMiscRev { get; set; }

        public virtual Village Village { get; set; }
        public virtual ICollection<TahReceipt> TahReceipts { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }

        //public virtual ICollection<CollectionMiscRevenue> CollectionMiscRevenues { get; set; }
        //public virtual ICollection<TahCollectionMiscRevenue> TahCollectionMiscRevenues { get; set; }
    }
}
