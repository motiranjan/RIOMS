using RIOMS.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace RIOMS.Domain.Abstract
{
    public interface IRIOMSRepository
    {
        IQueryable<Receipt> Receipts { get; }

        IQueryable<IForm> IForms { get; }
        IQueryable<Village> Villages { get; }
        IQueryable<TypesOfMiscRev> TypesOfMiscRev { get; }
        IQueryable<MiscRevenue> MiscRevenues { get; }

        Receipt GetReceiptByNo(int receiptNo);

        bool SaveReceipt(Receipt recept);

        List<Khata> GetKhatas(int villageId);

        void SaveMiscRev(MiscRevenue miscRev);

        Khata GetKhata(string khataNo, int villageId);

        IQueryable<Receipt> VillageWari(int vid, int cNo, string year);

        //IEnumerable<VillageWari> GetVillageWari(int vid, int cNo, string year);

        IQueryable<Receipt> GetAllReceipt();

        IQueryable<Receipt> GetReceiptsByIForm(IForm iForm);

        IQueryable<Receipt> GetCessCollection(int villageId);

        Khata GetLedger(string khataNo, int villageId, string fyear);

        IEnumerable<Defaulter> GetDefaulters(int villageId, string year);

        Khata UpdateLedger(Khata argKhata, string fyear);

        IForm GetIform(string year, int iformNo);

        IEnumerable<IForm> GetIformsVillageWise(string year, int vid);

        Village GetVillageWithDCB(int vid, string year);

        Village GetMiscRevDetail(int vid, string year);

        IEnumerable<IForm> GetMiscCollectionIformWise(string year, int vid);

        IEnumerable<IForm> GetAllIForms(string year);

        Village GetAdvAdj(string year, int vid);

        Village GetAdvCol(string year, int vid);

        // IEnumerable<Village> GetVillagesWithDCB(string year);
        Village GetVillageWithReceipts(string year, int vid);

        //IEnumerable<GoToVillageCess> GetGoToVillagesCess(string year, int vid);

        //IEnumerable<ComeFromVillageCess> GetComeFromVillagesCess(string year, int vid);

        IEnumerable<PlotsWithRT> GetMasaPlots(int vid);

        IEnumerable<PlotsWithRT> GetBasaPlots(int vid);

        IEnumerable<KhataWithArea> GetKhataMasaArea(int vid);

        IEnumerable<KhataWithArea> GetKhataBasaArea(int vid);

        IEnumerable<KhataWithArea> GetKahtasWiseCultivableArea(int vid);

        KhataWithArea GetKahtaWithCultivableArea(int vid, string khataNo);

        IEnumerable<Khata> GetKhataByRt(string name, int ricId);

        Village GetDCBMiscRev(int vid, string year);

        Village GetDCBXVI2(int vid, string year);

        IEnumerable<PlotsWithRT> GetKisamWiseArea(int vid, string kisam);

        bool AddIform(IForm iform);
    }
}