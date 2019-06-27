using System.ComponentModel.DataAnnotations;

namespace BuildingFacilityManager.Models.Tasks.Enums
{
    public enum InspectionStatus
    {
        Active = 1,
        Paused = 2,
        Completed = 3,
        [Display(Name = "Partially Completed")]
        PartiallyCompleted = 4
    }
}