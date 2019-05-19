using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BuildingFacilityManager.Models.Assets;
using BuildingFacilityManager.Models.Work_Order.Enums;

namespace BuildingFacilityManager.Models.Work_Order
{
    public class WorkOrder
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public WorkOrderStatus WorkOrderStatus { get; set; }

        public Asset Asset { get; set; }
        [ForeignKey("Asset")]
        public int AssetId { get; set; }
    }
}