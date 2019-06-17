using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingFacilityManager.Controllers;
using BuildingFacilityManager.Models;
using BuildingFacilityManager.Models.Assets;
using BuildingFacilityManager.Models.Work_Order;
using BuildingFacilityManager.ViewModels;

namespace BuildingFacilityManager.Areas.Inspector.Controllers
{
    public class AssetController : InspectorAuthorizationController
    {
        private readonly ApplicationDbContext _context;

        public AssetController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        // GET: Inspector/Asset
        public ActionResult Index()
        {
            var assetModel = new AssetsViewModel()
            {
                Assets = _context.Assets.Include(a => a.Space).Include(a => a.RelatedAssets).ToList(),
                Spaces = _context.Spaces.ToList()
            };
            return View(assetModel);
        }

        [HttpGet]
        public ActionResult AssetsWorkOrders(int id)
        {
            var myAsset = _context.Assets.SingleOrDefault(a => a.Id == id);
            if (myAsset != null) ViewBag.AssetLabel = myAsset.Label;
            var assetMod = new AssetsViewModel()
            {
                WorkOrders = _context.WorkOrders.Where(w => w.AssetId == id)
                    .Include(w => w.Asset.Space)
                    .Include(w => w.Asset.Space.Storey)
                    .ToList()

            };

            return PartialView("Assets_WorkOrders_Partial", assetMod);
        }

        public ActionResult SpaceAssets(int id)
        {
            var space = _context.Spaces.Include(s => s.Assets).SingleOrDefault(s => s.Id == id);

            var spaceAssets = new List<Asset>();
            if (space != null)
                foreach (var asset in space.Assets)
                    spaceAssets.Add(asset);
            if (space != null) ViewBag.spaceLabel = space.Label;
            ViewBag.SpaceId = id;

            return View(spaceAssets);
        }

        public ActionResult AssetsDetails(int id)
        {
            ViewBag.AssetId = id;
            var workModel = new WorkOrderViewModel()
            {
                Asset = _context.Assets.Include(a => a.Space)
                    .Include(a => a.RelatedAssets)
                    .Include(a => a.Space.Storey)
                    .Include(a => a.WorkOrders)
                    .SingleOrDefault(a => a.Id == id),
                WorkOrders = _context.WorkOrders
                    .Include(w => w.Reporter)
                    .Include(w => w.Fixer)
                    .Include(w => w.Asset)
                    .Include(w => w.Asset.Space)
                    .Include(w => w.Asset.Space.Storey)
                    .ToList(),
                Assets = _context.Assets.ToList(),
                Spaces = _context.Spaces.ToList(),
                Fixers = _context.Users.Where(u => u.Roles.Any(r => r.RoleId == "3")).ToList()

            };

            return View(workModel);
        }



        public ActionResult AddWorkOrderFromAssetDetails(WorkOrder workOrder)
        {
            if (workOrder.Description != null && workOrder.WorkOrderStatus != 0 && workOrder.AssetId != 0)
            {
                _context.WorkOrders.Add(workOrder);
                _context.SaveChanges();

            }
            return RedirectToAction("AssetsDetails", new { id = workOrder.AssetId });
        }


        [HttpGet]
        public ActionResult AddWorkOrderFromSpaceAssetsForm(int id)
        {
            ViewBag.AssetId = id;
            var workModel = new WorkOrderViewModel()
            {
                Asset = _context.Assets.Include(a => a.Space)
                    .Include(a => a.RelatedAssets)
                    .Include(a => a.Space.Storey)
                    .Include(a => a.WorkOrders)
                    .SingleOrDefault(a => a.Id == id),
                WorkOrders = _context.WorkOrders.Include(w => w.Asset)
                    .Include(w => w.Asset.Space)
                    .Include(w => w.Asset.Space.Storey)
                    .ToList(),
                Assets = _context.Assets.ToList(),
                Spaces = _context.Spaces.ToList(),
                Fixers = _context.Users.Where(u => u.Roles.Any(r => r.RoleId == "3")).ToList()
            };
            return View(workModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddWorkOrderFromSpaceAssets(WorkOrder workOrder)
        {
            if (workOrder.Description != null && workOrder.WorkOrderStatus != 0 && workOrder.AssetId != 0)
            {
                _context.WorkOrders.Add(workOrder);
                _context.SaveChanges();
            }
            return RedirectToAction("AssetsDetails", new { id = workOrder.AssetId });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignWorkOrderToFixer(WorkOrder workOrder)
        {
            var myWork = _context.WorkOrders.SingleOrDefault(w => w.Id == workOrder.Id);
            if (myWork != null && workOrder.FixerId != null) myWork.FixerId = workOrder.FixerId;
            _context.SaveChanges();

            return RedirectToAction("AssetsDetails", new { id = workOrder.AssetId });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeStatusWorkOrder(WorkOrder workOrder)
        {
            var myWork = _context.WorkOrders.SingleOrDefault(w => w.Id == workOrder.Id);
            if (myWork != null && workOrder.WorkOrderStatus != 0) myWork.WorkOrderStatus = workOrder.WorkOrderStatus;

            _context.SaveChanges();

            return RedirectToAction("AssetsDetails", new { id = workOrder.AssetId });

        }


    }
}