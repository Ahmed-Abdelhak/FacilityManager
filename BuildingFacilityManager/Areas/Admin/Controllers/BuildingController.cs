using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingFacilityManager.Models;
using BuildingFacilityManager.Models.Building_Models;
using BuildingFacilityManager.ViewModels;

namespace BuildingFacilityManager.Areas.Admin.Controllers
{
    public class BuildingController : Controller
    {

        private readonly ApplicationDbContext _context;

        public BuildingController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        // GET: Admin/Building
        public ActionResult Index()
        {
            var buildingModel = new BuildingViewModel
            {
                Buildings = _context.Buildings.ToList(),
                Stories = _context.Stories.ToList(),
                Building = _context.Buildings.SingleOrDefault(b=>b.Id == 1),
                Spaces = _context.Spaces.ToList()



            };

            return View(buildingModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStorey(Storey storey)
        {

            var buildingModelBefore = new BuildingViewModel
            {
                Buildings = _context.Buildings.ToList(),
                Stories = _context.Stories.ToList(),
                Building = _context.Buildings.SingleOrDefault(b => b.Id == 1),
                Spaces = _context.Spaces.ToList()


            };

            if (storey.Label != null)
            {
               
                _context.Stories.Add(storey);
                _context.SaveChanges();
                var buildingModel = new BuildingViewModel
                {
                    Buildings = _context.Buildings.ToList(),
                    Stories = _context.Stories.ToList(),
                    Building = _context.Buildings.SingleOrDefault(b => b.Id == 1),
                    Spaces = _context.Spaces.ToList()



                };
                return View("Index", buildingModel);

            }

            return View("Index", buildingModelBefore);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSpace(Space space)
        {
            var buildingModelBefore = new BuildingViewModel
            {
                Buildings = _context.Buildings.ToList(),
                Stories = _context.Stories.ToList(),
                Building = _context.Buildings.SingleOrDefault(b => b.Id == 1),
                Spaces = _context.Spaces.ToList()

            };

            if (space.Label != null && space.StoreyId != 0 && space.SpaceType != 0)
            {

                _context.Spaces.Add(space);
                _context.SaveChanges();
                var buildingModel = new BuildingViewModel
                {
                    Buildings = _context.Buildings.ToList(),
                    Stories = _context.Stories.ToList(),
                    Building = _context.Buildings.SingleOrDefault(b => b.Id == 1),
                    Spaces = _context.Spaces.ToList()

                };
                return View("Index", buildingModel);

            }

            return View("Index", buildingModelBefore);

        }
    }

    
}