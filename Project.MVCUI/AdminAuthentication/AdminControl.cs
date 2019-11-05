using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.AdminAuthentication
{
    public class AdminControl:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["admin"] !=null)
            {
                return true;
            }
            httpContext.Response.Redirect("/SystemRegister/Register");
            return false;
        }
    }
}