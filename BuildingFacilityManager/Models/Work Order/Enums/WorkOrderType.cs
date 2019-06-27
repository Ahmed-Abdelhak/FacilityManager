using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuildingFacilityManager.Models.Work_Order.Enums
{
    public enum WorkOrderType
    {
        Calibration = 1,

        [Display(Name = "Corrective Maintenance")]
        CorrectiveMaintenance = 2,

        [Display(Name = "Emergency Maintenance")]
        EmergencyMaintenance = 3,

        [Display(Name = "Event Report")]
        EventReport = 4,

        [Display(Name = "Preventive Maintenance")]
        PreventiveMaintenance = 5,

        DownTime = 6,

        [Display(Name = "Service Request")]
        ServiceRequest = 7,

        [Display(Name = "General Maintenance")]
        GeneralMaintenance = 8

    }
}