using System.ComponentModel.DataAnnotations;

namespace BuildingFacilityManager.Models.Tasks.Enums
{
    public enum InspectionType
    {
        [Display(Name = "Location Inspection")]
        LocationInspection = 1,

        [Display(Name = "Generator Inspection")]
        GeneratorInspection = 2,

        [Display(Name = "Pump Inspection")]
        PumpInspection = 3,

        [Display(Name = "FireFighting Inspection")]
            FireFightingInspection = 4,

        [Display(Name = "AirConditioning Inspection")]
            AirConditioningInspection = 5

    }
}