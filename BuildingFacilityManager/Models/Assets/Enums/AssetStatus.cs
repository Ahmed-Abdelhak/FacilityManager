using System.ComponentModel.DataAnnotations;

namespace BuildingFacilityManager.Models.Assets.Enums
{
    public enum AssetStatus 
    {
        Active = 1,
        [Display(Name = "In Maintenance")]
        InMaintenance = 2,
        Deprecated = 3
    }
}