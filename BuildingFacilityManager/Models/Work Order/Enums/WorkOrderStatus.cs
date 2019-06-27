using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BuildingFacilityManager.Models.Work_Order.Enums
{
    public enum WorkOrderStatus
    {
        Active = 1,
        [Display(Name = "In Progress")]

        InProgress = 2,
        Completed = 3,
        [Display(Name = "Waiting Purchase")]
        WaitingPurchase = 4,
        [Display(Name = "Purchase Complete")]

        PurchaseComplete = 5,

    }

}