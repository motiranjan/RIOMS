using RIOMS.Domain;
using RIOMS.Domain.Abstract;
using RIOMS.Domain.Models;
using RIOMS.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RIOMS.WebUI.Controllers
{
    public class MFormsController : Controller
    {
        private IRIOMSRepository repository;

        public MFormsController(IRIOMSRepository RIOMSRepository)
        {
            this.repository = RIOMSRepository;
        }

        public ActionResult Index(int vid,string year)
        {
           // ViewBag.ArrearFrom = arrearfrom;
           // ViewBag.ArrearTo = arrearto;
          ViewBag.VillageName=  repository.Villages.SingleOrDefault(v => v.RICircleId == 4 && v.Id == vid).Name;
            return View(repository.GetDefaulters(vid, year).OrderBy(k=>k.KhataNo)
                //.OrderBy(ac => ac.KhataNo.Contains('/') ? Convert.ToInt32(ac.KhataNo.Substring(ac.KhataNo.IndexOf('/') + 1, ac.KhataNo.Contains('(') ? (ac.KhataNo.IndexOf('(') - (ac.KhataNo.IndexOf('/') + 1)) : (ac.KhataNo.Length - (ac.KhataNo.IndexOf('/') + 1)))) + Convert.ToInt32(ac.KhataNo.Substring(0, ac.KhataNo.IndexOf('/'))) : Convert.ToInt32(ac.KhataNo.Substring(0, ac.KhataNo.Length - (ac.KhataNo.IndexOf('/') + 1))))
                );
        }

        public ViewResult Abstract(string year)
        {
             List<DCBViewModel> dcbs = new List<DCBViewModel>();
            foreach (Village village in repository.Villages.Where(v => v.RICircleId == Util.Util.RICId))
            {
                dcbs.Add(new DCBViewModel(repository.GetVillageWithDCB(village.Id, year)));
            }
            return View(new MFormAbstractViewModel(dcbs));
        }

        public ViewResult WithInt(int vid,string year,decimal amount)
        {
            ViewBag.MoreThen = amount;
            ViewBag.VillageName = repository.Villages.SingleOrDefault(v => v.RICircleId == 1 && v.Id == vid).Name;
            return View(repository.GetDefaulters(vid, year).OrderBy(ac => ac.KhataNo.Contains('/') ? Convert.ToInt32(ac.KhataNo.Substring(ac.KhataNo.IndexOf('/') + 1, ac.KhataNo.Contains('(') ? (ac.KhataNo.IndexOf('(') - (ac.KhataNo.IndexOf('/') + 1)) : (ac.KhataNo.Length - (ac.KhataNo.IndexOf('/') + 1)))) + Convert.ToInt32(ac.KhataNo.Substring(0, ac.KhataNo.IndexOf('/'))) : Convert.ToInt32(ac.KhataNo.Substring(0, ac.KhataNo.Length - (ac.KhataNo.IndexOf('/') + 1)))));
        }
    }
}
