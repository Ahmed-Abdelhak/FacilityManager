using System.ComponentModel.DataAnnotations;

namespace BuildingFacilityManager.Models.Assets.Enums
{
    public enum AssetType
    {
        Furniture = 1,

        Electrical = 2,

        [Display(Name = "Air Condition")]
        AirCondition = 3,

        [Display(Name = "Elevator Cabinet")]
        ElevatorCabinet = 4,
        Sanitary = 5,

        [Display(Name = "Fire Fighting")]
        FireFighting = 6,
        Electronics = 7,
        Machines = 8,
        Pipes = 9
    }
}