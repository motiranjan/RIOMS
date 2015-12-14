using RIOMS.Domain;
using RIOMS.Domain.Abstract;
using RIOMS.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RIOMS.WebUI.Controllers
{
    public class VillageWariController : Controller
    {
        //
        // GET: /VillageWari/
         private IRIOMSRepository repository;

         public VillageWariController(IRIOMSRepository RIOMSRepository)
        {
            this.repository = RIOMSRepository;
        }
        public ViewResult Index(string year, int iformNo,int vid)
        {
            ViewBag.Village = repository.Villages.SingleOrDefault(v => v.Id == vid);
            ReceiptViewModel viewModel = new ReceiptViewModel(repository.VillageWari(vid, iformNo, year));
            return View(viewModel);
        }
        public ViewResult Abstract(string year, int vid)
        {
           
            Village village = repository.GetVillageWithDCB(vid, year);
            return View(new VillageWariAbstractViewModel(repository.GetIformsVillageWise(year, vid),village));
        }
      public ViewResult Collections(string year,int vid)
        {
         
              Village village =repository.GetVillageWithReceipts(year, vid);
           ViewBag.VillageName=village.Name;
            return View(new ReceiptViewModel(village.Receipts));
        }
    }
}
