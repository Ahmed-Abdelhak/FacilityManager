using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using BuildingFacilityManager.Controllers;
using BuildingFacilityManager.Models;
using BuildingFacilityManager.Models.Work_Order;
using BuildingFacilityManager.ViewModels;

namespace BuildingFacilityManager.Areas.Admin.Controllers
{
    public class WorkOrderController : AdminAuthorizationController
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

        // GET: Admin/WorkOrder
        public ActionResult Index()
        {
            var workModel = new WorkOrderViewModel()
            {
                WorkOrders = _context.WorkOrders
                    .Include(w => w.Reporter)
                    .Include(w => w.Fixer)
                    .Include(w=>w.Asset)
                    .Include(w=>w.Asset.Space)
                    .Include(w=>w.Asset.Space.Storey)
                    .ToList(),
                Assets = _context.Assets.ToList(),
                Spaces = _context.Spaces.ToList(),
                Stories = _context.Stories.ToList(),
                Users = _context.Users.ToList(),
                Fixers = _context.Users.Where(u => u.Roles.Any(r => r.RoleId == "3")).ToList()
            };
            return View(workModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignWorkOrderToFixer(WorkOrder workOrder)
        {
            var myWork = _context.WorkOrders.SingleOrDefault(w => w.Id == workOrder.Id);
            if (myWork != null && workOrder.FixerId != null) myWork.FixerId = workOrder.FixerId;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeStatusWorkOrder(WorkOrder workOrder)
        {
            var myWork = _context.WorkOrders.SingleOrDefault(w => w.Id == workOrder.Id);
            if (myWork != null && workOrder.WorkOrderStatus != 0) myWork.WorkOrderStatus = workOrder.WorkOrderStatus;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult AddWork(WorkOrder workOrder)
        {
            var workModel = new WorkOrderViewModel()
            {
                WorkOrders = _context.WorkOrders
                    .Include(w => w.Reporter)
                    .Include(w => w.Fixer)
                    .Include(w => w.Asset)
                    .Include(w => w.Asset.Space)
                    .Include(w => w.Asset.Space.Storey)
                    .ToList(),
                Assets = _context.Assets.ToList(),
                Spaces = _context.Spaces.ToList(),
                Stories = _context.Stories.ToList(),
                Fixers = _context.Users.Where(u => u.Roles.Any(r => r.RoleId == "3")).ToList()

            };

            if (workOrder.Description != null && workOrder.WorkOrderStatus != 0 && workOrder.AssetId != 0 )
            {
                _context.WorkOrders.Add(workOrder);
                _context.SaveChanges();
                var workMod = new WorkOrderViewModel()
                {
                    WorkOrders = _context.WorkOrders
                        .Include(w => w.Reporter)
                        .Include(w => w.Fixer)
                        .Include(w => w.Asset)
                        .Include(w => w.Asset.Space)
                        .Include(w => w.Asset.Space.Storey)
                        .ToList(),
                    Assets = _context.Assets.ToList(),
                    Spaces = _context.Spaces.ToList(),
                    Stories = _context.Stories.ToList(),
                    Fixers = _context.Users.Where(u => u.Roles.Any(r => r.RoleId == "3")).ToList()

                };
                return View("Index", workMod);

            }
            return View("Index",workModel);
        }

       
    }
}