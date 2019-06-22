using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using BuildingFacilityManager.Controllers;
using BuildingFacilityManager.Models;
using BuildingFacilityManager.Models.Building_Models;
using BuildingFacilityManager.ViewModels;

namespace BuildingFacilityManager.Areas.Admin.Controllers
{
    public class BuildingController : AdminAuthorizationController
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
                Building = _context.Buildings.SingleOrDefault(b => b.Id == 1),
                Spaces = _context.Spaces.ToList()
            };

            return View(buildingModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStorey(Storey storey)
        {
            if (storey.Label != null && storey.Width > 0 && storey.Length > 0 && storey.Level >= 0)
            {
                _context.Stories.Add(storey);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSpace(Space space)
        {
           // I need to validate the Intersect of Lines of the Space, by the PositionX and PositionY
            var spaces = _context.Spaces.Where(s => s.StoreyId == space.StoreyId).ToList();
            var storey = _context.Stories.SingleOrDefault(s => s.Id == space.StoreyId);

            var flag = false;

            foreach (var t in spaces)
            {
                var x = Math.Abs(t.PositionX - space.PositionX);
                var y = Math.Abs(t.PositionY - space.PositionY);

                if (x >= (t.Width)
                    &&
                    y >= (t.Length)

                )
                {
                    flag = true;
                }
            }

            if (flag == true && storey != null && (space.Label != null && space.StoreyId != 0 && space.SpaceType != 0 && space.Length > 0 && space.Width >0 && space.WallsHeight >0 && space.PositionX >= 0 && space.PositionY >= 0 && space.Width + space.PositionX <= storey.Width && space.Length + space.PositionY <= storey.Length) )
            {
                _context.Spaces.Add(space);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

       
    }


}