using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BuildingFacilityManager.Models.Assets;
using BuildingFacilityManager.Models.Purchase_Orders;
using BuildingFacilityManager.Models.Work_Order.Enums;

namespace BuildingFacilityManager.Models.Work_Order
{
    public class WorkOrder
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public WorkOrderStatus WorkOrderStatus { get; set; }
        public DateTime? Date { get; set; }

        public WorkOrderType? WorkOrderType { get; set; }

        public Asset Asset { get; set; }
        [ForeignKey("Asset")]
        public int AssetId { get; set; }


        public ApplicationUser Reporter { get; set; }
        [ForeignKey("Reporter")]
        public string ReporterId { get; set; }


        public ApplicationUser Fixer { get; set; }
        [ForeignKey("Fixer")]
        public string FixerId { get; set; }

        public string FixerNotes { get; set; }
        public string PurchaseRequestNotes { get; set; }

        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }


        /*
     1-   Attachments Property
     
         */


        /*
         
        1- Run end 2 end Tests
           2- New Rule (Fixer Manager)
           3- Assign of Work Orders to a Fixer is based on the department ( Type of Asset )
           4- Assign of Work Orders is based on Availability and Shift type ( Night or Today ) 
           5- Split the Work Order to ( Internal Tasks , Associate Materials, Tools and Services )
           
           

         */
    }
}