using Newtonsoft.Json;
using RIOMS.Domain.Abstract;
using RIOMS.WebUI.Extensions;
using System.Linq;
using System.Web.Mvc;

namespace RIOMS.WebUI.Controllers
{
    public class RORController : Controller
    {
        private IRIOMSRepository repository;

        public RORController(IRIOMSRepository RIOMSRepository)

        {
            this.repository = RIOMSRepository;
        }

        public ViewResult Index()
        {
            ViewBag.Villages = new SelectList(repository.Villages.Where(v => v.RICircleId == Util.Util.RICId), "Id", "Name");
            return View();
        }

        [HttpGet]
        public JsonResult GetRoR(string khataNo, int villageId)
        {
            JsonNetResult jsonNetResult = new JsonNetResult();
            jsonNetResult.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            jsonNetResult.Data = repository.GetKhata(khataNo, villageId);
            return jsonNetResult;
        }

        [HttpGet]
        public ViewResult RTList()
        {
            ViewBag.Villages = new SelectList(repository.Villages.Where(v => v.RICircleId == Util.Util.RICId), "Id", "Name");
            return View();
        }

        [HttpGet]
        public JsonResult GetRTList(int villageId)
        {
            JsonNetResult jsonNetResult = new JsonNetResult();
            jsonNetResult.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            jsonNetResult.Data = repository.GetKhatas(villageId);
            return jsonNetResult;
        }
    }
}