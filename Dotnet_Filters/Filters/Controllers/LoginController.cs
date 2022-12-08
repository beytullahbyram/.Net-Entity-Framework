using Filters.Filter;
using Filters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult SıgIn()
        {
            return View();  
        }

        DatabaseContext db=new DatabaseContext();
        [HttpPost]
        public ActionResult SıgIn(Kullanıcı model)
        {
            Kullanıcı k= db.kullanıcılar.FirstOrDefault(x=>x.kullanıcıadı == model.kullanıcıadı && x.sifre==model.sifre);
            if(k != null)
            {
                Session["login"]=k;
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("","hatalı bilgiler");
                return View(model);
            }
            
        }
        public ActionResult Error()
        {
            Exception exception1 =TempData["error"] as Exception;
            return View(exception1);
        }
    }
}