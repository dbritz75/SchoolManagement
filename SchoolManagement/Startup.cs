using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;
using SchoolManagement.Models;
using System;

[assembly: OwinStartupAttribute(typeof(SchoolManagement.Startup))]
namespace SchoolManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        //Create user roles
        public void CreateRolesAndUsers()
        {
            var context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("AdminRole"))
            {
                var role = new IdentityRole();
                role.Name = "AdminRole";
                roleManager.Create(role);

                var user = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@student.com",
                    BirthDate = DateTime.Parse("1/1/2000")
                };

                var password = "password";
                var usr = userManager.Create(user, password);

                if (usr.Succeeded)
                {
                    //Add the "user" created above (admin username) to the role AdminRole
                    var result = userManager.AddToRole(user.Id, "AdminRole");
                }
            }

            if (!roleManager.RoleExists("TeacherRole"))
            {
                var role = new IdentityRole();
                role.Name = "TeacherRole";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("SupervisorRole"))
            {
                var role = new IdentityRole();
                role.Name = "SupervisorRole";
                roleManager.Create(role);
            }


        }

        public void ConfigureServices(IServiceCollection services)
        {
            
        }
    }
}
