using Filters.Filter;
using Filters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Controllers
{
    [ActFilter,ResFilter,AutFilter,Exp]
    public class HomeController : Controller
    {
        // GET: Home
        //public DatabaseContext db=new DatabaseContext();    
        public ActionResult Index()
        {
            //db.kullanıcılar.ToList();
            int sayi=0;
            int sayi2=1/sayi;
            return View(sayi2);
        }
        public ActionResult Index2()
        {
            return View();
        }
    }
}