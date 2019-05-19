using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuildingFacilityManager.Models.Building_Models
{
    public class Building
    {
        //General Data
        public int Id { get; set; }
        [Required]
        public string Label { get; set; }
        public string Description { get; set; }

        public List<Storey> Stories { get; set; }
    }
}