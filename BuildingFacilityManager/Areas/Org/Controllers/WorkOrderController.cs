using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingFacilityManager.Controllers;
using BuildingFacilityManager.Models;
using BuildingFacilityManager.ViewModels;

namespace BuildingFacilityManager.Areas.Org.Controllers
{
    public class WorkOrderController : OrgAuthorizationController
    {
        private readonly ApplicationDbContext _context;

        public WorkOrderController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();

        }

        // GET: Org/WorkOrder
        public ActionResult Index()
        {
            var workModel = new WorkOrderViewModel()
            {
                WorkOrders = _context.WorkOrders.Include(w => w.Asset)
                    .Include(w => w.Asset.Space)
                    .Include(w => w.Asset.Space.Storey)
                    .ToList(),
                Assets = _context.Assets.ToList(),
                Spaces = _context.Spaces.ToList()
            };
            return View(workModel);
        }

        public ActionResult CompleteOrder()
        {
            throw new NotImplementedException();
        }
    }
}