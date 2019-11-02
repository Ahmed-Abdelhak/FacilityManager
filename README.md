# FacilityManager
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
![Facility Manager](https://repository-images.githubusercontent.com/187499021/504e3780-9c54-11e9-9e12-c923ac627389)

A Web Based Facility Management System with different Roles. Built with ASP.NET MVC,
EntityFramework, JQuery and Bootstrap.

**Features** :
1. Admin Dashboard with different Charts to monitor all Work Orders, Inspection Tasks, Periodic Inspection
2. Group Policy Module to View and Add Users with different Roles
3. Building Definition Module to Define the Hierarchy of the building
4. Assets Control Module to define and View Assets with Different Categories
5. Inspection Tasks Module includes assigning tasks to Users in the Role ( Inspectors )
6. Work Order Module includes assigning Maintenance Work Orders to Users in the Role ( Fixers )
7. Cost Control Module 
8. Different Areas with Different Dash Boards for the 4 Different Roles ( Admins, Inspectors, Fixer, Purchase Manager ) 
9. Redirection after Login to Different Areas Based on the Role type
10. Dynamic Sidebar Navigation to View Assets in the Building Hirearchy and reports Work Order



**Setup** : 

1- run the Solution File (.sln)

2- Create a new Admin Account using the below code in your configurations.cs file under your Migration Folder (EF-Code First)
```
protected override void Seed(BuildingFacilityManager.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (!context.Roles.Any(r => r.Name == SystemRoles.Admin))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = SystemRoles.Admin };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "Admin@facilitymanager.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "Admin@facilitymanager.com", Email= "Admin@facilitymanager.com" };

                manager.Create(user, "**********");
                manager.AddToRole(user.Id, SystemRoles.Admin);
            }
        }
```

3- run the command "Update-Database" through NuGet Package Manager

4- Run the Project and once the website runs, log in from the top right with the created Admin credentials, That's it !


NOTE: You can Create accounts with different roles from the page  "/Admin/Group" using the "Add" button
   *The default password for new Accounts is  o]`Y.<:~1{-7{E   
