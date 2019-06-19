using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingFacilityManager.Models;
using BuildingFacilityManager.Models.Tasks;

namespace BuildingFacilityManager.Areas.Inspector.Controllers
{
    public class TaskController : InspectorAuthorizationController
    {
        private readonly ApplicationDbContext _context;

        public TaskController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangeInspectionTaskStatus(InspectionTask inspectionTask)
        {
            var mytask = _context.InspectionTasks.SingleOrDefault(w => w.Id == inspectionTask.Id);
            if (mytask != null && inspectionTask.InspectionStatus != 0) mytask.InspectionStatus = inspectionTask.InspectionStatus;
            if (mytask != null && inspectionTask.InspectionNotes != null) mytask.InspectionNotes = inspectionTask.InspectionNotes;


            _context.SaveChanges();
            return RedirectToAction("Index","Dashboard");
        }
    }
}