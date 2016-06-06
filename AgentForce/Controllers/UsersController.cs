using AgentForce.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AgentForce.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {

        ApplicationUser user;
        ApplicationDbContext context;
        List<ApplicationUser> _users;
        public UsersController()
        {
            context = new ApplicationDbContext();
            this.user = new ApplicationUser();
            this._users = new List<ApplicationUser>();

        }
        // GET: Users
        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;


                //var s=	UserManager.GetRoles(user.GetUserId());
                ViewBag.displayMenu = "No";

                if (isAdminUser())
                {
                    ViewBag.displayMenu = "Yes";
                }
                return View();
            }
            else
            {
                ViewBag.Name = "Not Logged IN";
            }

            return View();
        }

        public void getClients(string id)
        {
            var clients = from c in context.Users
                          where c.Id.ToString() == id
                          select c;
        }
        public ActionResult ListUsers()
        {
            var model = context.Users;
            return View(model.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddClient(ClientViewModel model)
        {
            ViewBag.Name = new SelectList(context.Roles.Where(a => a.Name.Contains("Agent")).ToList(), "Name", "Name");

            
            return View(model);
        }
    }
}
