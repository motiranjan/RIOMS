using Newtonsoft.Json;
using RIOMS.Domain;
using RIOMS.Domain.Abstract;
using RIOMS.Domain.Models;
using RIOMS.WebUI.Extensions;
using System;
using System.Linq;
using System.Web.Mvc;

namespace RIOMS.WebUI.Controllers
{
    public class ReceiptController : Controller
    {
        // GET: /Receipt/
        private IRIOMSRepository repository;

        public ReceiptController(IRIOMSRepository RIOMSRepository)
        {
            this.repository = RIOMSRepository;
        }

        public ViewResult Index()
        {
            ViewBag.Villages = new SelectList(repository.Villages.Where(v => v.RICircleId == Util.Util.RICId), "Id", "Name");
            return View("Index", new Receipt() { CollectionCess = new CollectionCess() });
        }

        public JsonNetResult Receipt()
        {
            var receipt = new Receipt() { Date = DateTime.Today, CollectionCess = new CollectionCess(), CollectionLandRevenue = new CollectionLandRevenue(), CollectionWaterTax = new CollectionWaterTax(), CollectionMiscRevenue = new CollectionMiscRevenue(), CollectionOther = new CollectionOther() };
            JsonNetResult jsonNetResult = new JsonNetResult();
            jsonNetResult.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            jsonNetResult.Data = receipt;
            return jsonNetResult;
        }

        public JsonNetResult GetReceiptByNo(int receiptNo)
        {
            JsonNetResult jsonNetResult = new JsonNetResult();

            jsonNetResult.Data = repository.GetReceiptByNo(receiptNo);
            jsonNetResult.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            return jsonNetResult;
        }

        public JsonNetResult GetKhata(string khataNo, int villageId, string fyear)
        {
            Khata khata = repository.GetLedger(khataNo, villageId, fyear);
            if (khata != null)
            {
                if (khata.NameOfRT != null && khata.NameOfRT.Length > 15)
                {
                    khata.NameOfRT = khata.NameOfRT;//.Substring(0, 15) + "...";
                }
            }
            JsonNetResult jsonNetResult = new JsonNetResult();
            jsonNetResult.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            jsonNetResult.Data = khata;
            return jsonNetResult;
        }

        private string GetFYear(DateTime date)
        {
            if (date.Month > 3)
            {
                return date.Year + "-" + (date.Year + 1);
            }
            else
            {
                return (date.Year - 1) + "-" + date.Year;
            }
        }

        [HttpPost]
        public JsonResult Save(Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                receipt.Year = GetFYear(receipt.Date);
                receipt.NameOfRT = receipt.NameOfRT?.Substring(0, 17);
                bool status = repository.SaveReceipt(receipt);
                return Json(new { success = status });
            }
            else
            {
                return Json(new { success = false });
            }
        }
    }
}