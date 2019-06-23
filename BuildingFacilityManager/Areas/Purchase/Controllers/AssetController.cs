using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using BuildingFacilityManager.Models;
using BuildingFacilityManager.Models.Assets;
using BuildingFacilityManager.Models.Work_Order;
using BuildingFacilityManager.ViewModels;

namespace BuildingFacilityManager.Areas.Purchase.Controllers
{
    public class AssetController : PurchaseAuthorizationController
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

            return PartialView("Assets_WorkOrders_Org_Partial", assetMod);
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