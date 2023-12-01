using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Application.Usuarios usuarios,Application.Sistema ApSistema)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

            Models.Sistema sistema = ApSistema.DataSystem();
            ViewBag.Sistema = sistema;
            Models.Usuarios Usuairo = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

                if (Usuairo != null)
                {
                    if (Usuairo.IdRol >= 1) {
                     return RedirectToAction("PrincipalA", "Administracion");
                    }
                        //switch (Usuairo.IdRol)
                        //{
                        //    //case 2:
                        //    //    // code block
                        //    //    return RedirectToAction("DocCompartidos", "Documentos");
                        //    case > 0:
                        //        // code block
                        //        return RedirectToAction("PrincipalA", "Administracion");
                        //default:
                        ////code block
                        //     break;
                        //}
                }
          
            ViewBag.rd = Request.QueryString["rd"];
            ViewBag.rdv = Request.QueryString["rdv"];
            ViewBag.cf = Request.QueryString["cf"];
            return View();
        }

        [HttpPost]
        public JsonResult IniciarSesion(Models.NuevoRegistro NuevoUsuario, Application.Usuarios usuario, Application.Menu menu)
        {
            if (NuevoUsuario != null)
            {
                // inicio de sesion
                Models.Usuarios DataUser = usuario.Iniciar(NuevoUsuario.usuarios);
                if (DataUser.Id > 0)
                {
                    Session["Sesion"] = DataUser;

                    if (NuevoUsuario.usuarios.Session)
                    {
                        Response.Cookies["SesionDT"].Value = Application.Cifrado.Encriptar(DataUser.ClaveCoo);
                    }
                }

                if (!String.IsNullOrEmpty(NuevoUsuario.usuarios.Ruta))
                {
                    string url = Application.Cifrado.Desencriptar(NuevoUsuario.usuarios.Ruta);
                    if (menu.ValidacionPagina(DataUser, url))
                    {
                        string Nu = Application.Cifrado.Desencriptar(NuevoUsuario.usuarios.RutaCompleta);
                        DataUser.RutaAcceso = Nu;
                    }
                }

                return Json(DataUser);
            }
            else
            {
                return Json("Ha ocurrido un problema!");
            }
        }

        [HttpPost]
        public JsonResult CerrarSesion()
        {
            Models.Usuarios DataUser = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            Response.Cookies["SesionDT"].Value = null;

            Session.Abandon();

            if (DataUser != null)
            {
                return Json(DataUser);
            }
            else
            {
                return Json("Ha ocurrido un problema!");
            }
        }
    }
}