using System.Web.Mvc;
using BuildingFacilityManager.Controllers;
using BuildingFacilityManager.Models;

namespace BuildingFacilityManager.Areas.Purchase.Controllers
{
    [Authorize(Roles = SystemRoles.Purchase)]

    public class PurchaseAuthorizationController : BaseController
    {
    }
}