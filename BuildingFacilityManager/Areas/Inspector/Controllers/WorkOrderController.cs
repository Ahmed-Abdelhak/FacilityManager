﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using BuildingFacilityManager.Controllers;
using BuildingFacilityManager.Models;
using BuildingFacilityManager.Models.Work_Order;
using BuildingFacilityManager.ViewModels;

namespace BuildingFacilityManager.Areas.Inspector.Controllers
{
    public class WorkOrderController : InspectorAuthorizationController
    {
        private readonly ApplicationDbContext _context;

        public WorkOrderController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();

        }

        // GET: Admin/WorkOrder
        public ActionResult Index()
        {
            var workModel = new WorkOrderViewModel()
            {
                WorkOrders = _context.WorkOrders.Include(w => w.Asset)
                    .Include(w => w.Asset.Space)
                    .Include(w => w.Asset.Space.Storey)
                    .ToList(),
                Assets = _context.Assets.ToList(),
                Spaces = _context.Spaces.ToList()
            };
            return View(workModel);
        }

        public ActionResult AddWork(WorkOrder workOrder)
        {

            var workModel = new WorkOrderViewModel()
            {
                WorkOrders = _context.WorkOrders.Include(w => w.Asset)
                    .Include(w => w.Asset.Space)
                    .Include(w => w.Asset.Space.Storey)
                    .ToList(),
                Assets = _context.Assets.ToList(),
                Spaces = _context.Spaces.ToList(),
            };

            if (workOrder.Description != null && workOrder.WorkOrderStatus != 0 && workOrder.AssetId != 0)
            {
                var user = User;
                _context.WorkOrders.Add(workOrder);
                _context.SaveChanges();
                var workMod = new WorkOrderViewModel()
                {
                    WorkOrders = _context.WorkOrders.Include(w => w.Asset)
                        .Include(w => w.Asset.Space)
                        .Include(w => w.Asset.Space.Storey)
                        .ToList(),
                    Assets = _context.Assets.ToList(),
                    Spaces = _context.Spaces.ToList()
                };
                return View("Index", workMod);

            }

            return View("Index", workModel);

        }

        
    }
}