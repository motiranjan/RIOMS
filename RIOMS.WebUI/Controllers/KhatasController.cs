using RIOMS.Domain;
using RIOMS.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RIOMS.WebUI.Controllers
{
    public class KhatasController : Controller
    {
        private IRIOMSRepository repository;
        public KhatasController(IRIOMSRepository RIOMSRepository)
        {
            this.repository = RIOMSRepository;
        }
        //
        // GET: /Khatas/

        public ViewResult Index()
        {
            return View(repository.Villages);
        }
        public ViewResult Search(string name)
        {
            return View(repository.GetKhataByRt(name));
        }
        public ViewResult Kisam(int vid,int kisam)
        {
            List<PlotsWithRT> plots;
            if (kisam==1)
            {
                plots = repository.GetMasaPlots(vid).OrderBy(p => Convert.ToInt32(p.KhataNo.Split('/')[0])).ToList();
            }
            else
            {
                plots = repository.GetBasaPlots(vid).OrderBy(p => Convert.ToInt32(p.KhataNo.Split('/')[0])).ToList();
            }
            return View(plots);
        }
        public ViewResult KisamNew(int vid)
        {
           
            List<KhataWithArea> khatas;
          
               // ViewBag.Title = repository.Villages.SingleOrDefault(v => v.Id == vid).Name + "Bahala";
            khatas = repository.GetKahtasWiseCultivableArea(vid).OrderBy(p => Convert.ToInt32(p.KhataNo.Split('/')[0])).ToList();
         
            return View(khatas);
        }
        public ViewResult BaSa(int vid)
        {
            return View(repository.GetBasaPlots(vid));
        }

        //public ViewResult Diaster(int vid)
        //{
        //    ViewBag.VillageName = repository.Villages.SingleOrDefault(v => v.Id == vid).Name;
        //    List<KhataWithArea> khatas;
        //    khatas = repository.GetKahtasWiseCultivableArea(vid).OrderBy(p => Convert.ToInt32(p.KhataNo.Split('/')[0])).ToList();

        //    return View(khatas);
        //}
        public ViewResult Diaster(int vid, string khataNo)
        {
             Village vil= repository.Villages.SingleOrDefault(v => v.Id == vid);
            ViewBag.VillageName =vil.Name;
            KhataWithArea khata;
            khata = repository.GetKahtaWithCultivableArea(vid,khataNo);//.OrderBy(p => Convert.ToInt32(p.KhataNo.Split('/')[0])).ToList();

            return View(khata);
        }
        public ViewResult Area(int vid)
        {
            ViewBag.VillageName = repository.Villages.SingleOrDefault(v => v.Id == vid).Name;
            return View(repository.GetKahtasWiseCultivableArea(vid));
        }
    }
}
