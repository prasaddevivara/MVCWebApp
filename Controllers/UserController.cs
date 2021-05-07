using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MVCWebApp.Models;

namespace MVCWebApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            IEnumerable<mvcUserModel> userlist;
            HttpResponseMessage response = GlobalVariables.WebapiClient.GetAsync("User").Result;
            userlist = response.Content.ReadAsAsync<IEnumerable<mvcUserModel>>().Result;
            return View(userlist);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            return View(new mvcUserModel());
        }

        [HttpPost]
        public ActionResult AddOrEdit(mvcUserModel user)
        {
            HttpResponseMessage response = GlobalVariables.WebapiClient.PostAsJsonAsync("User", user).Result;
            return RedirectToAction("Index");

        }
    }
}