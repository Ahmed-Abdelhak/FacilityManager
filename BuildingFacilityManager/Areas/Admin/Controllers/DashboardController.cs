using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingFacilityManager.Controllers;

namespace BuildingFacilityManager.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        
    }
}
