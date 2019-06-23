using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingFacilityManager.Controllers;
using BuildingFacilityManager.Models;
using BuildingFacilityManager.Models.Work_Order;
using BuildingFacilityManager.ViewModels;
using Microsoft.AspNet.Identity;

namespace BuildingFacilityManager.Areas.Org.Controllers
{
    public class DashboardController : OrgAuthorizationController
    {
        private readonly ApplicationDbContext _context;

        public DashboardController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var today = DateTime.Today;
            var todayLastWeek = today.AddDays(-7);
            //var todayLastWeek = today.(-7);
            var tomorrow = today.AddDays(1);
            var yesterday = today.AddDays(-1);
            var userId = User.Identity.GetUserId();


            var model = new DashBoardViewModel()
            {
                DashBoardUsers = _context.Users.ToList(),
                MyAssignedWorkOrdersToday = _context.WorkOrders.Where(w => w.FixerId == userId &&
                      DbFunctions.TruncateTime(w.Date)
                     == DbFunctions.TruncateTime(today))
                    .Include(w => w.Asset)
                    .Include(w => w.Asset.Space)
                    .Include(w => w.Asset.Space.Storey)
                    .ToList(),

                MyAssignedWorkOrdersTotal = _context.WorkOrders.Where(w => w.FixerId == userId)
                    .Include(w => w.Asset)
                    .Include(w => w.Asset.Space)
                    .Include(w => w.Asset.Space.Storey)
                    .ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeStatusWorkOrder(WorkOrder workOrder)
        {
            var myWork = _context.WorkOrders.SingleOrDefault(w => w.Id == workOrder.Id);
            if (myWork != null && workOrder.WorkOrderStatus != 0) myWork.WorkOrderStatus = workOrder.WorkOrderStatus;
            if (myWork != null && workOrder.FixerNotes != null) myWork.FixerNotes = workOrder.FixerNotes;

            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PurchaseRequest(WorkOrder workOrder)
        {
            var myWork = _context.WorkOrders.SingleOrDefault(w => w.Id == workOrder.Id);
            if (myWork != null && workOrder.WorkOrderStatus != 0) myWork.WorkOrderStatus = workOrder.WorkOrderStatus;
            if (myWork != null && workOrder.PurchaseRequestNotes != null) myWork.PurchaseRequestNotes = workOrder.PurchaseRequestNotes;

            _context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}