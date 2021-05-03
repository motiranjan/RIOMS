namespace RIOMS.Domain.Models
{
    using RIOMS.Domain.Map;
    using System.Data.Entity;

    public partial class RIOMSContext : DbContext
    {
        public RIOMSContext()
            : base("name=RIOMSContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<CollectionCess> CollectionCesses { get; set; }
        public virtual DbSet<CollectionLandRevenue> CollectionLandRevenues { get; set; }
        public virtual DbSet<CollectionMiscRevenue> CollectionMiscRevenues { get; set; }
        public virtual DbSet<CollectionOLR> CollectionOLRs { get; set; }
        public virtual DbSet<CollectionOPDR> CollectionOPDRs { get; set; }
        public virtual DbSet<CollectionOther> CollectionOthers { get; set; }
        public virtual DbSet<CollectionWaterTax> CollectionWaterTaxes { get; set; }
        public virtual DbSet<DemandCess> DemandCesses { get; set; }
        public virtual DbSet<DemandLandRevenue> DemandLandRevenues { get; set; }
        public virtual DbSet<DemandMiscRevenue> DemandMiscRevenues { get; set; }
        public virtual DbSet<DemandWaterTax> DemandWaterTaxes { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<IForm> IForms { get; set; }
        public virtual DbSet<Khata> Khatas { get; set; }
        public virtual DbSet<MiscRevenue> MiscRevenues { get; set; }
        public virtual DbSet<OLRCas> OLRCases { get; set; }
        public virtual DbSet<Plot> Plots { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<RICircle> RICircles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tahasil> Tahasils { get; set; }
        public virtual DbSet<TahCollectionCess> TahCollectionCesses { get; set; }
        public virtual DbSet<TahCollectionLandRevenue> TahCollectionLandRevenues { get; set; }
        public virtual DbSet<TahCollectionMiscRevenue> TahCollectionMiscRevenues { get; set; }
        public virtual DbSet<TahCollectionWaterTax> TahCollectionWaterTaxes { get; set; }
        public virtual DbSet<TahReceipt> TahReceipts { get; set; }
        public virtual DbSet<TypesOfMiscRev> TypesOfMiscRevs { get; set; }
        public virtual DbSet<Village> Villages { get; set; }
        public virtual DbSet<VillageWiseDemandCess> VillageWiseDemandCesses { get; set; }
        public virtual DbSet<VillageWiseDemandLandRevenue> VillageWiseDemandLandRevenues { get; set; }
        public virtual DbSet<VillageWiseDemandWaterTax> VillageWiseDemandWaterTaxes { get; set; }
        public virtual DbSet<VillageWiseIncreaseInDemandCess> VillageWiseIncreaseInDemandCesses { get; set; }
        public virtual DbSet<VillageWiseIncreaseInDemandLandrevenue> VillageWiseIncreaseInDemandLandrevenues { get; set; }
        public virtual DbSet<VillageWiseRemissionCess> VillageWiseRemissionCesses { get; set; }
        public virtual DbSet<VillageWiseRemissionWaterTax> VillageWiseRemissionWaterTaxes { get; set; }
        public virtual DbSet<Banke> Bankes { get; set; }
        public virtual DbSet<Farmer> Farmers { get; set; }
        public virtual DbSet<IIIAKhata> IIIAKhatas { get; set; }
        public virtual DbSet<IrrigatedPlot> IrrigatedPlots { get; set; }
        public virtual DbSet<TempDemandCess> TempDemandCesses { get; set; }
        public virtual DbSet<VillageWiseDemandMiscRevenue> VillageWiseDemandMiscRevenues { get; set; }
        public virtual DbSet<AdvanceAdjustmentCess> AdvanceAdjustmentCesses { get; set; }
        public virtual DbSet<AdvanceAdjustmentLandRevenue> AdvanceAdjustmentLandRevenues { get; set; }
        public virtual DbSet<AdvanceAdjustmentWaterTax> AdvanceAdjustmentWaterTaxes { get; set; }
        public virtual DbSet<AdvanceCollectionCess> AdvanceCollectionCesses { get; set; }
        public virtual DbSet<AdvanceCollectionLandRevenue> AdvanceCollectionLandRevenues { get; set; }
        public virtual DbSet<AdvanceCollectionWaterTax> AdvanceCollectionWaterTaxes { get; set; }
        public virtual DbSet<CollectionMovementCess> CollectionMovementCesses { get; set; }
        public virtual DbSet<CollectionMovementMiscRevenue> CollectionMovementMiscRevenues { get; set; }
        public virtual DbSet<DCBMiscRevenue> DCBMiscRevenues { get; set; }
        public virtual DbSet<Defaulter> Defaulters { get; set; }
        public virtual DbSet<IFormAbstractCess> IFormAbstractCesses { get; set; }
        public virtual DbSet<IFormAbstractLandRevenue> IFormAbstractLandRevenues { get; set; }
        public virtual DbSet<IFormAbstractMiscRevenue> IFormAbstractMiscRevenues { get; set; }
        public virtual DbSet<IFormAbstractOLR> IFormAbstractOLRs { get; set; }
        public virtual DbSet<IFormAbstractOther> IFormAbstractOthers { get; set; }
        public virtual DbSet<IFormAbstractWaterTax> IFormAbstractWaterTaxes { get; set; }
        public virtual DbSet<IFormDetailCess> IFormDetailCesses { get; set; }
        public virtual DbSet<IFormDetailLandRevenue> IFormDetailLandRevenues { get; set; }
        public virtual DbSet<IFormDetailMiscRevenue> IFormDetailMiscRevenues { get; set; }
        public virtual DbSet<IFormDetailOLR> IFormDetailOLRs { get; set; }
        public virtual DbSet<IFormDetailOPDR> IFormDetailOPDRs { get; set; }
        public virtual DbSet<IFormDetailOther> IFormDetailOthers { get; set; }
        public virtual DbSet<IFormDetailWaterTax> IFormDetailWaterTaxes { get; set; }
        public virtual DbSet<IrrigatedPlotView> IrrigatedPlotViews { get; set; }
        public virtual DbSet<KhatasWithArea> KhatasWithAreas { get; set; }
        public virtual DbSet<MalAreaTbl> MalAreaTbls { get; set; }
        public virtual DbSet<PartKhatasPlot> PartKhatasPlots { get; set; }
        public virtual DbSet<PartPlot> PartPlots { get; set; }
        public virtual DbSet<PartPlotsDueTo8_A_> PartPlotsDueTo8_A_ { get; set; }
        public virtual DbSet<PartPlotsDueToMc> PartPlotsDueToMcs { get; set; }
        public virtual DbSet<PlotsWithRT> PlotsWithRTs { get; set; }
        public virtual DbSet<Remission_2015_2016> Remission_2015_2016 { get; set; }
        public virtual DbSet<SadarSiha> SadarSihas { get; set; }
        public virtual DbSet<TotalCollectionCess> TotalCollectionCesses { get; set; }
        public virtual DbSet<TotalCollectionWaterTax> TotalCollectionWaterTaxes { get; set; }
        public virtual DbSet<VillageWiseTahCollectionCess> VillageWiseTahCollectionCesses { get; set; }
        public virtual DbSet<VillageWiseTahCollectionLandRevenue> VillageWiseTahCollectionLandRevenues { get; set; }
        public virtual DbSet<VillageWiseTahCollectionMiscRevenue> VillageWiseTahCollectionMiscRevenues { get; set; }
        public virtual DbSet<VillageWiseTahCollectionWaterTax> VillageWiseTahCollectionWaterTaxes { get; set; }
        public virtual DbSet<WaterTaxDefaulter> WaterTaxDefaulters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new KhataMap());
            modelBuilder.Configurations.Add(new VillageMap());
            modelBuilder.Configurations.Add(new PlotMap());
            modelBuilder.Configurations.Add(new DemandLandRevenueMap());
            modelBuilder.Configurations.Add(new DemandCessMap());
            modelBuilder.Configurations.Add(new DemandWaterTaxMap());
            //ri collection 
            modelBuilder.Configurations.Add(new ReceiptMap());
            modelBuilder.Configurations.Add(new CollectionCessMap());
            modelBuilder.Configurations.Add(new CollectionWaterTaxMap());
            modelBuilder.Configurations.Add(new CollectionLandRevenueMap());
            modelBuilder.Configurations.Add(new CollectionMiscRevenueMap());
            //
            modelBuilder.Configurations.Add(new MiscRevenueMap());
            modelBuilder.Configurations.Add(new DemandMiscRevenueMap());
            modelBuilder.Configurations.Add(new TypeOfMiscRevMap());
            modelBuilder.Configurations.Add(new VillageWiseTahCollectionMiscRevenueMap());
            //
            modelBuilder.Configurations.Add(new IFormMap());
            modelBuilder.Configurations.Add(new IFormDetailCessMap());
            modelBuilder.Configurations.Add(new IFormDetailLandRevenueMap());
            modelBuilder.Configurations.Add(new IFormDetailWaterTaxMap());
            modelBuilder.Configurations.Add(new IFormDetailMiscRevenueMap());
            modelBuilder.Configurations.Add(new IFormDetailOLRMap());
            modelBuilder.Configurations.Add(new IFormDetailOPDRMap());
            modelBuilder.Configurations.Add(new IFormDetailOtherMap());
            modelBuilder.Configurations.Add(new CollectionMovementCessMap());
            modelBuilder.Configurations.Add(new CollectionMovementMiscRevenueMap());
            modelBuilder.Configurations.Add(new VillageWiseDemandCessMap());
            modelBuilder.Configurations.Add(new VillageWiseDemandLandRevenueMap());
            modelBuilder.Configurations.Add(new VillageWiseDemandWaterTaxMap());
            //Adjustment
            modelBuilder.Configurations.Add(new AdvanceAdjustmentLandRevenueMap());
            modelBuilder.Configurations.Add(new AdvanceAdjustmentWaterTaxMap());
            modelBuilder.Configurations.Add(new AdvanceAdjustmentCessMap());
            //Addvance
            modelBuilder.Configurations.Add(new AdvanceCollectionLandRevenueMap());
            modelBuilder.Configurations.Add(new AdvanceCollectionWaterTaxMap());
            modelBuilder.Configurations.Add(new AdvanceCollectionCessMap());
            //increase
            modelBuilder.Configurations.Add(new VillageWiseIncreaseInDemandLandrevenueMap());
            modelBuilder.Configurations.Add(new VillageWiseIncreaseInDemandCessMap());
            //tah collection
            modelBuilder.Configurations.Add(new TahReceiptMap());

            modelBuilder.Configurations.Add(new TahCollectionCessMap());
            modelBuilder.Configurations.Add(new TahCollectionWaterTaxMap());
            modelBuilder.Configurations.Add(new TahCollectionLandRevenueMap());
            modelBuilder.Configurations.Add(new TahCollectionMiscRevenueMap());

            modelBuilder.Configurations.Add(new VillageWiseTahCollectionCessMap());
            modelBuilder.Configurations.Add(new VillageWiseTahCollectionWaterTaxMap());
            modelBuilder.Configurations.Add(new VillageWiseTahCollectionLandRevenueMap());

            modelBuilder.Configurations.Add(new DefaulterMap());
        }
    }
}
