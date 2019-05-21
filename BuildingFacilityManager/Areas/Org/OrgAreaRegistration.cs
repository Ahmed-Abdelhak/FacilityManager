using System.Web.Mvc;

namespace BuildingFacilityManager.Areas.Org
{
    public class OrgAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Org";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Org_default",
                "Org/{controller}/{action}/{id}",
                new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}