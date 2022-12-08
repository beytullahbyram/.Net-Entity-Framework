using Ajax_helper_methods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ajax_helper_methods.Controllers
{
    public class HomeController : Controller
    {
  
        // GET: Home
        List<string> list = new List<string>()
            {
                "teknoloji","sağlık","spor","bilim","astroloji","tarih","yapay zeka"
            };
        public ActionResult Index()
        {
            Session["liste"] = list;
            return View();
        }

        public MvcHtmlString DataSil(int id)
        {
            List<string> list =(List<string>)Session["liste"];
            list.RemoveAt(id);
            return MvcHtmlString.Empty;
        }
        public PartialViewResult VeriYukle()
        {
            List<string> list =(List<string>)Session["liste"];
            System.Threading.Thread.Sleep(3000);
            return PartialView("_PartialPageVeriListesi",list);
        }
        public PartialViewResult VeriKaybet()
        {
            return PartialView("_PartialPageVeriListesiKaybet");

        }



        public ActionResult Index2()
        {
            //ViewBag.liste = (List<Kisi>)Session["liste"];
            return View(new Kisi());
        }           
        [HttpPost]
        public PartialViewResult Index2(Kisi model)
        {
            List<Kisi> kisiler=null;
            if (Session["liste"] != null)
                kisiler=(List<Kisi>)Session["liste"];
            else
                kisiler=new List<Kisi>();
            model.id=Guid.NewGuid();
            kisiler.Add(model);
            Session["liste"]=kisiler;
            System.Threading.Thread.Sleep(2000);
            return PartialView("_PartialPageKisi",model);
        }
    }
}