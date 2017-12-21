using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW.LabStore.UI.Controllers
{
    public class UserMangerController : Controller
    {
        // GET: UserManger
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string userName,string pwd,string vcode)
        {
            JsonResult result = new JsonResult()
            {
                Data = new { success = true }
            };
            return result;
        }
    }
}