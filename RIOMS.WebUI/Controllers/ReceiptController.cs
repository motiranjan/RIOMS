using System.Web.Mvc;
using RIOMS.Domain.Concrete;
using RIOMS.Domain.Abstract;
using RIOMS.Domain;
using RIOMS.WebUI.Extensions;
using Newtonsoft.Json;
using System;

namespace RIOMS.WebUI.Controllers
{
    public class ReceiptController : Controller 
    {
        //
        // GET: /Receipt/
        private IRIOMSRepository repository;

        public ReceiptController(IRIOMSRepository RIOMSRepository)
        {
            this.repository = RIOMSRepository;
        }
        public ViewResult Index()
        {
            
            ViewBag.Villages =new SelectList(repository.Villages,"Id","Name");
            return View("Index", new Receipt() { CollectionCess = new CollectionCess() });
        }
        public JsonNetResult Receipt()
        {
            var receipt = new Receipt() { Date = DateTime.Today, CollectionCess = new CollectionCess(), CollectionLandRevenue = new CollectionLandRevenue(), CollectionWaterTax = new CollectionWaterTax(), CollectionMiscRevenue = new CollectionMiscRevenue(),CollectionOther=new CollectionOther()};
            JsonNetResult jsonNetResult = new JsonNetResult();
            jsonNetResult.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            jsonNetResult.Data = receipt;
            return jsonNetResult;
        }
        public JsonNetResult GetReceiptByNo(int receiptNo)
        {
            JsonNetResult jsonNetResult = new JsonNetResult();
            jsonNetResult.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            jsonNetResult.Data = repository.GetReceiptByNo(receiptNo);
            return jsonNetResult;
        }
        public JsonNetResult GetKhata(string khataNo, int villageId,string fyear)
        {
            Khata khata = repository.GetLedger(khataNo, villageId, fyear);
            if (khata!=null)
            {
                if (khata.NameOfRT.Length > 15)
                {
                    khata.NameOfRT = khata.NameOfRT.Substring(0, 15) + "...";
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
