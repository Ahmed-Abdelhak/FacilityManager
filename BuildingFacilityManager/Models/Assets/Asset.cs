using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuildingFacilityManager.Models.Assets.Enums;
using BuildingFacilityManager.Models.Building_Models;
using BuildingFacilityManager.Models.Work_Order;
using Newtonsoft.Json;

namespace BuildingFacilityManager.Models.Assets
{
    public class Asset
    {
        public int Id { get; set; }
        [Required]
        public string Label { get; set; }
        [JsonIgnore]
        public AssetType AssetType { get; set; }
        [JsonIgnore]
        public AssetStatus AssetStatus { get; set; }
        [JsonIgnore]
        public Space Space { get; set; }
        [ForeignKey("Space")]
        public int SpaceId { get; set; }
        [JsonIgnore]
        public string Vendor { get; set; }
        [JsonIgnore]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyy}", ApplyFormatInEditMode = true)]
        public DateTime? InstallationDate { get; set; }


        [JsonIgnore]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyy}", ApplyFormatInEditMode = true)]
        public DateTime? ManufacturedDate { get; set; }

        [JsonIgnore]
        public float Price { get; set; }

        [JsonIgnore]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyy}", ApplyFormatInEditMode = true)]
        public DateTime? PurchaseDate { get; set; }
        [JsonIgnore]
        public string Warranty { get; set; }

        [JsonIgnore]
        public string ExpectedLife { get; set; }


        [JsonIgnore]
        public virtual ICollection<Asset> RelatedAssets { get; set; }
        [JsonIgnore]
        public Asset RelatedAsset { get; set; }
        [JsonIgnore]
        [ForeignKey("RelatedAsset")]
        public int? Fk_AssetId { get; set; }
        [JsonIgnore]
        public List<WorkOrder> WorkOrders { get; set; }

        // specifications as PDF attachement

    }
}