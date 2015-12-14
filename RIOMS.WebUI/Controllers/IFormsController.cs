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
    public class IFormsController : Controller
    {
        private IRIOMSRepository repository;

        public IFormsController(IRIOMSRepository RIOMSRepository)
        {
            this.repository = RIOMSRepository;
        }
        // GET: /IForms/
        [HttpPost]
        public ActionResult GenerateIForm(IForm iForm)
        {
            return View(new IFormViewModel(repository.GetReceiptsByIForm(iForm),iForm));
        }

        public ViewResult AnnualAbstract()
        {
            return View("GenerateIForm", new IFormViewModel(repository.GetAllReceipt(), new IForm()));
        }
        public  ViewResult index()
        {
            
            return View(new IForm());
        }
        public ViewResult Detail(string year,int iformNo )
        {
            ViewBag.Villages = repository.Villages;
            
            return View(repository.GetIform(year,iformNo));
        }
        public  ViewResult List()
        {
            ViewBag.Villages = repository.Villages;
            return View(repository.IForms);
        }
        public ViewResult Abstract(string year)
        {
            return View(repository.GetAllIForms(year));
        }
    }
}
