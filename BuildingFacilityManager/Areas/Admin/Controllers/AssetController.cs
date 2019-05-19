using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingFacilityManager.Models;
using BuildingFacilityManager.Models.Assets;
using BuildingFacilityManager.ViewModels;

namespace BuildingFacilityManager.Areas.Admin.Controllers
{
    public class AssetController : Controller
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


        // GET: Admin/Asset
        public ActionResult Index()
        {
            var assetModel = new AssetsViewModel()
            {
                Assets = _context.Assets.Include(a => a.Space).Include(a => a.RelatedAssets).ToList(),
                Spaces = _context.Spaces.ToList()
            };
            return View(assetModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAsset(Asset asset)
        {
            var assetModel = new AssetsViewModel()
            {
                Assets = _context.Assets.Include(a => a.Space).Include(a => a.RelatedAssets).ToList(),
                Spaces = _context.Spaces.ToList()
            };

            if (asset.Label != null && asset.SpaceId != 0)
            {
                _context.Assets.Add(asset);
                _context.SaveChanges();
                var assetMod = new AssetsViewModel()
                {
                    Assets = _context.Assets.Include(a => a.Space).Include(a => a.RelatedAssets).ToList(),
                    Spaces = _context.Spaces.ToList(),

                };
                return View("Index", assetMod);
            }
            return View("Index", assetModel);
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
    }
}