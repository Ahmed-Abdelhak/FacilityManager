using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingFacilityManager.Controllers;
using BuildingFacilityManager.Models;
using BuildingFacilityManager.ViewModels;

namespace BuildingFacilityManager.Areas.Admin.Controllers
{
    public class DashboardController : AdminAuthorizationController
    {
        private readonly ApplicationDbContext _context;


        public DashboardController()
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
            var model = new DashBoardViewModel()
            {
                WorkOrders = _context.WorkOrders.Where(w => w.Date >= DateTime.Today)
                   .Include(w => w.Asset)
                   .Include(w => w.Asset.Space)
                   .Include(w => w.Asset.Space.Storey).ToList(),

                Assets = _context.Assets.Where(a => a.InstallationDate >= DateTime.Today)
                    .Include(a => a.Space)
                    .Include(a => a.RelatedAssets)
                    .ToList()
            };
            return View(model);
        }


    }
}
