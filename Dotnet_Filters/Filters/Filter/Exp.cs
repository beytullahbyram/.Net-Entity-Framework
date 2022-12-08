using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Filter
{
    public class Exp : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;  //kontrolü biz aldık biz yöneticez hataları
            filterContext.Controller.TempData["error"]=filterContext.Exception;
            filterContext.Result=new RedirectResult("/Login/Error");
        }
    }
}