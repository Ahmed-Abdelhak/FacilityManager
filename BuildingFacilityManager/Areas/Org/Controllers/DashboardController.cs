using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingFacilityManager.Controllers;

namespace BuildingFacilityManager.Areas.Org.Controllers
{
    public class DashboardController : BaseController
    {
        // GET: Org/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}