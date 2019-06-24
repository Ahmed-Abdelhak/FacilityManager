using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingFacilityManager.Models;
using BuildingFacilityManager.Models.Assets.Enums;
using BuildingFacilityManager.ViewModels;

namespace BuildingFacilityManager.Areas.Admin.Controllers
{
    public class CostController : AdminAuthorizationController
    {
        private readonly ApplicationDbContext _context;

        public CostController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            var allCompletedPurchaseOrders = _context.PurchaseOrders.ToList();

            float totalPurchaseOrderCost = 0;
            foreach (var purchaseOrder in allCompletedPurchaseOrders)
            {
                totalPurchaseOrderCost += purchaseOrder.Cost;
            }



            var todayCompletedPurchaseOrders = _context.PurchaseOrders.Where(w =>
                    DbFunctions.TruncateTime(w.PurchaseDateTime)
                    == DbFunctions.TruncateTime(DateTime.Today)


                )
                .Include(w => w.WorkOrder)
                .ToList();

            float todayPurchaseOrderCost = 0;
            foreach (var purchaseOrder in todayCompletedPurchaseOrders)
            {
                todayPurchaseOrderCost += purchaseOrder.Cost;
            }

            var todayAssetsInstalled = _context.Assets.Include(a => a.Space).Where(w =>
                DbFunctions.TruncateTime(w.InstallationDate)
                == DbFunctions.TruncateTime(DateTime.Today)).ToList();

            float todayAssetsInstalledCost = 0;

            foreach (var asset in todayAssetsInstalled)
            {
                todayAssetsInstalledCost += asset.Price;
            }

            float totalAssetsCosts = 0;
            float assetsFurnitureCosts = 0;
            float assetsElectricalCosts = 0;
            float assetsSanitaryCosts = 0;
            float assetsElectronicsCosts = 0;
            float assetsMachinesCosts = 0;
            float assetsFireFightingCosts = 0;

            var assets = _context.Assets.Include(a => a.Space).ToList();
            var assetsFurniture = _context.Assets.Include(a => a.Space).Where(t=>t.AssetType == AssetType.Furniture).ToList();
            var assetsElectrical = _context.Assets.Include(a => a.Space).Where(t => t.AssetType == AssetType.Electrical).ToList();
            var assetsSanitary = _context.Assets.Include(a => a.Space).Where(t => t.AssetType == AssetType.Sanitary).ToList();
            var assetsElectronics = _context.Assets.Include(a => a.Space).Where(t => t.AssetType == AssetType.Electronics).ToList();
            var assetsMachines = _context.Assets.Include(a => a.Space).Where(t => t.AssetType == AssetType.Machines).ToList();
            var assetsFireFighting = _context.Assets.Include(a => a.Space).Where(t => t.AssetType == AssetType.FireFighting).ToList();

            foreach (var asset in assets)
            {
                totalAssetsCosts += asset.Price;
            }

            foreach (var asset in assetsFurniture)
            {
                assetsFurnitureCosts += asset.Price;
            }

            foreach (var asset in assetsElectrical)
            {
                assetsElectricalCosts += asset.Price;
            }
            foreach (var asset in assetsSanitary)
            {
                assetsSanitaryCosts += asset.Price;
            }
            foreach (var asset in assetsElectronics)
            {
                assetsElectronicsCosts += asset.Price;
            }
            foreach (var asset in assetsMachines)
            {
                assetsMachinesCosts += asset.Price;
            }
            foreach (var asset in assetsFireFighting)
            {
                assetsFireFightingCosts += asset.Price;
            }


            var todayCosts = todayAssetsInstalledCost + todayPurchaseOrderCost;
            var buildingCosts = totalAssetsCosts + totalPurchaseOrderCost;



            var model = new DashBoardViewModel()
            {
                TodayCompletedPurchaseOrders = _context.PurchaseOrders.Where(w =>
                        DbFunctions.TruncateTime(w.PurchaseDateTime)
                        == DbFunctions.TruncateTime(DateTime.Today)


                    )
                    .Include(w => w.WorkOrder)
                    .ToList(),

                AllCompletedPurchaseOrders = _context.PurchaseOrders.ToList(),
                TotalPurchasesOrdersCost = totalPurchaseOrderCost,
                TodayPurchasesOrdersCost = todayPurchaseOrderCost,
                TotalAssetsCosts = totalAssetsCosts,
                AssetsFurnitureCosts = assetsFurnitureCosts,
                AssetsElectricalCosts = assetsElectricalCosts,
                AssetsSanitaryCosts  = assetsSanitaryCosts,
                AssetsElectronicsCosts = assetsElectronicsCosts,
                AssetsMachinesCosts = assetsMachinesCosts,
                AssetsFireFightingCosts = assetsFireFightingCosts,

                Assets = assets,
                AssetsElectrical = assetsElectrical,
                AssetsElectronics = assetsElectronics,
                AssetsFireFighting = assetsFireFighting,
                AssetsFurniture = assetsFurniture,
                AssetsMachines = assetsMachines,
                AssetsSanitary = assetsSanitary,
                Spaces = _context.Spaces.ToList(),
                TotalBuildingCosts = totalAssetsCosts + totalPurchaseOrderCost,
                TodayBuildingCosts = todayAssetsInstalledCost + todayPurchaseOrderCost,
                YesterdayBuildingCosts = buildingCosts - todayCosts

            };
            return View(model);
        }
    }
}