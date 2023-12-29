using iTextSharp.text;
using iTextSharp.text.pdf;
using ProyectoBase.Application;
using ProyectoBase.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            // Verificar si la sesión ha expirado
            if (HttpContext.Session != null && HttpContext.Session.IsNewSession)
            {
                string sessionCookie = HttpContext.Request.Headers["Cookie"];
                if ((sessionCookie != null) && (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0))
                {
                    // La sesión ha expirado, redirigir a la página de inicio de sesión
                    filterContext.Result = RedirectToAction("Index", "Home");
                }
            }
        }
    }

}