using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuildingFacilityManager.Models.Tasks;
using Newtonsoft.Json;

namespace BuildingFacilityManager.Models.Building_Models
{
    public class Storey
    {
        public int Id { get; set; }
        [Required]
        public string Label { get; set; }
        [JsonIgnore]
        public string Description { get; set; }
        [JsonIgnore]
        public Building Building { get; set; }
        [ForeignKey("Building")]
        [JsonIgnore]
        public int BuildingId { get; set; }

        [Required]
        public float Width { get; set; }
        [Required]
        public float Length { get; set; }
        [Required]
        public float Level { get; set; }

        [JsonIgnore]
        public List<Space> Spaces { get; set; }
        [JsonIgnore]
        public ICollection<InspectionTask> InspectionTasks { get; set; }    
    }
}