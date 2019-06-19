using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingFacilityManager.Models.Assets;
using BuildingFacilityManager.Models.Building_Models;

namespace BuildingFacilityManager.ViewModels
{
    public class BuildingViewerViewModel
    {
        public List<Storey> Stories { get; set; }
        public List<Space> Spaces { get; set; }
        public List<Asset> Assets { get; set; }  
    }
}