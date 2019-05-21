using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuildingFacilityManager.Models.Assets.Enums;
using BuildingFacilityManager.Models.Building_Models;
using BuildingFacilityManager.Models.Work_Order;

namespace BuildingFacilityManager.Models.Assets
{
    public class Asset
    {
        public int Id { get; set; }
        [Required]
        public string Label { get; set; }
        public AssetType AssetType { get; set; }
        public AssetStatus AssetStatus { get; set; }
        public Space Space { get; set; }
        [ForeignKey("Space")]
        public int SpaceId { get; set; }

        public string Vendor { get; set; }
        public DateTime? InstallationDate { get; set; }
        public DateTime? ManufacturedDate { get; set; }
        public float Price { get; set; }
        public string Warranty { get; set; }

        public virtual ICollection<Asset> RelatedAssets { get; set; }

        public Asset RelatedAsset { get; set; }

        [ForeignKey("RelatedAsset")]
        public int? Fk_AssetId { get; set; }

        public List<WorkOrder> WorkOrders { get; set; }
    }
}