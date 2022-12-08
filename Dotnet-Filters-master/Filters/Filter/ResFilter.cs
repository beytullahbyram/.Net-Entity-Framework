using Filters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Filter
{
    //action filterden farklı viewden önce çalışacak işlemler veya view çalışırken yapılacak işlemleri görmemizi sağlar
    public class ResFilter : FilterAttribute, IResultFilter
    {
        DatabaseContext db=new DatabaseContext();
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Kullanıcı kullanıcı=(Kullanıcı)filterContext.HttpContext.Session["login"];
            db.loglar.Add(new Log()
            { 
                
                kullanıcıadı=kullanıcı.kullanıcıadı,
                actionname=filterContext.RouteData.Values["action"].ToString(),
                controllername=filterContext.RouteData.Values["controller"].ToString(),
                tarih=DateTime.Now,
                bilgi="View çalıştı"
            });
            db.SaveChanges();
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Kullanıcı kullanıcı=(Kullanıcı)filterContext.HttpContext.Session["login"];
            db.loglar.Add(new Log()
            { 
                
                kullanıcıadı=kullanıcı.kullanıcıadı,
                actionname=filterContext.RouteData.Values["action"].ToString(),
                controllername=filterContext.RouteData.Values["controller"].ToString(),
                tarih=DateTime.Now,
                bilgi="View çalışmadan önce"
            });
            db.SaveChanges();
        }
    }
}