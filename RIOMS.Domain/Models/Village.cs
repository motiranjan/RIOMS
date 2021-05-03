namespace RIOMS.Domain.Models
{
    using System.Collections.Generic;

    public partial class Village
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Village()
        {
            Khatas = new HashSet<Khata>();
            Plots = new HashSet<Plot>();
            Receipts = new HashSet<Receipt>();
            TahReceipts = new HashSet<TahReceipt>();

            AdvanceCollectionLandRevenues = new HashSet<AdvanceCollectionLandRevenue>();
            AdvanceCollectionWaterTaxes = new HashSet<AdvanceCollectionWaterTax>();
            AdvanceCollectionCesses = new HashSet<AdvanceCollectionCess>();
            CollectionMovementCessesFrom = new HashSet<CollectionMovementCess>();
            CollectionMovementCessesTo = new HashSet<CollectionMovementCess>();
            CollectionMovementLandRevenuesFrom = new HashSet<CollectionMovementLandRevenue>();
            CollectionMovementLandRevenuesTo = new HashSet<CollectionMovementLandRevenue>();
            CollectionMovementWaterTaxesFrom = new HashSet<CollectionMovementWaterTax>();
            CollectionMovementWaterTaxesTo = new HashSet<CollectionMovementWaterTax>();
            DemandCesses = new HashSet<DemandCess>();
            DemandLandRevenues = new HashSet<DemandLandRevenue>();
            DemandWaterTaxes = new HashSet<DemandWaterTax>();

            VillageWiseDemandLandRevenues = new HashSet<VillageWiseDemandLandRevenue>();
            VillageWiseDemandCesses = new HashSet<VillageWiseDemandCess>();

            AdvanceAdjustmentWaterTaxes = new HashSet<AdvanceAdjustmentWaterTax>();
            AdvanceAdjustmentCesses = new HashSet<AdvanceAdjustmentCess>();
            AdvanceAdjustmentLandRevenues = new HashSet<AdvanceAdjustmentLandRevenue>();

            IFormDetailCesses = new HashSet<IFormDetailCess>();

            IFormDetailLandRevenues = new HashSet<IFormDetailLandRevenue>();
            IFormDetailWaterTaxes = new HashSet<IFormDetailWaterTax>();
            IFormDetailOLRs = new HashSet<IFormDetailOLR>();
            IFormDetailOPDRs = new HashSet<IFormDetailOPDR>();
            IFormDetailOthers = new HashSet<IFormDetailOther>();

            IncreaseInDemandCesses = new HashSet<VillageWiseIncreaseInDemandCess>();
            IncreaseInDemandLandrevenues = new HashSet<VillageWiseIncreaseInDemandLandrevenue>();

            TahCollectionLandRevenues = new HashSet<VillageWiseTahCollectionLandRevenue>();
            TahCollectionWaterTaxes = new HashSet<VillageWiseTahCollectionWaterTax>();
            TahCollectionCesses = new HashSet<VillageWiseTahCollectionCess>();

            CollectionMovementMiscRevenuesFrom = new HashSet<CollectionMovementMiscRevenue>();
            CollectionMovementMiscRevenuesTo = new HashSet<CollectionMovementMiscRevenue>();

            DemandMiscRevenues = new HashSet<DemandMiscRevenue>();
            TahCollectionMiscRevenues = new HashSet<VillageWiseTahCollectionMiscRevenue>();
        }

        public int Code { get; set; }

        public string Name { get; set; }

        public int RICircleId { get; set; }

        public int Id { get; set; }

        public int TahId { get; set; }

        public int? ThanaNo { get; set; }


        public virtual ICollection<Khata> Khatas { get; set; }


        public virtual ICollection<Plot> Plots { get; set; }


        public virtual ICollection<Receipt> Receipts { get; set; }

        public virtual RICircle RICircle { get; set; }

        public virtual Tahasil Tahasil { get; set; }
        public virtual ICollection<IFormDetailCess> IFormDetailCesses { get; set; }
        public virtual ICollection<IFormDetailLandRevenue> IFormDetailLandRevenues { get; set; }

        public virtual ICollection<IFormDetailWaterTax> IFormDetailWaterTaxes { get; set; }
        public virtual ICollection<IFormAbstractMiscRevenue> IFormAbstractMiscRevenues { get; set; }

        public virtual ICollection<IFormDetailOther> IFormDetailOthers { get; set; }
        public virtual ICollection<IFormDetailOPDR> IFormDetailOPDRs { get; set; }

        public virtual ICollection<IFormDetailOLR> IFormDetailOLRs { get; set; }


        public virtual ICollection<IFormDetailMiscRevenue> IFormDetailMiscRevenues { get; set; }
        public virtual ICollection<DemandCess> DemandCesses { get; internal set; }
        public virtual ICollection<DemandWaterTax> DemandWaterTaxes { get; internal set; }
        public virtual ICollection<DemandLandRevenue> DemandLandRevenues { get; internal set; }
        public virtual ICollection<VillageWiseDemandWaterTax> VillageWiseDemandWaterTaxes { get; internal set; }
        public virtual ICollection<VillageWiseDemandCess> VillageWiseDemandCesses { get; internal set; }
        public virtual ICollection<AdvanceAdjustmentWaterTax> AdvanceAdjustmentWaterTaxes { get; internal set; }
        public virtual ICollection<VillageWiseDemandLandRevenue> VillageWiseDemandLandRevenues { get; internal set; }
        public virtual ICollection<AdvanceAdjustmentLandRevenue> AdvanceAdjustmentLandRevenues { get; internal set; }
        public virtual ICollection<AdvanceCollectionCess> AdvanceCollectionCesses { get; internal set; }
        public virtual ICollection<AdvanceAdjustmentCess> AdvanceAdjustmentCesses { get; internal set; }
        public virtual ICollection<AdvanceCollectionWaterTax> AdvanceCollectionWaterTaxes { get; internal set; }
        public virtual ICollection<AdvanceCollectionLandRevenue> AdvanceCollectionLandRevenues { get; internal set; }
        public virtual ICollection<CollectionMovementCess> CollectionMovementCessesTo { get; internal set; }
        public virtual ICollection<CollectionMovementCess> CollectionMovementCessesFrom { get; internal set; }

        public virtual ICollection<CollectionMovementWaterTax> CollectionMovementWaterTaxesTo { get; internal set; }
        public virtual ICollection<CollectionMovementWaterTax> CollectionMovementWaterTaxesFrom { get; internal set; }

        public virtual ICollection<CollectionMovementLandRevenue> CollectionMovementLandRevenuesTo { get; internal set; }
        public virtual ICollection<CollectionMovementLandRevenue> CollectionMovementLandRevenuesFrom { get; internal set; }

        public virtual ICollection<VillageWiseTahCollectionCess> TahCollectionCesses { get; internal set; }
        public virtual ICollection<VillageWiseTahCollectionLandRevenue> TahCollectionLandRevenues { get; internal set; }
        public virtual ICollection<VillageWiseTahCollectionWaterTax> TahCollectionWaterTaxes { get; internal set; }

        public virtual ICollection<TahReceipt> TahReceipts { get; internal set; }
        public virtual ICollection<DemandMiscRevenue> DemandMiscRevenues { get; set; }
        public virtual ICollection<MiscRevenue> MiscRevenues { get; set; }
        public virtual ICollection<VillageWiseTahCollectionMiscRevenue> TahCollectionMiscRevenues { get; internal set; }
        public virtual ICollection<CollectionMovementMiscRevenue> CollectionMovementMiscRevenuesFrom { get; internal set; }
        public virtual ICollection<CollectionMovementMiscRevenue> CollectionMovementMiscRevenuesTo { get; internal set; }


        public virtual ICollection<VillageWiseIncreaseInDemandCess> IncreaseInDemandCesses { get; internal set; }
        public virtual ICollection<VillageWiseIncreaseInDemandLandrevenue> IncreaseInDemandLandrevenues { get; internal set; }
    }
}
