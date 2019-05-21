using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingFacilityManager.Models;
using BuildingFacilityManager.ViewModels;

namespace BuildingFacilityManager.Controllers
{
    public class BaseController : Controller
    {
        public BuildingTreeViewModel BuildingTreeViewModel { get; set; }
        private readonly ApplicationDbContext _context;


        public BaseController()
        {
            _context = new ApplicationDbContext();
            this.BuildingTreeViewModel = new BuildingTreeViewModel();
            this.BuildingTreeViewModel.Spaces = _context.Spaces.Include(s => s.Assets).ToList();
            this.BuildingTreeViewModel.Stories = _context.Stories.Include(s => s.Spaces).ToList();
            this.ViewData["BuildingTreeViewModel"] = this.BuildingTreeViewModel;
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

    }
}