using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using BuildingFacilityManager.Models.Assets;
using BuildingFacilityManager.Models.Building_Models;
using BuildingFacilityManager.Models.Work_Order;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BuildingFacilityManager.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
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


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}