using Newtonsoft.Json;
using RIOMS.Domain;
using RIOMS.Domain.Abstract;
using RIOMS.Domain.Models;
using RIOMS.WebUI.Extensions;
using System.Linq;
using System.Web.Mvc;

namespace RIOMS.WebUI.Controllers
{
    public class LedgerController : Controller
    {
        // GET: /Ledger/
        private IRIOMSRepository repository;

        public LedgerController(IRIOMSRepository RIOMSRepository)
        {
            this.repository = RIOMSRepository;
        }

        public ViewResult Index()
        {
            ViewBag.Villages = new SelectList(repository.Villages.Where(v => v.RICircleId == Util.Util.RICId), "Id", "Name");
            return View();
        }

        //public ViewResult DCB(int vid, string year)
        //{
        //    ViewBag.IForms = repository.IForms.Where(f => f.Year == year);
        //    Village village = repository.GetVillageWithDCB(vid, year);
        //    ICollection<IForm> iforms = repository.IForms.Where(f => f.Year == year).ToList();

        //    return View(new DCBViewModel(village, iforms));
        //}

        public ViewResult AdvAdj(int vid, string year)
        {
            ViewBag.Village = repository.Villages.SingleOrDefault(v => v.Id == vid);
            return View(repository.GetAdvAdj(year, vid));
        }

        public ViewResult AdvCol(int vid, string year)
        {
            ViewBag.Village = repository.Villages.SingleOrDefault(v => v.Id == vid);
            return View(repository.GetAdvCol(year, vid));
        }

        public JsonNetResult GetKhata(string khatano, int villageId, string fyear)
        {
            JsonNetResult jsonNetResult = new JsonNetResult();
            jsonNetResult.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            jsonNetResult.Data = repository.GetLedger(khatano, villageId, fyear);
            return jsonNetResult;
        }

        [HttpPost]
        public JsonNetResult UpdateLedger(Khata khata, string fyear)
        {
            JsonNetResult jsonNetResult = new JsonNetResult();
            jsonNetResult.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            jsonNetResult.Data = repository.UpdateLedger(khata, fyear);
            return jsonNetResult;
        }
    }
}