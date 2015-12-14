using System;
using System.Collections.Generic;
using System.Linq;
using RIOMS.Domain.Abstract;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Data;
namespace RIOMS.Domain.Concrete
{
    public class RIOMSRepository : IRIOMSRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Receipt> Receipts
        {
            get { return context.Receipts; }
        }

        public IQueryable<Village> Villages
        {
            get { return context.Villages; }
        }
        public IQueryable<IForm> IForms { get { return context.IForms; } }

        public IQueryable<Receipt> VillageWari(int vid, int cNo, string year)
        {
            IForm iform;
            IQueryable<Receipt> receipts;
            if (cNo != 0)
            {
                iform = IForms.SingleOrDefault(f => f.IFormNo == cNo && f.Year == year);
                receipts = context.Receipts.Where(r => r.VillageId == vid && r.Date >= iform.FromDate && r.Date <= iform.ToDate && r.CollectionMiscRevenue == null).OrderBy(r => r.Date);
            }
            else
            {
                receipts = context.Receipts.Where(r => r.ActualVillageId == vid && r.CollectionMiscRevenue == null).OrderBy(r => r.Date);
            }

            foreach (var receipt in receipts)
            {
                context.Entry(receipt).Reference(r => r.CollectionCess).Load();
                context.Entry(receipt).Reference(r => r.CollectionLandRevenue).Load();
                context.Entry(receipt).Reference(r => r.CollectionWaterTax).Load();
                context.Entry(receipt).Reference(r => r.CollectionMiscRevenue).Load();
                context.Entry(receipt).Reference(r => r.Village).Load();
            }
            return receipts;
        }
        public IQueryable<TypesOfMiscRev> TypesOfMiscRev
        {
            get { return context.TypesOfMiscRevs; }
        }
        public IForm NextIForm
        {
            get { return context.IForms.Single(i => i.IsDeposited == false); }
        }



