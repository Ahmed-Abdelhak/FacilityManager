using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingFacilityManager.Models.Building_Models;

namespace BuildingFacilityManager.ViewModels
{
    public class BuildingTreeViewModel
    {
        public List<Space> Spaces { get; set; }
        public List<Storey> Stories { get; set; }
        public Storey Storey { get; set; }

    }
}