using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingFacilityManager.Controllers;
using BuildingFacilityManager.Models;
using BuildingFacilityManager.Models.Tasks.Enums;
using BuildingFacilityManager.Models.Work_Order.Enums;
using BuildingFacilityManager.ViewModels;
using Microsoft.AspNet.Identity;

namespace BuildingFacilityManager.Areas.Inspector.Controllers
{
    public class DashboardController : InspectorAuthorizationController
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
            var userId = User.Identity.GetUserId();

            var model = new DashBoardViewModel()
            {

                TodayInspectionTasks =  _context.InspectionTasks
                    .Where(t =>
                        DbFunctions.TruncateTime(t.StartDate)
                        == DbFunctions.TruncateTime(today) && userId  == t.InspectorId
                        //t => t.StartDate >= today && t.StartDate < tomorrow
                        ||
                        DbFunctions.TruncateTime(today)
                        <= DbFunctions.TruncateTime(t.EndDate) &&
                        DbFunctions.TruncateTime(today)
                        >= DbFunctions.TruncateTime(t.StartDate)
                        /*  today <= t.EndDate && today >= t.StartDate */
                        && t.PeriodicInspection == PeriodicInspection.Daily
                        && userId == t.InspectorId

                        ||

                        // Stupid Code starts from Here !

                        today.Day == (t.StartDate.Value.Day + 7) && today <= t.EndDate && t.PeriodicInspection == PeriodicInspection.Weekly
                        && userId == t.InspectorId
                        ||
                        today.Day == (t.StartDate.Value.Day + 14) && today <= t.EndDate && t.PeriodicInspection == PeriodicInspection.Weekly
                        && userId == t.InspectorId
                        ||
                        today.Day == (t.StartDate.Value.Day + 21) && today <= t.EndDate && t.PeriodicInspection == PeriodicInspection.Weekly
                        && userId == t.InspectorId
                        ||
                        today.Day == (t.StartDate.Value.Day + 28) && today <= t.EndDate && t.PeriodicInspection == PeriodicInspection.Weekly
                        && userId == t.InspectorId
                        )

                    .Include(t => t.StoreyInspection)
                    .ToList(),
                ScheduledInspectionTasks = _context.InspectionTasks
                    .Where(t => t.StartDate >= tomorrow && userId == t.InspectorId)
                    .Include(t => t.Inspector)
                    .Include(t => t.StoreyInspection)
                    .ToList(),
                MyCreatedWorkOrdersToday = _context.WorkOrders.Where(w=>w.ReporterId == userId && 
                                                                        DbFunctions.TruncateTime(w.Date)
                                                                        == DbFunctions.TruncateTime(today))
                    .Include(w => w.Reporter)
                    .Include(w => w.Fixer)
                    .Include(w => w.Asset)
                    .Include(w => w.Asset.Space)
                    .Include(w => w.Asset.Space.Storey)
                    .ToList(),
                DashBoardUsers = _context.Users.ToList(),
                
                
            };
            return View(model);
        }

    }
}