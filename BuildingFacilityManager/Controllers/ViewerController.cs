using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using BuildingFacilityManager.Models;
using BuildingFacilityManager.ViewModels;

namespace BuildingFacilityManager.Controllers
{
    public class ViewerController : Controller
    {
        private readonly ApplicationDbContext _Context;

        public ViewerController()
        {
            _Context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var viewer = new BuildingViewerViewModel()
            {
               Stories = _Context.Stories.ToList(),
                Spaces = _Context.Spaces.ToList(),
                Assets = _Context.Assets.ToList()
            };



            return View(viewer);
        }
    }
}