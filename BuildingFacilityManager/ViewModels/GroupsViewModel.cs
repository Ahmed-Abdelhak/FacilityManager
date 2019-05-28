using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingFacilityManager.Models;

namespace BuildingFacilityManager.ViewModels
{
    public class GroupsViewModel
    {
        public IEnumerable<ApplicationUser> Inspectors { get; set; }
        public IEnumerable<ApplicationUser> OrganizationUsers { get; set; }

    }
}