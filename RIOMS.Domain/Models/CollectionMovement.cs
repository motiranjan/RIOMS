namespace RIOMS.Domain.Models
{
    public partial class CollectionMovementCess : PartOneRev
    {

        public long Id { get; set; }


        public int FromVillageId { get; set; }


        public int ToVillageId { get; set; }


        public string Year { get; set; }


       //public decimal InterestTotal { get; set; }
        public virtual Village ToVillage { get; set; }
        public virtual Village FromVillage { get; set; }
    }
    public partial class CollectionMovementWaterTax : CollectionPartOneRev
    {

        public long Id { get; set; }


        public int FromVillageId { get; set; }


        public int ToVillageId { get; set; }


        public string Year { get; set; }


       // public decimal? IntrestTotal { get; set; }
        public virtual Village ToVillage { get; set; }
        public virtual Village FromVillage { get; set; }
    }
    public partial class CollectionMovementLandRevenue : CollectionPartOneRev
    {

        public long Id { get; set; }


        public int FromVillageId { get; set; }


        public int ToVillageId { get; set; }


        public string Year { get; set; }


        //public decimal? IntrestTotal { get; set; }
        public virtual Village ToVillage { get; set; }
        public virtual Village FromVillage { get; set; }
    }
}
