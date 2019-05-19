using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingFacilityManager.Areas.Inspector.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Inspector/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}