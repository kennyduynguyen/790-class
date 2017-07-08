using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ContosoUniversity.Controllers
{
    public class ViewProfileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ViewProfile
        public ActionResult Index(string firstName, string lastName)
        {
            string user_id = User.Identity.GetUserId();
            ViewBag.user = db.Users.Find(user_id);
            return View();
        }
    }
}