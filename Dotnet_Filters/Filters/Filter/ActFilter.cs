using Filters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Filter
{
    public class ActFilter : FilterAttribute, IActionFilter
    {
        DatabaseContext db=new DatabaseContext();
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Kullanıcı kullanıcı=(Kullanıcı)filterContext.HttpContext.Session["login"];
            db.loglar.Add(new Log()
            { 
                
                kullanıcıadı=kullanıcı.kullanıcıadı,
                actionname=filterContext.ActionDescriptor.ActionName,
                controllername=filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                tarih=DateTime.Now,
                bilgi="action çalıştı"
            });
            db.SaveChanges();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
                        Kullanıcı kullanıcı=(Kullanıcı)filterContext.HttpContext.Session["login"];
            db.loglar.Add(new Log()
            { 
                
                kullanıcıadı=kullanıcı.kullanıcıadı,
                actionname=filterContext.ActionDescriptor.ActionName,
                controllername=filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                tarih=DateTime.Now,
                bilgi="action çalıştı"
            });
            db.SaveChanges();
        }
    }
}