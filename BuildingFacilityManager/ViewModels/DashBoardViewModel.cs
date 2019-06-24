using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingFacilityManager.Models;
using BuildingFacilityManager.Models.Assets;
using BuildingFacilityManager.Models.Building_Models;
using BuildingFacilityManager.Models.Purchase_Orders;
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
        public ICollection<WorkOrder> TodayWaitingPurchaseWorkOrders { get; set; }
        public ICollection<PurchaseOrder> TodayCompletedPurchaseOrders { get; set; }
        public ICollection<PurchaseOrder> AllCompletedPurchaseOrders { get; set; }
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
        public PurchaseOrder PurchaseOrder { get; set; }
        public float TotalPurchasesOrdersCost { get; set; }
        public float TodayPurchasesOrdersCost { get; set; }
        public float TotalAssetsCosts { get; set; }
        public float AssetsFurnitureCosts { get; set; }
        public float AssetsElectricalCosts { get; set; }
        public float AssetsSanitaryCosts { get; set; }
        public float AssetsElectronicsCosts { get; set; }
        public float AssetsMachinesCosts { get; set; }
        public float AssetsFireFightingCosts { get; set; }

        public ICollection<Asset> Assets { get; set; }
        public ICollection<Asset> AssetsFurniture { get; set; }
        public ICollection<Asset> AssetsElectrical { get; set; }
        public ICollection<Asset> AssetsSanitary { get; set; }
        public ICollection<Asset> AssetsElectronics { get; set; }
        public ICollection<Asset> AssetsMachines { get; set; }
        public ICollection<Asset> AssetsFireFighting { get; set; }
        public ICollection<Space> Spaces { get; set; }
        public float TotalBuildingCosts { get; set; }
        public float TodayBuildingCosts { get; set; }
        public float YesterdayBuildingCosts { get; set; }
        public int AssetHealthAffected { get; set; }
        public int AssetHealthAffectedId { get; set; }

    }
}