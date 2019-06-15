using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingFacilityManager.Models;
using BuildingFacilityManager.Models.Tasks;
using BuildingFacilityManager.Models.Tasks.Enums;
using BuildingFacilityManager.ViewModels;

namespace BuildingFacilityManager.Areas.Admin.Controllers
{
    public class TaskController : AdminAuthorizationController
    {
        private readonly ApplicationDbContext _context;

        public TaskController()
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

            var taskModel = new TaskViewModel()
            {
                TodayInspectionTasks = _context.InspectionTasks
                    .Where(t =>
                         DbFunctions.TruncateTime(t.StartDate)
                            == DbFunctions.TruncateTime(today)
                                //t => t.StartDate >= today && t.StartDate < tomorrow
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

                    .Include(t => t.Inspector)
                    .Include(t => t.StoreyInspection)
                    .ToList(),

                ScheduledInspectionTasks = _context.InspectionTasks
                    .Where(t => t.StartDate >= tomorrow)
                    .Include(t => t.Inspector)
                    .Include(t => t.StoreyInspection)
                    .ToList(),

                PausedInspectionTasks = _context.InspectionTasks
                    .Where(t => t.InspectionStatus == InspectionStatus.Paused)
                    .Include(t => t.Inspector)
                    .Include(t => t.StoreyInspection)
                    .ToList(),

                CompletedInspectionTasks = _context.InspectionTasks
                    .Where(t => t.InspectionStatus == InspectionStatus.Completed)
                    .Include(t => t.Inspector)
                    .Include(t => t.StoreyInspection)
                    .ToList(),

                Inspectors = _context.Users.Where(u => u.Roles.Any(r => r.RoleId == "2")).ToList(),

                Stories = _context.Stories.ToList()

            };

            return View(taskModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddInspectionTask(InspectionTask inspectionTask)
        {
            if (inspectionTask.InspectorId != null && inspectionTask.Description != null
                                                   && inspectionTask.InspectionStatus != 0
                                                   && inspectionTask.StartDate != null)
            {
                _context.InspectionTasks.Add(inspectionTask);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeInspectionTaskStatus(InspectionTask inspectionTask)
        {
            var mytask = _context.InspectionTasks.SingleOrDefault(w => w.Id == inspectionTask.Id);
            if (mytask != null && inspectionTask.InspectionStatus != 0) mytask.InspectionStatus = inspectionTask.InspectionStatus;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}