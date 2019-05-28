using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingFacilityManager.Controllers;
using BuildingFacilityManager.Models;
using BuildingFacilityManager.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BuildingFacilityManager.Areas.Admin.Controllers
{
    public class GroupController : AdminAuthorizationController
    {
        private readonly ApplicationDbContext _context;

        public GroupController()
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
            var groups = new GroupsViewModel()
            {
                Inspectors = _context.Users.Where(u => u.Roles.Any(r => r.RoleId == "2")).ToList(),
                OrganizationUsers = _context.Users.Where(u => u.Roles.Any(r => r.RoleId == "3")).ToList()

            };

            return View(groups);
        }
    }
}