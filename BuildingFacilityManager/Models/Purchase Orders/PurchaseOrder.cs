using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BuildingFacilityManager.Models.Work_Order;

namespace BuildingFacilityManager.Models.Purchase_Orders
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Cost { get; set; }
        public WorkOrder WorkOrder { get; set; }
        [ForeignKey("WorkOrder")]
        public int WorkOrderId { get; set; }

        public DateTime? PurchaseDateTime { get; set; }
    }
}