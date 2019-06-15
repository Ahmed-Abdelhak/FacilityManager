using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingFacilityManager.Models;
using BuildingFacilityManager.Models.Building_Models;
using BuildingFacilityManager.Models.Tasks;

namespace BuildingFacilityManager.ViewModels
{
    public class TaskViewModel
    {
        public InspectionTask InspectionTask { get; set; }
        public ICollection<InspectionTask> TodayInspectionTasks { get; set; }
        public ICollection<InspectionTask> ScheduledInspectionTasks { get; set; }
        public ICollection<InspectionTask> ActiveInspectionTasks { get; set; }
        public ICollection<InspectionTask> CompletedInspectionTasks { get; set; }
        public ICollection<InspectionTask> PausedInspectionTasks { get; set; }

        public ICollection<ApplicationUser> Inspectors { get; set; }
        public ApplicationUser Inspector { get; set; }

        public ICollection<Storey> Stories { get; set; }
        public Storey Storey { get; set; }
    }
}