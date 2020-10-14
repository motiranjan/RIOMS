namespace RIOMS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Remoting.Contexts;

    public partial class Village
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Village()
        {
            Khatas = new HashSet<Khata>();
            Plots = new HashSet<Plot>();
            Receipts = new HashSet<Receipt>();
            VillageWiseTahCollectionCesses = new HashSet<VillageWiseTahCollectionCess>();
            VillageWiseTahCollectionLandRevenues = new HashSet<VillageWiseTahCollectionLandRevenue>();
            VillageWiseTahCollectionWaterTaxes = new HashSet<VillageWiseTahCollectionWaterTax>();
            AdvanceCollectionLandRevenues = new HashSet<AdvanceCollectionLandRevenue>();
            AdvanceCollectionWaterTaxes = new HashSet<AdvanceCollectionWaterTax>();
            AdvanceCollectionCesses = new HashSet<AdvanceCollectionCess>();
            CollectionMovementCessesFrom = new HashSet<CollectionMovementCess>();
            CollectionMovementCessesTo = new HashSet<CollectionMovementCess>();
        }

        public int Code { get; set; }

        public string Name { get; set; }

        public int RICircleId { get; set; }

        public int Id { get; set; }

        public int TahId { get; set; }

        public int? ThanaNo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Khata> Khatas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Plot> Plots { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Receipt> Receipts { get; set; }

        public virtual RICircle RICircle { get; set; }

        public virtual Tahasil Tahasil { get; set; }
        public virtual ICollection<IFormDetailCess> IFormDetailCesses { get;  set; }
        public virtual ICollection<IFormDetailLandRevenue> IFormDetailLandRevenues { get;  set; }

        public virtual ICollection<IFormDetailWaterTax> IFormDetailWaterTaxes { get; set; }
        public virtual ICollection<IFormAbstractMiscRevenue> IFormAbstractMiscRevenues { get; set; }

        public virtual ICollection<IFormDetailOther> IFormDetailOthers { get; set; }
        public virtual ICollection<IFormDetailOPDR> IFormDetailOPDRs { get; set; }

        public virtual ICollection<IFormAbstractOLR> IFormDetailOLRs { get; set; }


        public virtual ICollection<IFormDetailMiscRevenue> IFormDetailMiscRevenues { get; set; }
        public virtual ICollection<DemandCess> DemandCesses { get; internal set; }
        public virtual ICollection<DemandWaterTax> DemandWaterTaxes { get; internal set; }
        public virtual ICollection<DemandLandRevenue> DemandLandRevenues { get; internal set; }
        public virtual ICollection<VillageWiseDemandWaterTax> VillageWiseDemandWaterTaxes { get; internal set; }
        public virtual ICollection<VillageWiseDemandCess> VillageWiseDemandCesses { get; internal set; }
        public virtual ICollection<AdvanceAdjustmentWaterTax> AdvanceAdjustmentWaterTaxes { get; internal set; }
        public virtual ICollection<VillageWiseDemandLandRevenue> VillageWiseDemandLandRevenues { get; internal set; }
        public virtual ICollection<AdvanceCollectionCess> AdvanceCollectionCesses { get; internal set; }
        public virtual ICollection<AdvanceAdjustmentCess> AdvanceAdjustmentCesses { get; internal set; }
        public virtual ICollection<AdvanceCollectionWaterTax> AdvanceCollectionWaterTaxes { get; internal set; }
        public virtual ICollection<AdvanceCollectionLandRevenue> AdvanceCollectionLandRevenues { get; internal set; }
        public virtual ICollection<CollectionMovementCess> CollectionMovementCessesTo { get; internal set; }
        public virtual ICollection<CollectionMovementCess> CollectionMovementCessesFrom { get; internal set; }
        public virtual ICollection<VillageWiseTahCollectionCess> VillageWiseTahCollectionCesses { get; internal set; }
        public virtual ICollection<VillageWiseTahCollectionLandRevenue> VillageWiseTahCollectionLandRevenues { get; internal set; }
        public virtual ICollection<VillageWiseTahCollectionWaterTax> VillageWiseTahCollectionWaterTaxes { get; internal set; }
        public virtual ICollection<DemandMiscRevenue> DemandMiscRevenues { get;  set; }
        public virtual ICollection<MiscRevenue> MiscRevenues { get;  set; }
        public virtual ICollection<VillageWiseTahCollectionMiscRevenue> VillageWiseTahCollectionMiscRevenues { get; internal set; }
        public virtual ICollection<CollectionMovementMiscRevenue> CollectionMovementMiscRevenuesFrom { get; internal set; }
        public virtual ICollection<CollectionMovementMiscRevenue> CollectionMovementMiscRevenuesTo { get; internal set; }
    }
}
