using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingFacilityManager.Models.Building_Models;

namespace BuildingFacilityManager.ViewModels
{
    public class BuildingViewModel
    {
        public List<Building> Buildings { get; set; }
        public List<Storey> Stories { get; set; }
        public Storey Storey { get; set; }
        public Building Building { get; set; }
        public Space Space { get; set; }
        public List<Space> Spaces { get; set; }
    }
}