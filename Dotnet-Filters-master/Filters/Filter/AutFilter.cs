using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Filter
{
    public class AutFilter : FilterAttribute, IAuthorizationFilter
    {
        //filtercontext actiondaki bilgileri ve web sitesindeki genel bilgileri taşır
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["login"] == null)
            {
                filterContext.Result = new RedirectResult("/Login/SıgIn");
            }
        }
    }
}