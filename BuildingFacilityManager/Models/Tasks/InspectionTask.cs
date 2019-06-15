using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BuildingFacilityManager.Models.Building_Models;
using BuildingFacilityManager.Models.Tasks.Enums;

namespace BuildingFacilityManager.Models.Tasks
{
    public class InspectionTask
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }

        public ApplicationUser Inspector { get; set; }

        [ForeignKey("Inspector")]
        public string InspectorId { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
       

        public InspectionStatus? InspectionStatus { get; set; }
        public PeriodicInspection? PeriodicInspection { get; set; }
        public InspectionType? InspectionType { get; set; }

        public Storey StoreyInspection { get; set; }
        [ForeignKey("StoreyInspection")]
        [Display(Name = "Location")]
        public int? StoreyInspectionId { get; set; }


        /*  This is for Emergency Assets like the Elevator and Plumping ... etc  */
        // public SpecialAsset SpecialAsset { get; set;} 



    }
}