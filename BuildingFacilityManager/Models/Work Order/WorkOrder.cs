using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string Description { get; set; }
        public WorkOrderStatus WorkOrderStatus { get; set; }
        public DateTime? Date { get; set; }

        public WorkOrderType? WorkOrderType { get; set; }

        public Asset Asset { get; set; }
        [ForeignKey("Asset")]
        public int AssetId { get; set; }


        /*
     1-   Attachments Property
     2-   I need to add Properties of the "Reporter"
      3-  I need to add Properties of the "AssignedEmployee" in a Crew and Shift is (Day or Night) 
                       Based on the Organization Crews that match the Asset Type (Crew will have departments )
       
      4- Add Materials, Services, Tools used while doing the Work Order by the Organization

         */
    }
}