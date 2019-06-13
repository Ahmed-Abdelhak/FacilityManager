using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingFacilityManager.Models.Assets;
using BuildingFacilityManager.Models.Work_Order;

namespace BuildingFacilityManager.ViewModels
{
    public class DashBoardViewModel
    {
        public ICollection<WorkOrder> WorkOrders { get; set; }
        public ICollection<Asset> Assets { get; set; }  
    }
}