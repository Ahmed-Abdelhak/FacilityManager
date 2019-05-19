using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuildingFacilityManager.Models.Assets;
using BuildingFacilityManager.Models.Building_Models.Enums;

namespace BuildingFacilityManager.Models.Building_Models
{
    public class Space
    {
        public int Id { get; set; }
        [Required]
        public string Label { get; set; }
        public string Description { get; set; }
        public SpaceType SpaceType { get; set; }

        public Storey Storey { get; set; }
        [ForeignKey("Storey")]
        public int StoreyId { get; set; }

        public List<Asset> Assets { get; set; }

    }
}