using System.Collections.Generic;
using BuildingFacilityManager.Models;
using BuildingFacilityManager.Models.Assets;
using BuildingFacilityManager.Models.Building_Models;
using BuildingFacilityManager.Models.Work_Order;

namespace BuildingFacilityManager.ViewModels
{
    public class AssetsViewModel
    {
        public Asset Asset { get; set; }
        public List<Asset> Assets { get; set; }
        public List<Space> Spaces { get; set; }
        public List<WorkOrder> WorkOrders { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
    }
}