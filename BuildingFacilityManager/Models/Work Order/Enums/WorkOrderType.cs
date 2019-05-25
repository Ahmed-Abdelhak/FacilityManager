using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildingFacilityManager.Models.Work_Order.Enums
{
    public enum WorkOrderType
    {
        Calibration = 1,
        CorrectiveMaintenance = 2,
        EmergencyMaintenance = 3,
        EventReport = 4,
        PreventiveMaintenance = 5,
        DownTime = 6,
        ServiceRequest = 7

    }
}