using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingFacilityManager.Controllers;

namespace BuildingFacilityManager.Areas.Inspector.Controllers
{
    public class DashboardController : BaseController
    {
        // GET: Inspector/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}