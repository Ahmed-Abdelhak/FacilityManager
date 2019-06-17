using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingFacilityManager.Controllers;
using BuildingFacilityManager.Models;

namespace BuildingFacilityManager.Areas.Inspector.Controllers
{
    [Authorize(Roles = SystemRoles.Inspector)]

    public class InspectorAuthorizationController : BaseController
    {
    }
}