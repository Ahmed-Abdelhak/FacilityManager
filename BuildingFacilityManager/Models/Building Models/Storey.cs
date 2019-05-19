using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingFacilityManager.Models.Building_Models
{
    public class Storey
    {
        public int Id { get; set; }
        [Required]
        public string Label { get; set; }
        public string Description { get; set; }
        public Building Building { get; set; }
        [ForeignKey("Building")]
        public int BuildingId { get; set; }

        public List<Space> Spaces { get; set; }
    }
}