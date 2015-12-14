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
    public class SadarSihaController : Controller
    {
        private IRIOMSRepository repository;

        public SadarSihaController(IRIOMSRepository RIOMSRepository)
        {
            this.repository = RIOMSRepository;
        }
        // GET: /SadarSiha/

        public ViewResult Index(string year, int iformNo)
        {
            ReceiptViewModel viewModel = new ReceiptViewModel(repository.GetReceiptsByIForm(new IForm() { IFormNo = iformNo, Year = year }));
            return View(viewModel);
        }
        public ViewResult Abstract(string year)
        {
            ViewBag.Year = year;
            return View(repository.GetAllIForms(year));
        }
    }
}
