using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using BuildingFacilityManager.Models.Assets;
using BuildingFacilityManager.Models.Building_Models;
using BuildingFacilityManager.Models.Enums;
using BuildingFacilityManager.Models.Tasks;
using BuildingFacilityManager.Models.Work_Order;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BuildingFacilityManager.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string Fullname { get { return string.Concat(FirstName + " " + LastName); } }

        public int? FirstLogin { get; set; } = 1;


        public ShiftType? ShiftType { get; set; }
        public Department? Department { get; set; }

        [InverseProperty("Reporter")]
        public ICollection<WorkOrder> WorkOrders_Reported { get; set; }

        [InverseProperty("Fixer")]
        public ICollection<WorkOrder> WorkOrders_Fixed { get; set; }

        public ICollection<InspectionTask> Tasks { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Storey> Stories { get; set; }
        public virtual DbSet<Space> Spaces { get; set; }
        public virtual DbSet<Asset> Assets { get; set; }
        public virtual DbSet<WorkOrder> WorkOrders { get; set; }
        public virtual DbSet<InspectionTask> InspectionTasks { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}