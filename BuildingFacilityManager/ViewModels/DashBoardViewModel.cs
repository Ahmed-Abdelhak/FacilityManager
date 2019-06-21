using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingFacilityManager.Models;
using BuildingFacilityManager.Models.Assets;
using BuildingFacilityManager.Models.Tasks;
using BuildingFacilityManager.Models.Work_Order;

namespace BuildingFacilityManager.ViewModels
{
    public class DashBoardViewModel
    {
        public ICollection<WorkOrder> WorkOrders { get; set; }
        public ICollection<WorkOrder> TodayCompletedWorkOrders { get; set; }
        public ICollection<WorkOrder> TodayActiveWorkOrders { get; set; }
        public ICollection<WorkOrder> TodayInProgressWorkOrders { get; set; }
        public ICollection<WorkOrder> MyCreatedWorkOrdersToday { get; set; }
        public ICollection<Asset> TodayInstalledAssets { get; set; }

        public ICollection<InspectionTask> TodayInspectionTasks { get; set; }
        public ICollection<InspectionTask> TodayInspectionTasksActive { get; set; }
        public ICollection<InspectionTask> TodayInspectionTasksCompleted { get; set; }
        public ICollection<InspectionTask> TodayInspectionTasksPartiallyCompleted { get; set; }
        public ICollection<InspectionTask> ScheduledInspectionTasks { get; set; }
        public InspectionTask InspectionTask { get; set; }
        public ICollection<ApplicationUser> DashBoardUsers { get; set; }
        public ICollection<WorkOrder> MyAssignedWorkOrdersToday { get; set; }
        public ICollection<WorkOrder> MyAssignedWorkOrdersTotal { get; set; }
        public WorkOrder WorkOrder { get; set; }
    }
}