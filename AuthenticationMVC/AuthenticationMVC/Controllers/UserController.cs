using AuthenticationMVC.Data;
using AuthenticationMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationMVC.Controllers
{
    public class UserController : Controller
    {
        private MyIdentityDbContext myDBContext;
        private UserManager<User> userManager;
        private RoleManager<Role> roleManager;

        public UserController()
        {
            myDBContext = new MyIdentityDbContext();
            UserStore<User> userStore = new UserStore<User>(myDBContext);
            userManager = new UserManager<User>(userStore);
            RoleStore<Role> roleStore = new RoleStore<Role>(myDBContext);
            roleManager = new RoleManager<Role>(roleStore);
        }
      
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(string Username, string PasswordHash)
        {
            User user = new User()
            {
                UserName = Username
            };
         var result = await userManager.CreateAsync(user, PasswordHash);
            if (result.Succeeded)
            {
                return View("Success");
            }
            else
            {
                return View("Error");
            }
        }

        public async Task<ActionResult> AddRole(string RoleName)
        {
            Role role = new Role()
            {
                Name = RoleName
            };
            var result = await roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return View("Success");
            }
            else
            {
                //result.Errors.First().ToString();
                return View("Error");
            }       
        }

        public async Task<ActionResult> AddUserToRole(string UserId, string RoleName)
        {
            var user = myDBContext.Users.Find(UserId);
            var role = myDBContext.Roles.Find(RoleName);
            if(role == null || user == null)
            {
                return View("ViewError");
            }
            var result =  await userManager.AddToRoleAsync(user.Id, role.Name);
            //string roleName1 = "Admin";
            //string roleName2 = "User";
            ////var result = await userManager.AddToRoleAsync(userId, roleName);
            //var result = await userManager.AddToRolesAsync(userId, roleName1, roleName2);
            if (result.Succeeded)
            {
                return View("Success");
            }
            else
            {
                return View("Error");
            }
           
        }

        public async Task<ActionResult> Login(string Username, string Password)
        {
            var user = await  userManager.FindAsync(Username, Password);
            if(user == null)
            {
                return View("Error");
            }
            else
            {
                SignInManager<User, string> signInManager = 
                    new SignInManager<User, string>(userManager, Request.GetOwinContext().Authentication);
               await signInManager.SignInAsync(user, false, false);
                return View("Success");
            }    
        }

        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect("Home");
        }

    }
}