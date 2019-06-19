using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BuildingFacilityManager.Models;
using Newtonsoft.Json;

namespace BuildingFacilityManager.Controllers.APIControllers
{
    public class CoreApiController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CoreApiController()
        {
            _context = ApplicationDbContext.Create();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult GetSpacesByStoryId(int id)
        {
            var spaces = _context.Spaces.Where(s => s.StoreyId == id).ToList();
            if (spaces.Count == 0)
            {
                return NotFound();
            }
            return Ok(spaces);
        }

        [HttpGet]
        public IHttpActionResult GetAssetsBySpaceId(int id)
        {
            var assets = _context.Assets.Where(a => a.SpaceId == id).ToList();
            if (assets.Count == 0)
            {
                return NotFound();
            }
            return Ok(assets);
        }

       

    }
}
