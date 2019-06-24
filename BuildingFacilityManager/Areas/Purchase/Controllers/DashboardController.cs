using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingFacilityManager.Models;
using BuildingFacilityManager.Models.Purchase_Orders;
using BuildingFacilityManager.Models.Work_Order;
using BuildingFacilityManager.Models.Work_Order.Enums;
using BuildingFacilityManager.ViewModels;
using Microsoft.AspNet.Identity;

namespace BuildingFacilityManager.Areas.Purchase.Controllers
{
    public class DashboardController : PurchaseAuthorizationController
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

                TodayWaitingPurchaseWorkOrders = _context.WorkOrders.Where(w =>
                        DbFunctions.TruncateTime(w.Date)
                        == DbFunctions.TruncateTime(DateTime.Today)

                        &&

                        w.WorkOrderStatus == WorkOrderStatus.WaitingPurchase

                    )
                    .Include(w => w.Asset)
                    .Include(w => w.Asset.Space)
                    .Include(w => w.Asset.Space.Storey).ToList(),

                TodayCompletedPurchaseOrders = _context.PurchaseOrders.Where(w =>
                        DbFunctions.TruncateTime(w.PurchaseDateTime)
                        == DbFunctions.TruncateTime(DateTime.Today)


                    )
                    .Include(w => w.WorkOrder)
                   .ToList(),
            };

            return View(model);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            if (purchaseOrder.WorkOrderId != 0 && purchaseOrder.Description != null
                                                   && purchaseOrder.Cost != 0
                                                   && purchaseOrder.PurchaseDateTime != null)
            {
                _context.PurchaseOrders.Add(purchaseOrder);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");

        }
    }
}
