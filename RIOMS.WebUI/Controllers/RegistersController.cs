using Newtonsoft.Json;
//using Newtonsoft.Json;
using RIOMS.Domain;
using RIOMS.Domain.Abstract;
using RIOMS.WebUI.Extensions;
using RIOMS.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RIOMS.WebUI.Controllers
{
    public class RegistersController : Controller
    {
        //
        // GET: /Registers/
        private IRIOMSRepository repository;

        public RegistersController(IRIOMSRepository RIOMSRepository)
        {
            this.repository = RIOMSRepository;
        }
       public  ViewResult Index()
        {
            ViewBag.Villages = new SelectList(repository.Villages, "Id", "Name");
            return View("Receipt");
        }
       
        public JsonNetResult Receipt()
        {
            var receipt =new Receipt() {Date=DateTime.Today ,CollectionCess = new CollectionCess(),CollectionLandRevenue=new CollectionLandRevenue(),CollectionWaterTax=new CollectionWaterTax(),CollectionMiscRevenue=new CollectionMiscRevenue() };
            JsonNetResult jsonNetResult = new JsonNetResult();
            jsonNetResult.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            jsonNetResult.Data = receipt;
            return jsonNetResult;
        }
        public JsonNetResult ReceiptsByDate(DateTime date)
        {
            var receipts=repository.Receipts.Where(r=>r.Date==date).ToList();
             JsonNetResult jsonNetResult = new JsonNetResult();
             jsonNetResult.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            
            jsonNetResult.Data =receipts ;
            return jsonNetResult;
        }
        //[HttpPost]
        //public JsonResult SaveReceipts(IEnumerable<Receipt> receipts)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        repository.SaveReceipts(receipts);
        //        return Json(new {success=true});
        //    }
        //    else
        //    {
        //        return Json(new { success = false });
        //    }
        //}

       
        public ViewResult VillageWari(int vid,int cNo)
        {
            
            ReceiptViewModel viewModel = new ReceiptViewModel(repository.VillageWari(vid,cNo,"2015-2016"));
            return View(viewModel);
        }

        public ViewResult SadarSiha(int cNo)
        {
            ReceiptViewModel viewModel = new ReceiptViewModel(repository.GetReceiptsByIForm(new IForm() { IFormNo=cNo,Year="2015-2016"}));
            return View(viewModel);
        }
        public ViewResult Ledger()
        {
            ViewBag.Villages = new SelectList(repository.Villages, "Id", "Name");
            return View();
        }

        public ViewResult DCBMiscRev()
        {
            return View();
        }
    }
}
