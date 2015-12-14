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
    public class MFormsController : Controller
    {
        private IRIOMSRepository repository;

        public MFormsController(IRIOMSRepository RIOMSRepository)
        {
            this.repository = RIOMSRepository;
        }

        public ActionResult Index(int vid,string year)
        {

            return View(repository.GetDefaulters(vid, year).OrderBy(ac => ac.KhataNo.Contains('/') ? Convert.ToInt32(ac.KhataNo.Substring(ac.KhataNo.IndexOf('/') + 1, ac.KhataNo.Contains('(') ? (ac.KhataNo.IndexOf('(') - (ac.KhataNo.IndexOf('/') + 1)) : (ac.KhataNo.Length - (ac.KhataNo.IndexOf('/') + 1)))) + Convert.ToInt32(ac.KhataNo.Substring(0, ac.KhataNo.IndexOf('/'))) : Convert.ToInt32(ac.KhataNo.Substring(0, ac.KhataNo.Length - (ac.KhataNo.IndexOf('/') + 1)))));
        }

        public ViewResult Abstract(string year)
        {
             List<DCBViewModel> dcbs = new List<DCBViewModel>();
            foreach (Village village in repository.Villages.Where(v => v.RICircleId == 1))
            {
                dcbs.Add(new DCBViewModel(repository.GetVillageWithDCB(village.Id, year)));
            }
            return View(new MFormAbstractViewModel(dcbs));
        }
    }
}
