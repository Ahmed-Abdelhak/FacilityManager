using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuildingFacilityManager.Models.Assets;
using BuildingFacilityManager.Models.Building_Models.Enums;
using BuildingFacilityManager.Models.Tasks;
using Newtonsoft.Json;

namespace BuildingFacilityManager.Models.Building_Models
{
    public class Space
    {
        public int Id { get; set; }
        [Required]
        public string Label { get; set; }
        [JsonIgnore]
        public string Description { get; set; }
        public SpaceType SpaceType { get; set; }
        [JsonIgnore]
        public Storey Storey { get; set; }
        [ForeignKey("Storey")]
        public int StoreyId { get; set; }
        [JsonIgnore]
        public List<Asset> Assets { get; set; }


        public float? PositionX { get; set; }
        public float? PositionY { get; set; }
        public float? Width { get; set; }
        public float? Length { get; set; }
        public float? WallsHeight { get; set; }
       
    }
}