        public Khata GetKhata(string khataNo, int villageId)
        {
            return context.Khatas.SingleOrDefault(k => k.VillageId == villageId && k.KhataNo == khataNo);


        }
        private void LoadReceiptDetail(Receipt receipt)
        {
            context.Entry(receipt).Reference(r => r.CollectionCess).Load();
            context.Entry(receipt).Reference(r => r.CollectionLandRevenue).Load();
            context.Entry(receipt).Reference(r => r.CollectionWaterTax).Load();
            context.Entry(receipt).Reference(r => r.CollectionMiscRevenue).Load();
            context.Entry(receipt).Reference(r => r.CollectionOther).Load();
            context.Entry(receipt).Reference(r => r.CollectionOLR).Load();
            context.Entry(receipt).Reference(r => r.CollectionOPDR).Load();
            context.Entry(receipt).Reference(r => r.Village).Load();
        }
        /// <summary>
        /// Save the Receipt
        /// </summary>
        /// <param name="receipt"></param>
        /// <returns></returns>
        public bool SaveReceipt(Receipt receipt)
        {
            try
            {

                var oldRecept = context.Receipts.SingleOrDefault(r => r.ReceiptNo == receipt.ReceiptNo);
                if (oldRecept != null)
                {
                    LoadReceiptDetail(oldRecept);
                    oldRecept.KhataNo = receipt.KhataNo;
                    oldRecept.VillageId = receipt.VillageId;
                    oldRecept.NameOfRT = receipt.NameOfRT;
                    if (oldRecept.HasCess || receipt.HasCess)
                    {
                        if (receipt.HasCess)
                        {
                            if (!oldRecept.HasCess)
                            {
                                oldRecept.CollectionCess = new CollectionCess();
                            }
                            oldRecept.CollectionCess.Current = receipt.CollectionCess.Current;
                            oldRecept.CollectionCess.Previous = receipt.CollectionCess.Previous;
                            oldRecept.CollectionCess.Second = receipt.CollectionCess.Second;
                            oldRecept.CollectionCess.Third = receipt.CollectionCess.Third;
                            oldRecept.CollectionCess.MoreThanThree = receipt.CollectionCess.MoreThanThree;
                            oldRecept.CollectionCess.InterestTotal = receipt.CollectionCess.InterestTotal;
                        }
                        else
                        {
                            oldRecept.CollectionCess = null;
                        }
                    }



                    if (oldRecept.HasLandRevenue || receipt.HasLandRevenue)
                    {
                        if (receipt.HasLandRevenue)
                        {
                            if (!oldRecept.HasLandRevenue)
                            {
                                oldRecept.CollectionLandRevenue = new CollectionLandRevenue();
                            }
                            oldRecept.CollectionLandRevenue.Current = receipt.CollectionLandRevenue.Current;
                            oldRecept.CollectionLandRevenue.Previous = receipt.CollectionLandRevenue.Previous;
                            oldRecept.CollectionLandRevenue.Second = receipt.CollectionLandRevenue.Second;
                            oldRecept.CollectionLandRevenue.Third = receipt.CollectionLandRevenue.Third;
                            oldRecept.CollectionLandRevenue.MoreThanThree = receipt.CollectionLandRevenue.MoreThanThree;
                            oldRecept.CollectionLandRevenue.InterestTotal = receipt.CollectionLandRevenue.InterestTotal;
                        }
                        else
                        {
                            oldRecept.CollectionLandRevenue = null;
                        }

                    }

                    if (oldRecept.HasWaterTax || receipt.HasWaterTax)
                    {
                        if (!oldRecept.HasWaterTax)
                        {
                            oldRecept.CollectionWaterTax = new CollectionWaterTax();
                        }
                        oldRecept.CollectionWaterTax.Current = receipt.CollectionWaterTax.Current;
                        oldRecept.CollectionWaterTax.Previous = receipt.CollectionWaterTax.Previous;
                        oldRecept.CollectionWaterTax.Second = receipt.CollectionWaterTax.Second;
                        oldRecept.CollectionWaterTax.Third = receipt.CollectionWaterTax.Third;
                        oldRecept.CollectionWaterTax.MoreThanThree = receipt.CollectionWaterTax.MoreThanThree;
                        oldRecept.CollectionWaterTax.InterestTotal = receipt.CollectionWaterTax.InterestTotal;
                    }
                    if (oldRecept.HasMiscRevenue || receipt.HasMiscRevenue)
                    {
                        if (!oldRecept.HasMiscRevenue)
                        {
                            oldRecept.CollectionMiscRevenue = new CollectionMiscRevenue();
                        }
                        oldRecept.CollectionMiscRevenue.CaseNo = receipt.CollectionMiscRevenue.CaseNo;
                        oldRecept.CollectionMiscRevenue.Current = receipt.CollectionMiscRevenue.Current;
                        oldRecept.CollectionMiscRevenue.Arrear = receipt.CollectionMiscRevenue.Arrear;
                        oldRecept.CollectionMiscRevenue.Type = receipt.CollectionMiscRevenue.Type;
                        oldRecept.CollectionMiscRevenue.Interest = receipt.CollectionMiscRevenue.Interest;

                    }
                    if (oldRecept.HasOthers || receipt.HasOthers)
                    {
                        if (!oldRecept.HasOthers)
                        {
                            oldRecept.CollectionOther = new CollectionOther();
                        }
                        oldRecept.CollectionOther.CaseNo = receipt.CollectionOther.CaseNo;
                        oldRecept.CollectionOther.Amount = receipt.CollectionOther.Amount;
                        oldRecept.CollectionOther.Type = receipt.CollectionOther.Type;

                    }
                    oldRecept.Date = receipt.Date;
                    // oldRecept.CollectionLandRevenue = recept.CollectionLandRevenue;
                    // oldRecept.CollectionWaterTax = recept.CollectionWaterTax;
                }
                else
                {
                    context.Receipts.Add(receipt);
                }
                context.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException dbex)
            {
                Exception raise = dbex;
                foreach (var vErrors in dbex.EntityValidationErrors)
                {
                    foreach (var vError in vErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}", vErrors.Entry.Entity.ToString(), vError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                return false;
            }
        }
        public Receipt GetReceiptByNo(int receiptNo)
        {
            var receipt = context.Receipts.SingleOrDefault(r => r.ReceiptNo == receiptNo);
            LoadReceiptDetail(receipt);
            return receipt;
        }


        public IQueryable<Receipt> GetAllReceipt()
        {
            var receipts = context.Receipts;
            foreach (var receipt in receipts)
            {
                LoadReceiptDetail(receipt);
            }
            return receipts;
        }


        public IQueryable<Receipt> GetReceiptsByIForm(IForm iform)
        {
            if (iform.IsDeposited == null)
            {
                iform.FromDate = IForms.Single(i => i.IFormNo == iform.IFormNo && i.Year == iform.Year).FromDate;
                iform.ToDate = IForms.Single(i => i.IFormNo == iform.IFormNo && i.Year == iform.Year).ToDate;
            }
            var receipts = Receipts.Where(r => r.Date >= iform.FromDate && r.Date <= iform.ToDate);
            foreach (var receipt in receipts)
            {
                LoadReceiptDetail(receipt);
            }
            return receipts;

        }


        public IQueryable<Receipt> GetCessCollection(int villageId)
        {
            var receipts = context.Receipts.Where(r => r.VillageId == villageId && r.HasCess);
            foreach (var receipt in receipts)
            {
                LoadReceiptDetail(receipt);
            }
            return receipts;
        }

        private void LoadDemand(Khata khata, string fyear)
        {
            context.Entry(khata).Collection(d => d.DemandCesses).Query().Where(d => d.Year == fyear).Load();
            context.Entry(khata).Collection(d => d.DemandWaterTaxes).Query().Where(d => d.Year == fyear).Load();
            context.Entry(khata).Collection(d => d.Receipts).Query().Where(r => r.Year == fyear).Load();
            context.Entry(khata).Reference(d => d.Village).Load();
            khata.TotalArea = context.Entry(khata).Collection(d => d.PlotDetails).Query().Sum(p => p.Area).GetValueOrDefault();
        }
        public Khata GetLedger(string khataNo, int villageId, string fyear)
        {
            var khata = context.Khatas.SingleOrDefault(k => k.VillageId == villageId && k.KhataNo == khataNo);
            if (khata != null)
            {
                LoadDemand(khata, fyear);

                var receipts = khata.Receipts;
                foreach (var receipt in receipts)
                {
                    context.Entry(receipt).Reference(r => r.CollectionCess).Load();
                    context.Entry(receipt).Reference(r => r.CollectionWaterTax).Load();
                }
            }
            return khata;
        }


        //public IEnumerable<CessDCB> GetCessDCB(int villageId)
        //{
        //  return  context.GetCessDCB(villageId);
        //}


        public Khata UpdateLedger(Khata argKhata, string fyear)
        {
            try
            {
                var khata = context.Khatas.SingleOrDefault(k => k.VillageId == argKhata.VillageId && k.KhataNo == argKhata.KhataNo);
                if (khata != null)
                {
                    LoadDemand(khata, fyear);
                    var receipts = khata.Receipts;
                    foreach (var receipt in receipts)
                    {
                        context.Entry(receipt).Reference(r => r.CollectionCess).Load();
                        context.Entry(receipt).Reference(r => r.CollectionWaterTax).Load();
                    }
                    if (khata.DemandCesses.Count == 0 && argKhata.DemandCesses.Count > 0)
                    {
                        argKhata.DemandCesses.ElementAt(0).KhataNo = argKhata.KhataNo;
                        argKhata.DemandCesses.ElementAt(0).VillageId = argKhata.VillageId;
                        argKhata.DemandCesses.ElementAt(0).Year = fyear;
                        khata.DemandCesses.Add(argKhata.DemandCesses.ElementAt(0));
                    }
                    if (khata.DemandCesses.Count > 0)
                    {

                        khata.DemandCesses.ElementAt(0).MoreThanThree = argKhata.DemandCesses.ElementAt(0).MoreThanThree;
                        khata.DemandCesses.ElementAt(0).Third = argKhata.DemandCesses.ElementAt(0).Third;
                        khata.DemandCesses.ElementAt(0).Second = argKhata.DemandCesses.ElementAt(0).Second;
                        khata.DemandCesses.ElementAt(0).Previous = argKhata.DemandCesses.ElementAt(0).Previous;
                        khata.DemandCesses.ElementAt(0).Current = argKhata.DemandCesses.ElementAt(0).Current;
                        khata.DemandCesses.ElementAt(0).Advance = argKhata.DemandCesses.ElementAt(0).Advance;
                    }
                    if (khata.DemandWaterTaxes.Count == 0 && argKhata.DemandWaterTaxes.Count > 0)
                    {
                        argKhata.DemandWaterTaxes.ElementAt(0).KhataNo = argKhata.KhataNo;
                        argKhata.DemandWaterTaxes.ElementAt(0).VillageId = argKhata.VillageId;
                        argKhata.DemandWaterTaxes.ElementAt(0).Year = fyear;
                        khata.DemandWaterTaxes.Add(argKhata.DemandWaterTaxes.ElementAt(0));

                    }
                    if (khata.DemandWaterTaxes.Count > 0)
                    {
                        khata.DemandWaterTaxes.ElementAt(0).MoreThanThree = argKhata.DemandWaterTaxes.ElementAt(0).MoreThanThree;
                        khata.DemandWaterTaxes.ElementAt(0).Third = argKhata.DemandWaterTaxes.ElementAt(0).Third;
                        khata.DemandWaterTaxes.ElementAt(0).Second = argKhata.DemandWaterTaxes.ElementAt(0).Second;
                        khata.DemandWaterTaxes.ElementAt(0).Previous = argKhata.DemandWaterTaxes.ElementAt(0).Previous;
                        khata.DemandWaterTaxes.ElementAt(0).Current = argKhata.DemandWaterTaxes.ElementAt(0).Current;
                        khata.DemandWaterTaxes.ElementAt(0).Advance = argKhata.DemandWaterTaxes.ElementAt(0).Advance;
                    }
                }
                context.SaveChanges();
                return khata;
            }
            catch (DbEntityValidationException dbex)
            {
                Exception raise = dbex;
                foreach (var vErrors in dbex.EntityValidationErrors)
                {
                    foreach (var vError in vErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}", vErrors.Entry.Entity.ToString(), vError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }



        public IEnumerable<Defaulter> GetDefaulters(int villageId, string year)
        {


            return context.Defaulters.Where(d => d.VillageId == villageId && d.Year == year);
        }
        public void SaveMiscRev(MiscRevenue miscRev)
        {
            miscRev.DemandMiscRevenues.Add(new DemandMiscRevenue
            {
                Current = miscRev.Amount,
                Year = miscRev.FYear,
                VillageId = miscRev.VillageId,

            });
            context.MiscRevenues.Add(miscRev);

            context.SaveChanges();
        }


        public IEnumerable<VillageWari> GetVillageWari(int vid, int cNo, string year)
        {
            return context.GetVillageWari(cNo, vid, year);
        }


        public IForm GetIform(string year, int iformNo)
        {
            IForm iform = context.IForms.SingleOrDefault(c => c.Year == year && c.IFormNo == iformNo);
            context.Entry(iform).Collection(i => i.IFormDetailCesses).Load();
            context.Entry(iform).Collection(i => i.IFormDetailWaterTaxes).Load();
            context.Entry(iform).Collection(i => i.IFormDetailLandRevenues).Load();
            context.Entry(iform).Collection(i => i.IFormDetailMiscRevenues).Load();
            context.Entry(iform).Collection(i => i.IFormDetailOLRs).Load();
            context.Entry(iform).Collection(i => i.IFormDetailOthers).Load();
            return iform;
        }
        public IEnumerable<IForm> GetIformsVillageWise(string year, int vid)
        {
            IEnumerable<IForm> iforms = context.IForms.Where(c => c.Year == year);
            foreach (IForm iform in iforms)
            {
                context.Entry(iform).Collection(i => i.IFormDetailCesses).Query().Where(c => c.VillageId == vid).Load();
                context.Entry(iform).Collection(i => i.IFormDetailWaterTaxes).Query().Where(c => c.VillageId == vid).Load();
                context.Entry(iform).Collection(i => i.IFormDetailLandRevenues).Query().Where(c => c.VillageId == vid).Load();
                context.Entry(iform).Collection(i => i.IFormDetailOLRs).Query().Where(c => c.VillageId == vid).Load();
                context.Entry(iform).Collection(i => i.IFormDetailOthers).Query().Where(c => c.VillageId == vid).Load();

            }
            return iforms;
        }


        public Village GetVillageWithDCB(int vid, string year)
        {
            var village = context.Villages.Single(v => v.Id == vid);
            context.Entry(village).Collection(v => v.IFormDetailCesses).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.IFormDetailWaterTaxes).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.IFormDetailLandRevenues).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.DemandCesses).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.DemandWaterTaxes).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.DemandLandRevenues).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.VillageWiseDemandCesses).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.VillageWiseDemandWaterTaxes).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.VillageWiseDemandLandRevenues).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.AdvanceCollectionCesses).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.AdvanceAdjustmentCesses).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.AdvanceAdjustmentWaterTaxes).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.AdvanceCollectionWaterTaxes).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.AdvanceCollectionLandRevenues).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.CollectionMovementCessesTo).Query().Where(i => i.Year == year).Include(i => i.ToVillage).Load();
            context.Entry(village).Collection(v => v.CollectionMovementCessesFrom).Query().Where(i => i.Year == year).Include(i => i.FromVillage).Load();
            context.Entry(village).Collection(v => v.VillageWiseTahCollectionLandRevenues).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.VillageWiseTahCollectionCesses).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.VillageWiseTahCollectionWaterTaxes).Query().Where(i => i.Year == year).Load();


            return village;
        }



        public IQueryable<MiscRevenue> MiscRevenues
        {
            get { return context.MiscRevenues; }
        }


        public Village GetMiscRevDetail(int vid, string year)
        {
            Village village = Villages.SingleOrDefault(v => v.Id == vid);
            context.Entry(village).Collection(v => v.DemandMiscRevenues).Query().Where(d => d.VillageId == vid && d.Year == year).Include(m => m.MiscRevenue).Load();
            foreach (MiscRevenue miscRev in village.MiscRevenues)
            {
                context.Entry(miscRev).Collection(m => m.Receipts).Query().Where(r => r.Year == year).Include(r => r.CollectionMiscRevenue).Load();
                context.Entry(miscRev).Reference(m => m.TypesOfMiscRev).Load();
                context.Entry(miscRev).Collection(m => m.TahReceipts).Query().Where(r => r.Year == year).Include(r => r.TahCollectionMiscRevenue).Load();
            }


            return village;
        }



        public IEnumerable<IForm> GetMiscCollectionIformWise(string year, int vid)
        {
            IEnumerable<IForm> iforms = context.IForms.Where(c => c.Year == year);
            foreach (IForm iform in iforms)
            {
                context.Entry(iform).Collection(i => i.IFormDetailMiscRevenues).Query().Where(c => c.VillageId == vid).Load();

            }
            return iforms;
        }


        public IEnumerable<IForm> GetAllIForms(string year)
        {
            IEnumerable<IForm> iforms = context.IForms.Where(c => c.Year == year);
            foreach (IForm iform in iforms)
            {
                context.Entry(iform).Collection(i => i.IFormDetailCesses).Load();
                context.Entry(iform).Collection(i => i.IFormDetailWaterTaxes).Load();
                context.Entry(iform).Collection(i => i.IFormDetailLandRevenues).Load();
                context.Entry(iform).Collection(i => i.IFormDetailOLRs).Query().Load();
                context.Entry(iform).Collection(i => i.IFormDetailOthers).Load();
                context.Entry(iform).Collection(i => i.IFormDetailMiscRevenues).Load();
                context.Entry(iform).Collection(i => i.IFormDetailOPDRs).Load();
            }
            return iforms;
        }


        public Village GetAdvAdj(string year, int vid)
        {
            Village village = context.Villages.SingleOrDefault(v => v.Id == vid);
            context.Entry(village).Collection(v => v.AdvanceAdjustmentCesses).Query().Where(a => a.Year == year).Load();
            context.Entry(village).Collection(v => v.AdvanceAdjustmentWaterTaxes).Query().Where(a => a.Year == year).Load();
            // context.Entry(village).Collection(v => v.AdvanceAdjustmentLandRevenues).Query().Where(a => a.Year == year).Load();
            return village;
        }





        public Village GetAdvCol(string year, int vid)
        {
            Village village = context.Villages.SingleOrDefault(v => v.Id == vid);
            context.Entry(village).Collection(v => v.AdvanceCollectionCesses).Query().Where(a => a.Year == year).Load();
            context.Entry(village).Collection(v => v.AdvanceCollectionWaterTaxes).Query().Where(a => a.Year == year).Load();
            context.Entry(village).Collection(v => v.AdvanceCollectionLandRevenues).Query().Where(a => a.Year == year).Load();
            return village;
        }


        //public IEnumerable<Village> GetVillagesWithDCB(string year)
        // {
        //     IEnumerable<Village> villages = Villages.Where(V=>V.RICircleId==1);
        //     foreach (Village village in villages)
        //     {

        //     context.Entry(village).Collection(v => v.IFormDetailCesses).Query().Where(i => i.Year == year).Load();
        //     context.Entry(village).Collection(v => v.IFormDetailWaterTaxes).Query().Where(i => i.Year == year).Load();
        //     context.Entry(village).Collection(v => v.IFormDetailLandRevenues).Query().Where(i => i.Year == year).Load();
        //     context.Entry(village).Collection(v => v.DemandCesses).Query().Where(i => i.Year == year).Load();
        //     context.Entry(village).Collection(v => v.VillageWiseDemandCesses).Query().Where(i => i.Year == year).Load();
        //     context.Entry(village).Collection(v => v.VillageWiseDemandWaterTaxes).Query().Where(i => i.Year == year).Load();
        //     context.Entry(village).Collection(v => v.VillageWiseDemandLandRevenues).Query().Where(i => i.Year == year).Load();
        //     context.Entry(village).Collection(v => v.AdvanceCollectionCesses).Query().Where(i => i.Year == year).Load();
        //     context.Entry(village).Collection(v => v.AdvanceAdjustmentCesses).Query().Where(i => i.Year == year).Load();
        //     context.Entry(village).Collection(v => v.CollectionMovementCessesTo).Query().Where(i => i.Year == year).Include(i => i.ToVillage).Load();
        //     context.Entry(village).Collection(v => v.CollectionMovementCessesFrom).Query().Where(i => i.Year == year).Include(i => i.FromVillage).Load();
        //     context.Entry(village).Collection(v => v.VillageWiseTahCollectionCesses).Query().Where(c=>c.Year==year).Load();
        //     context.Entry(village).Collection(v => v.VillageWiseTahCollectionLandRevenues).Query().Where(c => c.Year == year).Load();

        //     }
        //     return villages;
        // }





        public Village GetVillageWithReceipts(string year, int vid)
        {
            Village village = Villages.SingleOrDefault(v => v.Id == vid);
            context.Entry(village).Collection(v => v.Receipts).Query().Where(i => i.Year == year).Include(r => r.CollectionCess).Include(r => r.CollectionWaterTax).Include(r => r.CollectionLandRevenue).Include(r => r.CollectionOther).Load();
            return village;
        }


        public IEnumerable<GoToVillageCess> GetGoToVillagesCess(string year, int vid)
        {
            return context.GetGoToVillagesCess(vid, year);
        }

        public IEnumerable<ComeFromVillageCess> GetComeFromVillagesCess(string year, int vid)
        {
            return context.GetComeFromVillagesCess(vid, year);
        }


        public Village GetDCBMiscRev(int vid, string year)
        {
            Village village = Villages.SingleOrDefault(v => v.Id == vid);
            context.Entry(village).Collection(v => v.DemandMiscRevenues).Query().Where(d => d.VillageId == vid && d.Year == year).Load();
            context.Entry(village).Collection(v => v.IFormDetailMiscRevenues).Query().Where(d => d.VillageId == vid && d.Year == year).Load();
            context.Entry(village).Collection(v => v.VillageWiseTahCollectionMiscRevenues).Query().Where(d => d.VillageId == vid && d.Year == year).Load();
            context.Entry(village).Collection(v => v.CollectionMovementMiscRevenuesFrom).Query().Where(m => m.Year == year).Include(m => m.VillageFrom).Load();
            context.Entry(village).Collection(v => v.CollectionMovementMiscRevenuesTo).Query().Where(m => m.Year == year).Include(m => m.VillageTo).Load();
            return village;

        }


        public Village GetDCBXVI2(int vid, string year)
        {
            Village village = Villages.SingleOrDefault(v => v.Id == vid);
            context.Entry(village).Collection(v => v.IFormDetailCesses).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.IFormDetailWaterTaxes).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.IFormDetailLandRevenues).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.IFormDetailOLRs).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.IFormDetailOthers).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.IFormDetailOPDRs).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.IFormDetailMiscRevenues).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.VillageWiseTahCollectionMiscRevenues).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.VillageWiseTahCollectionCesses).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.VillageWiseTahCollectionWaterTaxes).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.DemandMiscRevenues).Query().Where(i => i.Year == year).Load();
            context.Entry(village).Collection(v => v.CollectionMovementMiscRevenuesFrom).Query().Where(m => m.Year == year).Include(m => m.VillageFrom).Load();
            context.Entry(village).Collection(v => v.CollectionMovementMiscRevenuesTo).Query().Where(m => m.Year == year).Include(m => m.VillageTo).Load();
            context.Entry(village).Collection(v => v.CollectionMovementCessesTo).Query().Where(i => i.Year == year).Include(i => i.ToVillage).Load();
            context.Entry(village).Collection(v => v.CollectionMovementCessesFrom).Query().Where(i => i.Year == year).Include(i => i.FromVillage).Load();
            return village;
        }


        public IEnumerable<PlotsWithRT> GetMasaPlots(int vid)
        {
            return context.PlotsWithRTs.Where(p => p.Kisam.Contains("ମାଳ") && p.VillageId == vid);
        }

        public IEnumerable<PlotsWithRT> GetBasaPlots(int vid)
        {

            return context.PlotsWithRTs.Where(p => (p.Kisam.Contains("ବାହଲ") || p.Kisam.Contains("ବାହାଲ") || p.Kisam.Contains("ବେର୍ଣ୍ଣା") || p.Kisam.Contains("ବେରଣା")) && p.VillageId == vid);
        }
        public IEnumerable<KhataWithArea> GetKahtasWiseCultivableArea(int vid)
        {
            return context.PlotsWithRTs.Where(p => p.VillageId == vid).GroupBy(k => new { k.KhataNo, k.NameOfRT }).Select(x => new KhataWithArea
           {
               KhataNo = x.Key.KhataNo,
               TotalArea = x.Sum(p => p.Area),
               MalArea = x.Where(p => p.Kisam.Contains("ମାଳ")).Sum(p => p.Area),
               BahalArea = x.Where(p => (p.Kisam.Contains("ବେର୍ଣ୍ଣା") || p.Kisam.Contains("ବେରଣା") || p.Kisam.Contains("ବାହଲ") || p.Kisam.Contains("ବାହାଲ"))).Sum(p => p.Area),
               NameOfRT = x.Key.NameOfRT
           }).Where(p => p.MalArea > 0 || p.BahalArea > 0);
        }

        public KhataWithArea GetKahtaWithCultivableArea(int vid,string khtaNo)
       {
            //(p.Kisam.Contains("ମାଳ") || p.Kisam.Contains("ବେର୍ଣ୍ଣା") || p.Kisam.Contains("ବେରଣା") || p.Kisam.Contains("ବାହଲ") || p.Kisam.Contains("ବାହାଲ"))
           return  context.PlotsWithRTs.Where(p =>p.VillageId == vid && p.KhataNo==khtaNo).GroupBy(k => new { k.KhataNo, k.NameOfRT }).Select(x => new KhataWithArea
           { KhataNo = x.Key.KhataNo, 
               TotalArea=x.Sum(p=>p.Area),
             MalArea = x.Where(p => p.Kisam.Contains("ମାଳ")).Sum(p=>p.Area),
             BahalArea=x.Where(p=> (p.Kisam.Contains("ବେର୍ଣ୍ଣା") || p.Kisam.Contains("ବେରଣା") || p.Kisam.Contains("ବାହଲ") || p.Kisam.Contains("ବାହାଲ"))).Sum(p=>p.Area),
               NameOfRT = x.Key.NameOfRT
           }).Where(p=>p.MalArea>0 || p.BahalArea>0).FirstOrDefault();
           
          
       }


        public IEnumerable<KhataWithArea> GetKhataMasaArea(int vid)
        {
            return context.PlotsWithRTs.Where(p => p.Kisam.Contains("ମାଳ") && p.VillageId == vid).GroupBy(k => new { k.KhataNo, k.NameOfRT }).Select(x => new KhataWithArea { KhataNo = x.Key.KhataNo, TotalArea = x.Sum(p => p.Area), NameOfRT = x.Key.NameOfRT });
        }

        public IEnumerable<KhataWithArea> GetKhataBasaArea(int vid)
        {
            return context.PlotsWithRTs.Where(p => (p.Kisam.Contains("ବାହଲ") || p.Kisam.Contains("ବାହାଲ")) && p.VillageId == vid).GroupBy(k => new { k.KhataNo, k.NameOfRT }).Select(x => new KhataWithArea { KhataNo = x.Key.KhataNo, TotalArea = x.Sum(p => p.Area), NameOfRT = x.Key.NameOfRT });
        }


        public IEnumerable<Khata> GetKhataByRt(string name)
        {
            return context.Khatas.Where(k => k.NameOfRT.Contains(name));
        }
    }
}
