using EShopping.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(EShopping.Startup))]
namespace EShopping
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            AddSuperUser();
        }
        private void AddSuperUser()
        {
            try
            {
                using (ApplicationDbContext Db = new ApplicationDbContext())
                {
                    var roleStore = new RoleStore<IdentityRole>(Db);
                    var roleMngr = new RoleManager<IdentityRole>(roleStore);
                    var userStore = new UserStore<ApplicationUser>(Db);
                    var userMngr = new UserManager<ApplicationUser>(userStore);

                    if (!roleMngr.RoleExists("Admin"))
                    {
                        roleMngr.Create(new IdentityRole("Admin"));
                        if (userMngr.FindByEmail("admin@yahoo.com") == null)
                        {
                            ApplicationUser user = new ApplicationUser { UserName = "admin@yahoo.com", Email = "admin@yahoo.com" };
                            var result = userMngr.Create(user, "Aa@12345");
                            if (result.Succeeded)
                            {
                                userMngr.AddToRole(user.Id, "Admin");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message + "/n" + ex.StackTrace);
            }
        }

    }

}

