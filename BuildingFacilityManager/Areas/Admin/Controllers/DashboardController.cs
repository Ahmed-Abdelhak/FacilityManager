using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using BuildingFacilityManager.Controllers;
using BuildingFacilityManager.Models;
using BuildingFacilityManager.Models.Tasks.Enums;
using BuildingFacilityManager.Models.Work_Order.Enums;
using BuildingFacilityManager.ViewModels;

namespace BuildingFacilityManager.Areas.Admin.Controllers
{
    public class DashboardController : AdminAuthorizationController
    {
        private readonly ApplicationDbContext _context;


        public DashboardController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }


        public ActionResult Index()
        {
            var today = DateTime.Today;
            var todayLastWeek = today.AddDays(-7);
            //var todayLastWeek = today.(-7);
            var tomorrow = today.AddDays(1);
            var yesterday = today.AddDays(-1);

            var model = new DashBoardViewModel()
            {
                WorkOrders = _context.WorkOrders.Where(w=>
                        DbFunctions.TruncateTime(w.Date)
                        == DbFunctions.TruncateTime(DateTime.Today)

                             //w => w.Date >= DateTime.Today

                             )
                   .Include(w => w.Asset)
                   .Include(w => w.Asset.Space)
                   .Include(w => w.Asset.Space.Storey).ToList(),

                TodayActiveWorkOrders = _context.WorkOrders.Where(w =>
                DbFunctions.TruncateTime(w.Date)
                == DbFunctions.TruncateTime(DateTime.Today)

                &&

                w.WorkOrderStatus == WorkOrderStatus.Active

                )
                .Include(w => w.Asset)
                .Include(w => w.Asset.Space)
                .Include(w => w.Asset.Space.Storey).ToList(),

                TodayCompletedWorkOrders = _context.WorkOrders.Where(w =>
                DbFunctions.TruncateTime(w.Date)
                == DbFunctions.TruncateTime(DateTime.Today)

                &&

                w.WorkOrderStatus == WorkOrderStatus.Completed

                )
                .Include(w => w.Asset)
                .Include(w => w.Asset.Space)
                .Include(w => w.Asset.Space.Storey).ToList(),


                TodayInProgressWorkOrders = _context.WorkOrders.Where(w =>
                        DbFunctions.TruncateTime(w.Date)
                        == DbFunctions.TruncateTime(DateTime.Today)

                        &&

                        w.WorkOrderStatus == WorkOrderStatus.In_Progress

                    )
                    .Include(w => w.Asset)
                    .Include(w => w.Asset.Space)
                    .Include(w => w.Asset.Space.Storey).ToList(),

                TodayInstalledAssets = _context.Assets.Where(a =>
                            DbFunctions.TruncateTime(a.InstallationDate)
                            == DbFunctions.TruncateTime(DateTime.Today)
                        )


                    .Include(a => a.Space)
                    .Include(a => a.RelatedAssets)
                    .ToList(),
                DashBoardUsers = _context.Users.ToList(),
               TodayInspectionTasks = _context.InspectionTasks
                    .Where(t =>
                        DbFunctions.TruncateTime(t.StartDate)
                        == DbFunctions.TruncateTime(today) 
                        ||
                        DbFunctions.TruncateTime(today)
                        <= DbFunctions.TruncateTime(t.EndDate) &&
                        DbFunctions.TruncateTime(today)
                        >= DbFunctions.TruncateTime(t.StartDate)
                        /*  today <= t.EndDate && today >= t.StartDate */
                        && t.PeriodicInspection == PeriodicInspection.Daily
                       

                        ||

                        // Stupid Code starts from Here !

                        today.Day == (t.StartDate.Value.Day + 7) && today <= t.EndDate && t.PeriodicInspection == PeriodicInspection.Weekly
                       
                        ||
                        today.Day == (t.StartDate.Value.Day + 14) && today <= t.EndDate && t.PeriodicInspection == PeriodicInspection.Weekly
                       
                        ||
                        today.Day == (t.StartDate.Value.Day + 21) && today <= t.EndDate && t.PeriodicInspection == PeriodicInspection.Weekly
                     
                        ||
                        today.Day == (t.StartDate.Value.Day + 28) && today <= t.EndDate && t.PeriodicInspection == PeriodicInspection.Weekly
                       
                    )

                    .Include(t => t.StoreyInspection)
                    .ToList(),
                TodayInspectionTasksActive  = _context.InspectionTasks
                .Where(t =>
                DbFunctions.TruncateTime(t.StartDate)
                == DbFunctions.TruncateTime(today) && t.InspectionStatus == InspectionStatus.Active
                ||
                DbFunctions.TruncateTime(today)
                <= DbFunctions.TruncateTime(t.EndDate) &&
                DbFunctions.TruncateTime(today)
                >= DbFunctions.TruncateTime(t.StartDate)
                /*  today <= t.EndDate && today >= t.StartDate */
                && t.PeriodicInspection == PeriodicInspection.Daily
                && t.InspectionStatus == InspectionStatus.Active

                ||

                // Stupid Code starts from Here !

                today.Day == (t.StartDate.Value.Day + 7) && today <= t.EndDate && t.PeriodicInspection == PeriodicInspection.Weekly
                && t.InspectionStatus == InspectionStatus.Active
                ||
                today.Day == (t.StartDate.Value.Day + 14) && today <= t.EndDate && t.PeriodicInspection == PeriodicInspection.Weekly
                && t.InspectionStatus == InspectionStatus.Active
                ||
                today.Day == (t.StartDate.Value.Day + 21) && today <= t.EndDate && t.PeriodicInspection == PeriodicInspection.Weekly
                && t.InspectionStatus == InspectionStatus.Active
                ||
                today.Day == (t.StartDate.Value.Day + 28) && today <= t.EndDate && t.PeriodicInspection == PeriodicInspection.Weekly
                && t.InspectionStatus == InspectionStatus.Active
                )

                .Include(t => t.StoreyInspection)
                .ToList(),

                TodayInspectionTasksCompleted = _context.InspectionTasks
                    .Where(t =>
                        DbFunctions.TruncateTime(t.StartDate)
                        == DbFunctions.TruncateTime(today) && t.InspectionStatus == InspectionStatus.Completed
                        ||
                        DbFunctions.TruncateTime(today)
                        <= DbFunctions.TruncateTime(t.EndDate) &&
                        DbFunctions.TruncateTime(today)
                        >= DbFunctions.TruncateTime(t.StartDate)
                        /*  today <= t.EndDate && today >= t.StartDate */
                        && t.PeriodicInspection == PeriodicInspection.Daily
                        && t.InspectionStatus == InspectionStatus.Completed

                        ||

                        // Stupid Code starts from Here !

                        today.Day == (t.StartDate.Value.Day + 7) && today <= t.EndDate && t.PeriodicInspection == PeriodicInspection.Weekly
                        && t.InspectionStatus == InspectionStatus.Completed
                        ||
                        today.Day == (t.StartDate.Value.Day + 14) && today <= t.EndDate && t.PeriodicInspection == PeriodicInspection.Weekly
                        && t.InspectionStatus == InspectionStatus.Completed
                        ||
                        today.Day == (t.StartDate.Value.Day + 21) && today <= t.EndDate && t.PeriodicInspection == PeriodicInspection.Weekly
                        && t.InspectionStatus == InspectionStatus.Completed
                        ||
                        today.Day == (t.StartDate.Value.Day + 28) && today <= t.EndDate && t.PeriodicInspection == PeriodicInspection.Weekly
                        && t.InspectionStatus == InspectionStatus.Completed
                    )

                    .Include(t => t.StoreyInspection)
                    .ToList(),
                TodayInspectionTasksPartiallyCompleted = _context.InspectionTasks
                    .Where(t =>
                        DbFunctions.TruncateTime(t.StartDate)
                        == DbFunctions.TruncateTime(today) && t.InspectionStatus == InspectionStatus.PartiallyCompleted
                        ||
                        DbFunctions.TruncateTime(today)
                        <= DbFunctions.TruncateTime(t.EndDate) &&
                        DbFunctions.TruncateTime(today)
                        >= DbFunctions.TruncateTime(t.StartDate)
                        /*  today <= t.EndDate && today >= t.StartDate */
                        && t.PeriodicInspection == PeriodicInspection.Daily
                        && t.InspectionStatus == InspectionStatus.PartiallyCompleted

                        ||

                        // Stupid Code starts from Here !

                        today.Day == (t.StartDate.Value.Day + 7) && today <= t.EndDate && t.PeriodicInspection == PeriodicInspection.Weekly
                        && t.InspectionStatus == InspectionStatus.PartiallyCompleted
                        ||
                        today.Day == (t.StartDate.Value.Day + 14) && today <= t.EndDate && t.PeriodicInspection == PeriodicInspection.Weekly
                        && t.InspectionStatus == InspectionStatus.PartiallyCompleted
                        ||
                        today.Day == (t.StartDate.Value.Day + 21) && today <= t.EndDate && t.PeriodicInspection == PeriodicInspection.Weekly
                        && t.InspectionStatus == InspectionStatus.PartiallyCompleted
                        ||
                        today.Day == (t.StartDate.Value.Day + 28) && today <= t.EndDate && t.PeriodicInspection == PeriodicInspection.Weekly
                        && t.InspectionStatus == InspectionStatus.PartiallyCompleted
                    )

                    .Include(t => t.StoreyInspection)
                    .ToList(),
            };
            return View(model);
        }


      
    }
}
