using iTextSharp.text;
using iTextSharp.text.pdf;
using ProyectoBase.Application;
using ProyectoBase.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class AdministracionController : BaseController
    {
        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    base.OnActionExecuting(filterContext);

        //    // Obtener el usuario de la sesión
        //    Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

        //    if (Usuario != null)
        //    {
        //        ViewBag.UserGlobal = Usuario;

        //    }
        //    else
        //    {
        //        // Si no hay usuario, redirige al login o página inicial
        //        filterContext.Result = RedirectToAction("Index", "Home");
        //    }
        //}

        public ActionResult AdminCarpetas(Models.Notification _notification, Application.Notification Anotification, Application.Sistema ApSistema, Application.PermisosRolElementos APPpermisosRolElementos)
        {
            Models.Sistema sistema = ApSistema.DataSystem();
            ViewBag.Sistema = sistema;
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            List<Models.PermisosRolElementos> PermisosRolElementos = APPpermisosRolElementos.PermisosElementos(Usuario);
            ViewBag.ElementoOculto = PermisosRolElementos;
            if (Usuario != null)
            {
                ViewBag.Nombre = Usuario.Nombre + " " + Usuario.Apellidos;
                ViewBag.Rol = Usuario.NombreRol;
                ViewBag.Foto = Usuario.Inicial;
                ViewBag.Usuario = Usuario;
                _notification.IdUsuario = Usuario.Id;
                List<Models.Notification> notificar = Anotification.SP_listNotification(_notification);
                ViewBag.lisnotifi = notificar;
                Models.Notification CountNoti = Anotification.SP_ConteoNoti(_notification);
                ViewBag.CountNoti = CountNoti;



                string Carpetas = CarpetasPadre();
                ViewBag.carpetas = Carpetas;

                return View();
            }
            else { return RedirectToAction("Index", "Home"); }
        }

        public ActionResult AdminGrupos(Application.EmpresasListado empresasListado,
          Models.Notification _notification, Application.Notification Anotification, Application.Sistema ApSistema, Application.PermisosRolElementos APPpermisosRolElementos)
        {
            Models.Sistema sistema = ApSistema.DataSystem();
            ViewBag.Sistema = sistema;
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            List<Models.PermisosRolElementos> PermisosRolElementos = APPpermisosRolElementos.PermisosElementos(Usuario);
            ViewBag.ElementoOculto = PermisosRolElementos;
            if (Usuario != null)
            {
                ViewBag.Nombre = Usuario.Nombre + " " + Usuario.Apellidos;
                ViewBag.Rol = Usuario.NombreRol;
                ViewBag.Usuario = Usuario;
                ViewBag.Foto = Usuario.Inicial;
                List<Models.EmpresasListado> dtEmpresasListado = empresasListado.SP_EmpresasListado();
                ViewBag.dtEmpresasListado = dtEmpresasListado;






                _notification.IdUsuario = Usuario.Id;
                List<Models.Notification> notificar = Anotification.SP_listNotification(_notification);
                ViewBag.lisnotifi = notificar;

                Models.Notification CountNoti = Anotification.SP_ConteoNoti(_notification);
                ViewBag.CountNoti = CountNoti;
                return View();
            }
            else { return RedirectToAction("Index", "Home"); }
        }  
        public ActionResult VisualizarDocumentoSAdmin(Models.List_Doc _list_Doc, Application.List_Doc Alist_Doc,
          Models.Notification _notification, Application.Notification Anotification, Application.Sistema ApSistema, Application.PermisosRolElementos APPpermisosRolElementos)
        {
            Models.Sistema sistema = ApSistema.DataSystem();
            ViewBag.Sistema = sistema;
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            List<Models.PermisosRolElementos> PermisosRolElementos = APPpermisosRolElementos.PermisosElementos(Usuario);
            ViewBag.ElementoOculto = PermisosRolElementos;
            if (Usuario != null)
            {
                ViewBag.Nombre = Usuario.Nombre + " " + Usuario.Apellidos;
                ViewBag.Rol = Usuario.NombreRol;
                ViewBag.Usuario = Usuario;
                ViewBag.Foto = Usuario.Inicial;



                _list_Doc.IdSesion = Usuario.Id;
                List<Models.List_Doc> dtList_Doc = Alist_Doc.SP_ListarDocAdmin();
                ViewBag.Docs = dtList_Doc;




                _notification.IdUsuario = Usuario.Id;
                List<Models.Notification> notificar = Anotification.SP_listNotification(_notification);
                ViewBag.lisnotifi = notificar;

                Models.Notification CountNoti = Anotification.SP_ConteoNoti(_notification);
                ViewBag.CountNoti = CountNoti;
                return View();
            }
            else { return RedirectToAction("Index", "Home"); }
        }
        public ActionResult CheckDoc(Application.Documentos documentos, Models.Documento documento, Application.Notification Anotification, Models.Notification _notification
            ,Application.Sistema ApSistema, Application.PermisosRolElementos APPpermisosRolElementos)
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            List<Models.PermisosRolElementos> PermisosRolElementos = APPpermisosRolElementos.PermisosElementos(Usuario);
            ViewBag.ElementoOculto = PermisosRolElementos;
            Models.Sistema sistema = ApSistema.DataSystem();
            ViewBag.Sistema = sistema;
            ViewBag.Nombre = Usuario.Nombre + " " + Usuario.Apellidos;
            ViewBag.Id = Usuario.Id;
            ViewBag.Rol = Usuario.NombreRol;
            List<Models.Documento> InfoDP = documentos.CheckDocPrestado();
            ViewBag.CustodiaD = InfoDP;

            _notification.IdUsuario = Usuario.Id;
            List<Models.Notification> notificar = Anotification.SP_listNotification(_notification);
            ViewBag.lisnotifi = notificar;
            Models.Notification CountNoti = Anotification.SP_ConteoNoti(_notification);
            ViewBag.CountNoti = CountNoti;
            ViewBag.Foto = Usuario.Inicial;
            return View();
        }




        // GET: Administracion
        public ActionResult Index(Application.Menu menu, Models.Notification _notification, Application.Notification Anotification, Application.Cat_ClasificacionArchivo cat_ClasificacionArchivo,
            Application.List_Doc listadoAdmin, Application.Sistema ApSistema, Application.PermisosRolElementos APPpermisosRolElementos)
        {
            Models.Cat_ClasificacionArchivo Rorden = cat_ClasificacionArchivo.SP_RESSET();
            Models.Sistema sistema = ApSistema.DataSystem();
            ViewBag.Sistema = sistema;
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena2 = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;

            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            List<Models.PermisosRolElementos> PermisosRolElementos = APPpermisosRolElementos.PermisosElementos(Usuario);
            ViewBag.ElementoOculto = PermisosRolElementos;

            if (Usuario != null)
            {

                ViewBag.Nombre = Usuario.Nombre + " " + Usuario.Apellidos;
                ViewBag.Id = Usuario.Id;
                ViewBag.Rol = Usuario.NombreRol;
                ViewBag.Foto = Usuario.Inicial;
                _notification.IdUsuario = Usuario.Id;
                ViewBag.usuario = Usuario;

                List<Models.Notification> notificar = Anotification.SP_listNotification(_notification);
                ViewBag.lisnotifi = notificar;

                Models.Notification CountNoti = Anotification.SP_ConteoNoti(_notification);
                ViewBag.CountNoti = CountNoti;

                List<Models.List_Doc> Adoc = listadoAdmin.SP_ListarDocAdmin();
                ViewBag.AdminDoc = Adoc;


                //PARA HACER EL ARBOL POR USUARIO
                if (((ProyectoBase.Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"]).IdRol == 3 || ((ProyectoBase.Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"]).IdRol == 1003)
                {
                    string Carpetas = getParents();
                    ViewBag.carpetas = Carpetas;
                }
                else
                {
                    string Carpetas = ListadoPerfil();
                    ViewBag.carpetas = Carpetas;
                }

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home", new { @rd = Application.Cifrado.Encriptar(cadena), @rdv = Application.Cifrado.Encriptar(url) });
            }
  
        }

        //PARA HACER EL ARBOL POR USUARIO
        public string ListadoPerfil()
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            Models.Cat_ClasificacionArchivo carpeta = new Models.Cat_ClasificacionArchivo();
            carpeta.Id = Usuario.Id;
            Application.Cat_ClasificacionArchivo cat_ClasificacionArchivo = new Application.Cat_ClasificacionArchivo();
            List<Models.Cat_ClasificacionArchivo> dtClasificacionArchivo = cat_ClasificacionArchivo.Cat_ClasificacionArchivo_ListarPorIdUsuario(carpeta);
            string resulCarpetas = "";

            if (dtClasificacionArchivo.Count > 0)
            {
                resulCarpetas += "<ul>";

                foreach (var dt in dtClasificacionArchivo)
                {

                    resulCarpetas += "<li id='" + dt.Id + "'>" + dt.Nombre;
                    resulCarpetas += ListadoPerfilSub(dt);
                    resulCarpetas += getDocument(dt);
                    resulCarpetas += "</li>";

                }
                resulCarpetas += "</ul>";
            }

            return resulCarpetas;
        }
        public string ListadoPerfilSub(Models.Cat_ClasificacionArchivo cat_ClasificacionDoc)
        {

            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            Models.Cat_ClasificacionArchivo carpeta = new Models.Cat_ClasificacionArchivo();
            cat_ClasificacionDoc.IdUser = Usuario.Id;

            Application.Cat_ClasificacionArchivo cat_ClasificacionArchivo = new Application.Cat_ClasificacionArchivo();
            List<Models.Cat_ClasificacionArchivo> dtSClasificacionArchivo = cat_ClasificacionArchivo.Cat_SubClasificacionArchivo_ListarPorIdUsuario(cat_ClasificacionDoc);


            string resulCarpetas = "";
            if (dtSClasificacionArchivo.Count > 0)
            {
                resulCarpetas += "<ul>";

                foreach (var dt in dtSClasificacionArchivo)
                {
                    resulCarpetas += "<li id='" + dt.Id + "'>" + dt.Nombre;
                    resulCarpetas += ListadoPerfilSub(dt);
                    resulCarpetas += getDocument(dt);
                    resulCarpetas += "</li>";

                }
                resulCarpetas += "</ul>";
            }
            return resulCarpetas;
        }









        public ActionResult PrincipalA(Application.Menu menu, Application.Documento_Versiones Adocumento_Versiones,
            Models.Documento_Versiones _documento_Versiones, Application.Documentos Apdocumentos,
            Models.ConteoDocCompartidos _ConteoDocCompartidos, Application.ConteoDocCompartidos AConteoDocCompartidos,
            Models.listadoVigencia _listadoVigencia, Application.listadoVigencia AlistadoVigencia,
            Models.Notification _notification, Application.Notification Anotification, Application.LisUser APlisUser, Application.Correo correo, Application.Sistema ApSistema,
            Models.Documento documento, Application.PermisosRolElementos APPpermisosRolElementos)
        {

            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena2 = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            Models.Sistema sistema = ApSistema.DataSystem();
            ViewBag.Sistema = sistema;

            List<Models.PermisosRolElementos> PermisosRolElementos = APPpermisosRolElementos.PermisosElementos(Usuario);
            ViewBag.ElementoOculto = PermisosRolElementos;

            if (Usuario != null)
            {
                List<Models.LisUser> lisUser = APlisUser.SP_UserExpirado();


                foreach (var dtUsuario in lisUser)
                {
                    correo.EnvioCorreoExpira(dtUsuario);
                     
                }

                Models.Notification analisis = Anotification.SP_NotiFechaTermino();

                ViewBag.Nombre = Usuario.Nombre + " " + Usuario.Apellidos;
                ViewBag.Rol = Usuario.NombreRol;
                ViewBag.Foto = Usuario.Inicial;


                _documento_Versiones.IdUsuario = Usuario.Id;
                List<Models.Documento_Versiones> conteo = Adocumento_Versiones.SP_ConteoMisDoc(_documento_Versiones);
                ViewBag.Conteo = conteo;

                _ConteoDocCompartidos.Id = Usuario.Id;
                List<Models.ConteoDocCompartidos> conteoC = AConteoDocCompartidos.SP_ConteoDocCompartidos(_ConteoDocCompartidos);
                ViewBag.ConteoC = conteoC;
                List<Models.ConteoDocCompartidos> vigente = AConteoDocCompartidos.SP_ConteoVigente(_ConteoDocCompartidos);
                ViewBag.ConteoV = vigente;
                List<Models.ConteoDocCompartidos> vencido = AConteoDocCompartidos.SP_ConteoVencido(_ConteoDocCompartidos);
                ViewBag.ConteoVe = vencido;

                _listadoVigencia.Id = Usuario.Id;
                List<Models.listadoVigencia> vigentes = AlistadoVigencia.SP_listadoVigente(_listadoVigencia);
                ViewBag.lisvigente = vigentes;

                List<Models.listadoVigencia> vencidos = AlistadoVigencia.SP_listadoVencido(_listadoVigencia);
                ViewBag.lisvencido = vencidos;

                List<Models.listadoVigencia> Proxvenc = AlistadoVigencia.SP_LisProxVence(_listadoVigencia);
                ViewBag.lisProx = Proxvenc;

                _notification.IdUsuario = Usuario.Id;
                List<Models.Notification> notificar = Anotification.SP_listNotification(_notification);
                ViewBag.lisnotifi = notificar;

                Models.Notification notificationV = Anotification.SP_DocVisto(_notification);
                ViewBag.Visto = notificationV.Ids;

                Models.Notification notificationNV = Anotification.SP_DocNoVisto(_notification);
                ViewBag.NVisto = notificationNV.Ids;

                Models.Notification CountNoti = Anotification.SP_ConteoNoti(_notification);
                ViewBag.CountNoti = CountNoti;

                documento.IdUsuario = Usuario.Id;

                Models.Documento ConteoSolicitud = Apdocumentos.ConteoSolicitud(documento);
                ViewBag.Solicitud = ConteoSolicitud;

                List<Models.Documento> ListSolicitud = Apdocumentos.ListSolicitud(documento);
                ViewBag.ListSolicitud = ListSolicitud;
                return View();

            }
            else
            {
                return RedirectToAction("Index", "Home", new { @rd = Application.Cifrado.Encriptar(cadena), @rdv = Application.Cifrado.Encriptar(url) });
            }

        }

        public ActionResult Vista(Models.Notification _notification, Application.Notification Anotification,
            Application.Documentos documentos, Application.Menu menu, Models.Notification Dnotificacion, Application.Notification Apnotificacion, Application.Sistema ApSistema, Application.PermisosRolElementos APPpermisosRolElementos)
        {
            Models.Sistema sistema = ApSistema.DataSystem();
            ViewBag.Sistema = sistema;
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadenaCompleta = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;


            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            List<Models.PermisosRolElementos> PermisosRolElementos = APPpermisosRolElementos.PermisosElementos(Usuario);
            ViewBag.ElementoOculto = PermisosRolElementos;
            if (menu.ValidacionPagina(Usuario, url))
            {

                ViewBag.Nombre = Usuario.Nombre + " " + Usuario.Apellidos;
                ViewBag.Rol = Usuario.NombreRol;
                ViewBag.Foto = Usuario.Inicial;
                _notification.IdUsuario = Usuario.Id;
                List<Models.Notification> notificar = Anotification.SP_listNotification(_notification);
                ViewBag.lisnotifi = notificar;

                Models.Notification CountNoti = Anotification.SP_ConteoNoti(_notification);
                ViewBag.CountNoti = CountNoti;

                //VISTA PROCEDIMIENTOS

                if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    //DATOS DEL DOCUMENTO
                    int Id = Convert.ToInt32(Application.Cifrado.Desencriptar(Request.QueryString["Id"]));
                    Models.Documento doc = new Documento();
                    doc.Id = Id;

                    Models.Documento documento = documentos.SP_DocumentoInfo(doc);
                    ViewBag.InfoDoc = documento;
                    Models.Documento documentoR = documentos.sp_NombreRutaDoc(doc);
                    ViewBag.Ruta = documentoR.Nombre;


                    //CONTROL DE NOTIFICACIONES 
                    Dnotificacion.IdUsuario = Usuario.Id;
                    Dnotificacion.IdDocumento = Id;
                    Models.Notification DesactivarNot = Apnotificacion.SP_NotificacionAC(Dnotificacion);


                    return View();
                }
                else { return RedirectToAction("PrincipalA", "Administracion"); }

            }
            else
            {
                return RedirectToAction("Index", "Home", new { @rd = Application.Cifrado.Encriptar(cadena), @rdv = Application.Cifrado.Encriptar(url)
                , @cf = Application.Cifrado.Encriptar(cadenaCompleta)
                });
            }



        }

        public ActionResult VistaEditar(Models.Notification _notification, Application.Notification Anotification,
        Application.Documentos documentos, Application.Cat_Tipo_Documento cat_Tipo_Documento,
        Application.Cat_TipoArchivo cat_TipoArchivo, Application.Cat_Almacenamiento_Documento cat_Almacenamiento_Documento,
        Application.Cat_ClasificacionDoc cat_ClasificacionDoc, Application.Cat_ClasificacionArchivo cat_ClasificacionArchivo
            , Application.Sistema ApSistema, Application.PermisosRolElementos APPpermisosRolElementos)
        {
            Models.Sistema sistema = ApSistema.DataSystem();
            ViewBag.Sistema = sistema;

            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            List<Models.PermisosRolElementos> PermisosRolElementos = APPpermisosRolElementos.PermisosElementos(Usuario);
            ViewBag.ElementoOculto = PermisosRolElementos;
            if (Usuario != null)
            {
                ViewBag.Nombre = Usuario.Nombre + " " + Usuario.Apellidos;
                ViewBag.Rol = Usuario.NombreRol;
                ViewBag.Foto = Usuario.Inicial;


                _notification.IdUsuario = Usuario.Id;
                List<Models.Notification> notificar = Anotification.SP_listNotification(_notification);
                ViewBag.lisnotifi = notificar;

                Models.Notification CountNoti = Anotification.SP_ConteoNoti(_notification);
                ViewBag.CountNoti = CountNoti;

                List<Models.Cat_Tipo_Documento> dtTipoDocumentos = cat_Tipo_Documento.Cat_Tipo_Documento_Listar();
                ViewBag.dtTipoDocumentos = dtTipoDocumentos;

                List<Models.Cat_TipoArchivo> dtTipoArchivo = cat_TipoArchivo.Cat_TipoArchivo_Listar();
                ViewBag.dtTipoArchivo = dtTipoArchivo;

                List<Models.Cat_Almacenamiento_Documento> dtAlmacenamiento = cat_Almacenamiento_Documento.Cat_Almacenamiento_Documento_Listar();
                ViewBag.dtAlmacenamiento = dtAlmacenamiento;

                List<Models.Cat_ClasificacionDoc> dtClasificacion = cat_ClasificacionDoc.Cat_ClasificacionDoc_Listar();
                ViewBag.dtClasificacion = dtClasificacion;

                List<Models.Cat_ClasificacionArchivo> dtClasificacionArchivo = cat_ClasificacionArchivo.Cat_ClasificacionArchivo_Listar();
                ViewBag.dtClasificacionArchivo = dtClasificacionArchivo;

                List<Models.Cat_ClasificacionArchivo> dtSClasificacionArchivo = cat_ClasificacionArchivo.SP_Subclas();
                ViewBag.dtsubClasificacionArchivo = dtSClasificacionArchivo;


                if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
                {

                    int Id = Convert.ToInt32(Application.Cifrado.Desencriptar(Request.QueryString["Id"]));
                    Models.Documento doc = new Documento();
                    doc.Id = Id;

                    Models.Documento documento = documentos.SP_DocumentoInfo2(doc);
                    ViewBag.nombredoc = documento.Nombre;
                    ViewBag.editable = documento.NmArchivoword;
                    ViewBag.Descripcion = documento.Descripcion;
                    ViewBag.version = documento.Version;
                    ViewBag.codigo = documento.NmArchivo;
                    ViewBag.Id = doc.Id;

                    ViewBag.FechaRevision = documento.FechaRevision;
                    ViewBag.Fechadeentradaenvigor = documento.FechaEntradaVigor;
                    ViewBag.FechaPublicacion = documento.FechaPublicacion;
                    ViewBag.FechaVencimiento = documento.FechaVencimiento;
                    ViewBag.FechaProximaRevision = documento.FechaProximaRevision;

                    ViewBag.dtTipoDocumento = documento.IdTipoDocumento;
                    ViewBag.PalabraClave = documento.PalabraClave;
                    ViewBag.IdTipoArchivo = documento.IdTipoArchivo;
                    ViewBag.IdMedioAlmacenamiento = documento.IdMedioAlmacenamiento;
                    ViewBag.IdClasificacion = documento.IdClasificacion;

                  

                    return View();
                }
                else
                {
                    return RedirectToAction("PrincipalA", "Administracion");
                }


            }
            else { return RedirectToAction("Index", "Home"); }

        } 
        
        public ActionResult VistaEditarCompartido(Models.Notification _notification, Application.Notification Anotification,
        Application.Documentos documentos, Application.Cat_Tipo_Documento cat_Tipo_Documento,
        Application.Cat_TipoArchivo cat_TipoArchivo, Application.Cat_Almacenamiento_Documento cat_Almacenamiento_Documento,
        Application.Cat_ClasificacionDoc cat_ClasificacionDoc, Application.Cat_ClasificacionArchivo cat_ClasificacionArchivo
            , Application.Sistema ApSistema, Application.PermisosRolElementos APPpermisosRolElementos)
        {

            Models.Sistema sistema = ApSistema.DataSystem();
            ViewBag.Sistema = sistema;
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            List<Models.PermisosRolElementos> PermisosRolElementos = APPpermisosRolElementos.PermisosElementos(Usuario);
            ViewBag.ElementoOculto = PermisosRolElementos;
            if (Usuario != null)
            {
                ViewBag.Nombre = Usuario.Nombre + " " + Usuario.Apellidos;
                ViewBag.Rol = Usuario.NombreRol;
                ViewBag.Foto = Usuario.Inicial;
                _notification.IdUsuario = Usuario.Id;
                List<Models.Notification> notificar = Anotification.SP_listNotification(_notification);
                ViewBag.lisnotifi = notificar;

                Models.Notification CountNoti = Anotification.SP_ConteoNoti(_notification);
                ViewBag.CountNoti = CountNoti;

                List<Models.Cat_Tipo_Documento> dtTipoDocumentos = cat_Tipo_Documento.Cat_Tipo_Documento_Listar();
                ViewBag.dtTipoDocumentos = dtTipoDocumentos;

                List<Models.Cat_TipoArchivo> dtTipoArchivo = cat_TipoArchivo.Cat_TipoArchivo_Listar();
                ViewBag.dtTipoArchivo = dtTipoArchivo;

                List<Models.Cat_Almacenamiento_Documento> dtAlmacenamiento = cat_Almacenamiento_Documento.Cat_Almacenamiento_Documento_Listar();
                ViewBag.dtAlmacenamiento = dtAlmacenamiento;

                List<Models.Cat_ClasificacionDoc> dtClasificacion = cat_ClasificacionDoc.Cat_ClasificacionDoc_Listar();
                ViewBag.dtClasificacion = dtClasificacion;

                List<Models.Cat_ClasificacionArchivo> dtClasificacionArchivo = cat_ClasificacionArchivo.Cat_ClasificacionArchivo_Listar();
                ViewBag.dtClasificacionArchivo = dtClasificacionArchivo;

                List<Models.Cat_ClasificacionArchivo> dtSClasificacionArchivo = cat_ClasificacionArchivo.SP_Subclas();
                ViewBag.dtsubClasificacionArchivo = dtSClasificacionArchivo;


                if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
                {


                    int Id = Convert.ToInt32(Application.Cifrado.Desencriptar(Request.QueryString["Id"]));
                    Models.Documento doc = new Documento();
                    doc.Id = Id;

                    Models.Documento documento = documentos.SP_DocumentoInfo2(doc);
                    ViewBag.nombredoc = documento.Nombre;
                    ViewBag.editable = documento.NmArchivoword;
                    ViewBag.Descripcion = documento.Descripcion;
                    ViewBag.version = documento.Version;
                    ViewBag.codigo = documento.NmArchivo;
                    ViewBag.Id = doc.Id;

                    ViewBag.FechaRevision = documento.FechaRevision;
                    ViewBag.Fechadeentradaenvigor = documento.FechaEntradaVigor;
                    ViewBag.FechaPublicacion = documento.FechaPublicacion;
                    ViewBag.FechaVencimiento = documento.FechaVencimiento;
                    ViewBag.FechaProximaRevision = documento.FechaProximaRevision;

                    ViewBag.dtTipoDocumento = documento.IdTipoDocumento;
                    ViewBag.PalabraClave = documento.PalabraClave;
                    ViewBag.IdTipoArchivo = documento.IdTipoArchivo;
                    ViewBag.IdMedioAlmacenamiento = documento.IdMedioAlmacenamiento;
                    ViewBag.IdClasificacion = documento.IdClasificacion;

                    List<Models.Documento> DocHistorial = documentos.DOC_Versionamiento(doc);
                    ViewBag.Historial = DocHistorial;

                    return View();
                }
                else
                {
                    return RedirectToAction("PrincipalA", "Administracion");
                }


            }
            else { return RedirectToAction("Index", "Home"); }

        }
        public ActionResult Micuenta(Models.Notification _notification, Application.Notification Anotification
            , Application.Sistema ApSistema, Application.PermisosRolElementos APPpermisosRolElementos)
        {
            Models.Sistema sistema = ApSistema.DataSystem();
            ViewBag.Sistema = sistema;
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            List<Models.PermisosRolElementos> PermisosRolElementos = APPpermisosRolElementos.PermisosElementos(Usuario);
            ViewBag.ElementoOculto = PermisosRolElementos;
            if (Usuario != null)
            {
                ViewBag.Nombre = Usuario.Nombre + " " + Usuario.Apellidos;
                ViewBag.Rol = Usuario.NombreRol;
                ViewBag.Foto = Usuario.Inicial;
                _notification.IdUsuario = Usuario.Id;
                List<Models.Notification> notificar = Anotification.SP_listNotification(_notification);
                ViewBag.lisnotifi = notificar;

                Models.Notification CountNoti = Anotification.SP_ConteoNoti(_notification);
                ViewBag.CountNoti = CountNoti;
            }
            else { return RedirectToAction("Index", "Home"); }

            return View();
        }
        public ActionResult Registrar(Models.Notification _notification, Application.Notification Anotification,
            Application.EmpresasListado AempresasListado, Application.Sistema ApSistema, Application.LisUser AlisUser, Application.PermisosRolElementos APPpermisosRolElementos,
            Application.Cat_Roles APPcat_Roles)
        {
            Models.Sistema sistema = ApSistema.DataSystem();
            ViewBag.Sistema = sistema;
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena2 = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            List<Models.PermisosRolElementos> PermisosRolElementos = APPpermisosRolElementos.PermisosElementos(Usuario);
            ViewBag.ElementoOculto = PermisosRolElementos;
            if (Usuario != null)
            {

                ViewBag.Nombre = Usuario.Nombre + " " + Usuario.Apellidos;
                ViewBag.Rol = Usuario.NombreRol;
                ViewBag.Foto = Usuario.Inicial;
                List<Models.LisUser> usuarios = AlisUser.ListadoUsuariosGral();
                ViewBag.lisuser = usuarios;
                _notification.IdUsuario = Usuario.Id;
                List<Models.Notification> notificar = Anotification.SP_listNotification(_notification);
                ViewBag.lisnotifi = notificar;

                Models.Notification CountNoti = Anotification.SP_ConteoNoti(_notification);
                ViewBag.CountNoti = CountNoti;

                List<Models.EmpresasListado> empresasListados = AempresasListado.SP_EmpresasListado();
                ViewBag.empresaLis = empresasListados;


                List<Models.Cat_Roles> rolListado = APPcat_Roles.Cat_Roles_listar();
                ViewBag.Roles = rolListado;

                return View();

            }
            else
            {
                return RedirectToAction("Index", "Home", new { @rd = Application.Cifrado.Encriptar(cadena), @rdv = Application.Cifrado.Encriptar(url) });
            }
        }
        public ActionResult Estadisticas(Models.Notification _notification, Application.Notification Anotification,
        Application.List_Doc list_Doc, Application.Cat_ClasificacionDoc Acat_ClasificacionDoc, Application.Usuarios Ausuarios
            , Application.Sistema ApSistema, Application.PermisosRolElementos APPpermisosRolElementos)
        {
            Models.Sistema sistema = ApSistema.DataSystem();
            ViewBag.Sistema = sistema;
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena2 = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            List<Models.PermisosRolElementos> PermisosRolElementos = APPpermisosRolElementos.PermisosElementos(Usuario);
            ViewBag.ElementoOculto = PermisosRolElementos;
            if (Usuario != null)
            {

                ViewBag.Nombre = Usuario.Nombre + " " + Usuario.Apellidos;
                ViewBag.Rol = Usuario.NombreRol;
                ViewBag.Foto = Usuario.Inicial;
                _notification.IdUsuario = Usuario.Id;
                List<Models.Notification> notificar = Anotification.SP_listNotification(_notification);
                ViewBag.lisnotifi = notificar;

                Models.Notification CountNoti = Anotification.SP_ConteoNoti(_notification);
                ViewBag.CountNoti = CountNoti;

                List<Models.List_Doc> listadoDelete = list_Doc.SP_RegistroDelete();
                ViewBag.listadoDelete = listadoDelete;


                Models.Notification notificationV = Anotification.SP_DocVisto2();
                ViewBag.Visto = notificationV.Ids;

                Models.Notification notificationNV = Anotification.SP_DocNoVisto2();
                ViewBag.NVisto = notificationNV.Ids;

                Models.Cat_ClasificacionDoc conteoclas = Acat_ClasificacionDoc.SP_ConteoClasificacion();
                ViewBag.Conteoclas = conteoclas;

                List<Models.Usuarios> Cusuarios = Ausuarios.SP_ConteoUsuarios();
                ViewBag.Conteouser = Cusuarios;

                List<Models.Usuarios> CusuariosA = Ausuarios.SP_ConteoUsuariosActivos();
                ViewBag.ConteouserA = CusuariosA;

                return View();

            }
            else
            {
                return RedirectToAction("Index", "Home", new { @rd = Application.Cifrado.Encriptar(cadena), @rdv = Application.Cifrado.Encriptar(url) });
            }
        }

















        public string getParents()
        {
            Application.Cat_ClasificacionArchivo cat_ClasificacionArchivo = new Application.Cat_ClasificacionArchivo();
            List<Models.Cat_ClasificacionArchivo> dtClasificacionArchivo = cat_ClasificacionArchivo.Cat_ClasificacionArchivo_Listar();
            string resulCarpetas = "";

            if (dtClasificacionArchivo.Count > 0)
            {
                resulCarpetas += "<ul>";

                foreach (var dt in dtClasificacionArchivo)
                {
                    string variable = "data-jstree='{\"icon\":\"fa fa-folder\"}'";

                    resulCarpetas += "<li id='" + dt.Id + "' " + variable + ">" + dt.Nombre;
                    resulCarpetas += getChildren(dt);
                    resulCarpetas += getDocument(dt);
                    resulCarpetas += "</li>";

                    

            }
                resulCarpetas += "</ul>";
            }

            return resulCarpetas;
        }
        public string getChildren(Models.Cat_ClasificacionArchivo cat_ClasificacionDoc)
        {
            Application.Cat_ClasificacionArchivo cat_ClasificacionArchivo = new Application.Cat_ClasificacionArchivo();
            List<Models.Cat_ClasificacionArchivo> dtSClasificacionArchivo = cat_ClasificacionArchivo.Cat_SubClasificacionArchivo_Listar(cat_ClasificacionDoc);

            string resulCarpetas = "";
            if (dtSClasificacionArchivo.Count > 0)
            {
                resulCarpetas += "<ul>";

                foreach (var dt in dtSClasificacionArchivo)
                {
                    string variable = "data-jstree='{\"icon\":\"fa fa-folder\"}'";

                    resulCarpetas += "<li id='" + dt.Id + "' " + variable + ">" + dt.Nombre; resulCarpetas += getChildren(dt);
                    resulCarpetas += getDocument(dt);
                    resulCarpetas += "</li>";

                }
                resulCarpetas += "</ul>";
            }
            return resulCarpetas;
        }
        public string getDocument(Models.Cat_ClasificacionArchivo cat_ClasificacionDoc)
        {
            Application.Cat_ClasificacionArchivo cat_ClasificacionArchivo = new Application.Cat_ClasificacionArchivo();
            List<Models.Cat_ClasificacionArchivo> dtSClasificacionArchivo = cat_ClasificacionArchivo.SP_DocPadre(cat_ClasificacionDoc);

            string resulDoc = "";

            if (dtSClasificacionArchivo.Count > 0)
            {
                resulDoc += "<ul>";

                foreach (var dt in dtSClasificacionArchivo)
                {
                    string variable = "data-jstree='{\"icon\":\"fa fa-file-text\"}'";
                    resulDoc += "<li id='" + dt.IdDoc + "' " + variable + " onclick='SeleccionarPorId(" + dt.IdDoc + ")'>" + dt.Nombre;
                    resulDoc += "</li>";

                }
                resulDoc += "</ul>";
            }

            return resulDoc;
        }

        [HttpPost]
        public JsonResult desactivarNoti(Models.Notification Dnotificacion, Application.Notification Apnotificacion)
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            Dnotificacion.IdUsuario = Usuario.Id;
            Models.Notification DesactivarNot = Apnotificacion.SP_NotificacionAC(Dnotificacion);

            return Json(DesactivarNot);
        }
        [HttpPost]
        public JsonResult desactivarNotiPrestamo(Models.Notification Dnotificacion, Application.Notification Apnotificacion)
        {
        
            Models.Notification DesactivarNot = Apnotificacion.SP_NotificacionPrestamo(Dnotificacion);

            return Json(DesactivarNot);
        } 
        [HttpPost]
        public JsonResult desactivarNotiPrestamos(Models.Notification Dnotificacion, Application.Notification Apnotificacion)
        {
        
            Models.Notification DesactivarNot = Apnotificacion.SP_DesactivarNPrestamo(Dnotificacion);

            return Json(DesactivarNot);
        }

        [HttpPost]
        public JsonResult DocumentoActualizar(Application.Documentos ApDocumentos, Models.Documento Adoc)
        {
            Models.Documento Ndocumento = ApDocumentos.SP_DocumentoActualizar(Adoc);

            return Json(Ndocumento);
        }
        public JsonResult Departamento_Listar(Models.Cat_ListadoDepartamentos cat_ListadoDepartamentos, Application.Cat_ListadoDepartamentos APcat_ListadoDepartamentos)
        {
            List<Models.Cat_ListadoDepartamentos> cat_ListadoDepartamentoss = APcat_ListadoDepartamentos.SP_LisDep(cat_ListadoDepartamentos);
            return Json(cat_ListadoDepartamentoss);
        }
        public JsonResult Puesto_Listar(Models.Cat_ListadoDepartamentos cat_ListadoDepartamentos, Application.Cat_ListadoDepartamentos APcat_ListadoDepartamentos)
        {
            List<Models.Cat_ListadoDepartamentos> cat_ListadoDepartamentoss = APcat_ListadoDepartamentos.SP_CatEmpresaPuestos(cat_ListadoDepartamentos);
            return Json(cat_ListadoDepartamentoss);
        }
        [HttpPost]
        public JsonResult Usuario_Registrar(Models.Usuarios NuevoUsuario, Application.Usuarios Ausuarios)
        {
            Models.Usuarios Nusuario = Ausuarios.SP_RegistrarUser(NuevoUsuario);

            return Json(Nusuario);
        }
        [HttpPost]
        public JsonResult Usuario_Actualizar(Models.Usuarios UpdateUsuario, Application.Usuarios Ausuarios)
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

            UpdateUsuario.Id = Usuario.Id;
            Models.Usuarios updatesuarios = Ausuarios.SP_ActualizarUsuario(UpdateUsuario);

            return Json(updatesuarios);
        }
        public JsonResult SubClasificacionArchivo_Listar(Models.Cat_ClasificacionArchivo cat_ClasificacionArchivo, Application.Cat_ClasificacionArchivo APcat_ClasificacionArchivo)
        {
            List<Models.Cat_ClasificacionArchivo> clasificacionArchivos = APcat_ClasificacionArchivo.Cat_SubClasificacionArchivo_Listar(cat_ClasificacionArchivo);
            return Json(clasificacionArchivos);
        }

        //EXPIRADO
        [HttpPost]
        public JsonResult DocExpirado(Application.LisUser APlisUser, Application.Correo correo, Application.Notification Anotification)
        {
            List<Models.LisUser> lisUser = APlisUser.SP_UserExpirado();

            foreach (var dtUsuario in lisUser)
            {
                correo.EnvioCorreoExpira(dtUsuario);

            }

            Models.Notification analisis = Anotification.SP_NotiFechaTermino();

            return Json(lisUser);
        }

        public JsonResult SolicitudAceptar(Models.Documento Documento, Application.Documentos ADoc)
        {
            Models.Documento Res = ADoc.SolicitudAceptar(Documento);
            return Json(Res);
        }

        public JsonResult SolicitudNegar(Models.Documento Documento, Application.Documentos ADoc)
        {
            Models.Documento Res = ADoc.SolicitudNegar(Documento);
            return Json(Res);
        }
        [HttpPost]
        public JsonResult DocVersion(Application.Documentos ApDocumentos, Models.Documento Adoc)
        {
            Models.Documento Ndocumento = ApDocumentos.DocVersion(Adoc);

            return Json(Ndocumento);
        }

        [HttpPost]
        public JsonResult Grupo_ListarPor_Id(Models.Grupo Datagrupo, Application.Grupo APPGrupo)
        {
            List<Models.Grupo> Respuesta = APPGrupo.Grupo_ListarPor_Id(Datagrupo);
            return Json(Respuesta);
        }


        [HttpPost]
        public JsonResult GrupoPersona_listar(Models.Grupo Datagrupo, Application.Grupo APPGrupo)
        {
            List<Models.Grupo> Respuesta = APPGrupo.GrupoPersona_listar(Datagrupo);

            return Json(Respuesta);
        }

        [HttpPost]
        public JsonResult GrupoPersona_listarFaltante(Models.Grupo Datagrupo, Application.Grupo APPGrupo)
        {
            List<Models.Grupo> Respuesta = APPGrupo.GrupoPersona_listarFaltante(Datagrupo);

            return Json(Respuesta);
        }


        [HttpPost]
        public JsonResult InsertarGrupoPersona(Models.Grupo Datagrupo, Application.Grupo APPGrupo)
        {
            Models.Grupo Respuesta = APPGrupo.InsertarGrupoPersona(Datagrupo);

            return Json(Respuesta);
        }


        [HttpPost]
        public JsonResult EliminarGrupoPersona(Models.Grupo Datagrupo, Application.Grupo APPGrupo)
        {
            Models.Grupo Respuesta = APPGrupo.EliminarGrupoPersona(Datagrupo);

            return Json(Respuesta);
        }

        [HttpPost]
        public JsonResult EmpresaGrupo_Agregar(Models.Grupo Datagrupo, Application.Grupo APPGrupo)
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

            Datagrupo.IdP = Usuario.Id;
            Models.Grupo Respuesta = APPGrupo.EmpresaGrupo_Agregar(Datagrupo);

            return Json(Respuesta);
        }

        [HttpPost]
        public JsonResult EmpresaGrupo_Eliminar(Models.Grupo Datagrupo, Application.Grupo APPGrupo)
        {
            Models.Grupo Respuesta = APPGrupo.EmpresaGrupo_Eliminar(Datagrupo);

            return Json(Respuesta);
        }


        [HttpPost]
        public JsonResult Cat_ClasificacionArchivo_Listar_Id(Models.Grupo Datacarpeta, Application.Grupo APPGrupo)
        {
            List<Models.Grupo> Respuesta = APPGrupo.Cat_ClasificacionArchivo_Listar_Id(Datacarpeta);
            return Json(Respuesta);
        }

        [HttpPost]
        public JsonResult Cat_ClasificacionArchivo_Listar_Faltante(Models.Grupo Datacarpeta, Application.Grupo APPGrupo)
        {
            List<Models.Grupo> Respuesta = APPGrupo.Cat_ClasificacionArchivo_Listar_Faltante(Datacarpeta);
            return Json(Respuesta);
        }

        [HttpPost]
        public JsonResult Cat_ClasificacionArchivo_Listar_Permiso(Models.Grupo Datacarpeta, Application.Grupo APPGrupo)
        {
            List<Models.Grupo> Respuesta = APPGrupo.Cat_ClasificacionArchivo_Listar_Permiso(Datacarpeta);

            return Json(Respuesta);
        }

        [HttpPost]
        public JsonResult Usuario_Carpeta_Insertar(Models.Grupo Datacarpeta , Application.Grupo APPGrupo)
        {
            List<Models.Grupo> respuestas = new List<Models.Grupo>();

            foreach (var carpetaId in Datacarpeta.IdClist)
            {
                foreach (var usuarioId in Datacarpeta.IdPlist)
                {
                    Models.Grupo Respuesta = APPGrupo.Usuario_Carpeta_Insertar(usuarioId, carpetaId);
                    respuestas.Add(Respuesta);
                }
            }
            return Json(respuestas);

        }

        [HttpPost]
        public JsonResult Usuario_Carpeta_Borrar(Models.Grupo Datacarpeta, Application.Grupo APPGrupo)
        {
            List<Models.Grupo> respuestas = new List<Models.Grupo>();
            foreach (var carpetaId in Datacarpeta.IdClist)
            {
                foreach (var usuarioId in Datacarpeta.IdPlist)
                {
                    Models.Grupo Respuesta = APPGrupo.Usuario_Carpeta_Borrar(usuarioId, carpetaId);
                    respuestas.Add(Respuesta);
                }
            }
            return Json(respuestas);
        }

        [HttpPost]
        public JsonResult Resetearpassword(Models.LisUser Usuario, Application.LisUser ApplisUser)
        {
            Models.LisUser Respuesta = ApplisUser.Resetearpassword(Usuario);

            return Json(Respuesta);
        }







        public string CarpetasPadre()
        {
            Application.Cat_ClasificacionArchivo cat_ClasificacionArchivo = new Application.Cat_ClasificacionArchivo();
            List<Models.Cat_ClasificacionArchivo> dtClasificacionArchivo = cat_ClasificacionArchivo.Cat_ClasificacionArchivo_Listar();
            string resulCarpetas = "";

            if (dtClasificacionArchivo.Count > 0)
            {
                resulCarpetas += "<ul>";

                foreach (var dt in dtClasificacionArchivo)
                {
                    resulCarpetas += "<li id='" + dt.Id + "' data-consultar>" + dt.Nombre;
                    resulCarpetas += Subcarpeta(dt);
                    resulCarpetas += "</li>";
                }
                resulCarpetas += "</ul>";
            }

            return resulCarpetas;
        }
        public string Subcarpeta(Models.Cat_ClasificacionArchivo cat_ClasificacionDoc)
        {
            Application.Cat_ClasificacionArchivo cat_ClasificacionArchivo = new Application.Cat_ClasificacionArchivo();
            List<Models.Cat_ClasificacionArchivo> dtSClasificacionArchivo = cat_ClasificacionArchivo.Cat_SubClasificacionArchivo_Listar(cat_ClasificacionDoc);

            string resulCarpetas = "";
            if (dtSClasificacionArchivo.Count > 0)
            {
                resulCarpetas += "<ul>";
                foreach (var dt in dtSClasificacionArchivo)
                {
                    resulCarpetas += "<li id='" + dt.Id + "' data-consultar>" + dt.Nombre; resulCarpetas += Subcarpeta(dt);
                    resulCarpetas += "</li>";

                }
                resulCarpetas += "</ul>";
            }
            return resulCarpetas;
        }
    }



}
