using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingFacilityManager.Controllers;
using BuildingFacilityManager.Models;

namespace BuildingFacilityManager.Areas.Org.Controllers
{
    [Authorize(Roles = SystemRoles.Fixer)]

    public class OrgAuthorizationController : BaseController
    {
    }
}