using ProyectoBase.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProyectoBase.Controllers
{
    public class DocumentosController : BaseController
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

        public ActionResult Gestionar(Models.Notification _notification, Application.Notification Anotification,
           Application.Documentos documentos, Application.Menu menu, Models.Notification Dnotificacion, Application.Notification Apnotificacion,
           Application.List_Doc ADetails, Application.Sistema ApSistema, Application.PermisosRolElementos APPpermisosRolElementos)
        {
            Models.Sistema sistema = ApSistema.DataSystem();
            ViewBag.Sistema = sistema;
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadenaCompleta = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;


            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

            List<Models.PermisosRolElementos> PermisosRolElementos = APPpermisosRolElementos.PermisosElementos(Usuario);
            ViewBag.ElementoOculto = PermisosRolElementos;

            if (Usuario != null)
            {

                ViewBag.Nombre = Usuario.Nombre + " " + Usuario.Apellidos;
                ViewBag.Rol = Usuario.NombreRol;
                ViewBag.UsuarioId = Usuario.Id;
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

                    Models.List_Doc info = new List_Doc();
                    info.Id = Id;
                    info.IdSesion = Usuario.Id;
                    List<Models.List_Doc> DetailsDoc = ADetails.DetalleDocCompartido(info);
                    ViewBag.DetailsDoc = DetailsDoc;

                    //CONTROL DE NOTIFICACIONES 
                    Dnotificacion.IdUsuario = Usuario.Id;
                    Dnotificacion.IdDocumento = Id;
                    Models.Notification DesactivarNot = Apnotificacion.SP_NotificacionAC(Dnotificacion);
                    //HISTORIAL
                    List<Models.Documento> DocHistorial = documentos.DOC_Versionamiento(doc);
                    ViewBag.Historial = DocHistorial;
                    return View();
                }
                else { return RedirectToAction("Index", "Home"); }
            }
            else { return RedirectToAction("PrincipalA", "Administracion"); }
        }

        public ActionResult DirectorioFDC(Models.Notification _notification, Application.Notification Anotification, Models.List_Doc _list_Doc, Application.List_Doc Alist_Doc,
            Models.Cat_ClasificacionArchivo cat_ClasificacionDoc, Application.Cat_ClasificacionArchivo cat_ClasificacionArchivo, Application.Sistema ApSistema, Application.PermisosRolElementos APPpermisosRolElementos)
        {
            Models.Sistema sistema = ApSistema.DataSystem();
            ViewBag.Sistema = sistema;
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            List<Models.PermisosRolElementos> PermisosRolElementos = APPpermisosRolElementos.PermisosElementos(Usuario);
            ViewBag.ElementoOculto = PermisosRolElementos;
            if (Usuario != null)
            {
                Models.Cat_ClasificacionArchivo Rorden = cat_ClasificacionArchivo.SP_RESSET2();

                ViewBag.Nombre = Usuario.Nombre + " " + Usuario.Apellidos;
                ViewBag.Rol = Usuario.NombreRol;
                ViewBag.Foto = Usuario.Inicial;
                _notification.IdUsuario = Usuario.Id;
                List<Models.Notification> notificar = Anotification.SP_listNotification(_notification);
                ViewBag.lisnotifi = notificar;

                Models.Notification CountNoti = Anotification.SP_ConteoNoti(_notification);
                ViewBag.CountNoti = CountNoti;

                cat_ClasificacionDoc.IdUser = Usuario.Id;
                //string Carpetas = ObtenerPCustodia2(cat_ClasificacionDoc);
                string Carpetas = ObtenerPCustodia2();

                ViewBag.carpetas = Carpetas;

                return View();
            }
            else { return RedirectToAction("Index", "Home"); }
        }

        public ActionResult EditarCustodia(Models.Notification _notification, Application.Notification Anotification, Application.Documentos documentos,
            Models.Cat_ClasificacionArchivo cat_ClasificacionDoc, Application.Sistema ApSistema, Application.PermisosRolElementos APPpermisosRolElementos)
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
                //DATOS DEL DOCUMENTO
                int Id = Convert.ToInt32(Application.Cifrado.Desencriptar(Request.QueryString["Id"]));
                Models.Documento doc = new Documento();
                doc.Id = Id;

                ViewBag.IdDoc = Id;

                Models.Documento documento = documentos.SP_DocumentoInfo(doc);
                ViewBag.nombredoc = documento.Nombre;

                _notification.IdUsuario = Usuario.Id;
                List<Models.Notification> notificar = Anotification.SP_listNotification(_notification);
                ViewBag.lisnotifi = notificar;
                Models.Notification CountNoti = Anotification.SP_ConteoNoti(_notification);
                ViewBag.CountNoti = CountNoti;

                cat_ClasificacionDoc.IdUser = Usuario.Id;

                string Carpetas = ObtenerPCustodia();
                ViewBag.carpetas = Carpetas;

                documento.IdUsuario = Usuario.Id;
                documento.Id= Id;
                List <Models.Documento> InfoDP = documentos.SP_INF_Prestado(documento);
                ViewBag.CustodiaD = InfoDP;

                return View();
            }
            else { return RedirectToAction("Index", "Home"); }
        }


        // GET: Documentos
        public ActionResult NuevoDocumento(Application.Cat_Tipo_Documento cat_Tipo_Documento,
            Application.Cat_TipoArchivo cat_TipoArchivo, Application.Cat_Almacenamiento_Documento cat_Almacenamiento_Documento,
            Application.Cat_ClasificacionDoc cat_ClasificacionDoc, Application.Cat_ClasificacionArchivo cat_ClasificacionArchivo,
             Models.Notification _notification, Application.Notification Anotification, Application.Sistema ApSistema, Application.PermisosRolElementos APPpermisosRolElementos)
        {


            Models.Sistema sistema = ApSistema.DataSystem();
            ViewBag.Sistema = sistema;
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            ViewBag.Foto = Usuario.Inicial;

            List<Models.PermisosRolElementos> PermisosRolElementos = APPpermisosRolElementos.PermisosElementos(Usuario);
            ViewBag.ElementoOculto = PermisosRolElementos;

            if (Usuario != null)
            {
                Models.Cat_ClasificacionArchivo Rorden = cat_ClasificacionArchivo.SP_RESSET();


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

                ViewBag.Nombre = Usuario.Nombre + " " + Usuario.Apellidos;
                ViewBag.Rol = Usuario.NombreRol;

                _notification.IdUsuario = Usuario.Id;
                List<Models.Notification> notificar = Anotification.SP_listNotification(_notification);
                ViewBag.lisnotifi = notificar;
                Models.Notification CountNoti = Anotification.SP_ConteoNoti(_notification);
                ViewBag.CountNoti = CountNoti;

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
            else { return RedirectToAction("Index", "Home"); }

        }

        public ActionResult VisualizarDocumento(Models.List_Doc _list_Doc, Application.List_Doc Alist_Doc,
            Application.Cat_Entidades entidades, Application.EmpresasListado empresasListado,
            Application.ProvedorListado provedoresListado, Models.Notification _notification, Application.Notification Anotification
            , Application.Sistema ApSistema, Application.PermisosRolElementos APPpermisosRolElementos)
        {
            Models.Sistema sistema = ApSistema.DataSystem();
            ViewBag.Sistema = sistema;
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            List<Models.PermisosRolElementos> PermisosRolElementos = APPpermisosRolElementos.PermisosElementos(Usuario);
            ViewBag.ElementoOculto = PermisosRolElementos;

            // Verificar si la propiedad persisoRuta está presente
            if (PermisosRolElementos.Any(item => item.IdElemento == "RutaArbol"))
            {
                // Si "RutaArbol" está presente, configurar un nuevo ViewBag con el valor 1
                ViewBag.PermisoRutaPresente = 1;
            }

            if (Usuario != null)
            {
                ViewBag.Nombre = Usuario.Nombre + " " + Usuario.Apellidos;
                ViewBag.Rol = Usuario.NombreRol;
                ViewBag.Usuario = Usuario;
                ViewBag.UsuarioId = Usuario.Id;
                ViewBag.Foto = Usuario.Inicial;
                List<Models.Cat_Entidades> dtEntidades = entidades.SP_lisCat_Entidades();
                ViewBag.dtEntidad = dtEntidades;

                List<Models.ProvedorListado> dtprovedorListados = provedoresListado.SP_ProvedoresListado();
                ViewBag.dtprovedorListados = dtprovedorListados;

                List<Models.EmpresasListado> dtEmpresasListado = empresasListado.SP_EmpresasListado();
                ViewBag.dtEmpresasListado = dtEmpresasListado;



                _list_Doc.IdSesion = Usuario.Id;
                List<Models.List_Doc> dtList_Doc = Alist_Doc.SP_ListarDocumentos(_list_Doc);
                ViewBag.dtList_Doc = dtList_Doc;

                _notification.IdUsuario = Usuario.Id;
                List<Models.Notification> notificar = Anotification.SP_listNotification(_notification);
                ViewBag.lisnotifi = notificar;

                Models.Notification CountNoti = Anotification.SP_ConteoNoti(_notification);
                ViewBag.CountNoti = CountNoti;
                return View();
            }
            else { return RedirectToAction("Index", "Home"); }
        }

        public ActionResult DocCompartidos(Models.ListarCompartir _listarCompartir, Application.ListarCompartir AlistarCompartir
            , Models.Notification _notification, Application.Notification Anotification, Application.Sistema ApSistema, Application.PermisosRolElementos APPpermisosRolElementos)

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
                ViewBag.IdUser = Usuario.Id;
                _listarCompartir.IdUsuario = Usuario.Id;
                ViewBag.Foto = Usuario.Inicial;
                List<Models.ListarCompartir> Lcompartir = AlistarCompartir.SP_ListarCompartir(_listarCompartir);
                ViewBag.Compartir = Lcompartir;

                _notification.IdUsuario = Usuario.Id;
                List<Models.Notification> notificar = Anotification.SP_listNotification(_notification);
                ViewBag.lisnotifi = notificar;

                Models.Notification CountNoti = Anotification.SP_ConteoNoti(_notification);
                ViewBag.CountNoti = CountNoti;

                return View();
            }
            else { return RedirectToAction("Index", "Home"); }
        }


        public ActionResult VistaDetalle(Models.Notification _notification, Application.Notification Anotification,
            Application.Documentos documentos, Application.Menu menu, Models.Notification Dnotificacion, Application.Notification Apnotificacion,
            Application.List_Doc ADetails, Application.Sistema ApSistema, Application.PermisosRolElementos APPpermisosRolElementos)
        {
            Models.Sistema sistema = ApSistema.DataSystem();
            ViewBag.Sistema = sistema;
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadenaCompleta = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;


            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            List<Models.PermisosRolElementos> PermisosRolElementos = APPpermisosRolElementos.PermisosElementos(Usuario);
            ViewBag.ElementoOculto = PermisosRolElementos;
            if (Usuario != null)
            {

                ViewBag.Nombre = Usuario.Nombre + " " + Usuario.Apellidos;
                 ViewBag.Rol = Usuario.NombreRol;
                ViewBag.UsuarioId = Usuario.Id;
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
                  
                    //ViewBag.Ruta = "DocumentosTemporales";

                    Models.Documento documentoR = documentos.sp_NombreRutaDoc(doc);
                    ViewBag.Ruta = documentoR.Nombre;

                    //CONTROL DE NOTIFICACIONES 
                    Dnotificacion.IdUsuario = Usuario.Id;
                    Dnotificacion.IdDocumento = Id;
                    Models.Notification DesactivarNot = Apnotificacion.SP_NotificacionAC(Dnotificacion);


                    return View();
                    }
                    else { return RedirectToAction("Index", "Home"); }
                }
            else { return RedirectToAction("PrincipalA", "Administracion"); }
        }

        public ActionResult VistaDetalleAdmin(Models.Notification _notification, Application.Notification Anotification,
            Application.Documentos documentos, Application.Menu menu, Models.Notification Dnotificacion, Application.Notification Apnotificacion,
            Application.List_Doc ADetails, Application.Sistema ApSistema, Application.PermisosRolElementos APPpermisosRolElementos)
        {
            Models.Sistema sistema = ApSistema.DataSystem();
            ViewBag.Sistema = sistema;
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadenaCompleta = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;


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
                //VISTA PROCEDIMIENTOS

                if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    


                    //DATOS DEL DOCUMENTO
                    int Id = Convert.ToInt32(Application.Cifrado.Desencriptar(Request.QueryString["Id"]));
                    Models.Documento doc = new Documento();
                    doc.Id = Id;


                    Models.Documento documento = documentos.SP_DocumentoInfo(doc);
                    ViewBag.nombredoc = documento.Nombre;
                    ViewBag.Descripcion = documento.Descripcion;
                    ViewBag.version = documento.Version;
                    ViewBag.NArchivo = documento.NmArchivo;
                    ViewBag.Ruta = "DocumentosTemporales";

                    Models.List_Doc info = new List_Doc();
                    info.Id = Id;
                    info.IdSesion = Usuario.Id;
                    List<Models.List_Doc> DetailsDoc = ADetails.DetalleDocCompartido(info);
                    ViewBag.DetailsDoc = DetailsDoc;


                    //CONTROL DE NOTIFICACIONES 
                    Dnotificacion.IdUsuario = Usuario.Id;
                    Dnotificacion.IdDocumento = Id;
                    Models.Notification DesactivarNot = Apnotificacion.SP_NotificacionAC(Dnotificacion);


                    return View();
                }
                else { return RedirectToAction("Index", "Home"); }
            }
            else { return RedirectToAction("PrincipalA", "Administracion"); }
        }











        public string ListadoPerfil()
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            Models.Cat_ClasificacionArchivo carpeta = new Models.Cat_ClasificacionArchivo();
            carpeta.Id= Usuario.Id;
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
                    resulCarpetas += "</li>";

                }
                resulCarpetas += "</ul>";
            }
            return resulCarpetas;
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

                    resulCarpetas += "<li id='" + dt.Id + "' " + variable + ">" + dt.Nombre;
                    resulCarpetas += getChildren(dt);
                    resulCarpetas += "</li>";

                }
                resulCarpetas += "</ul>";
            }
            return resulCarpetas;
        }

        public string ObtenerPCustodia()
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            Application.Cat_ClasificacionArchivo cat_ClasificacionArchivo = new Application.Cat_ClasificacionArchivo();
            List<Models.Cat_ClasificacionArchivo> dtClasificacionArchivo = cat_ClasificacionArchivo.cat_DocumentosCustodia();
            string resulCarpetas = "";

            if (dtClasificacionArchivo.Count > 0)
            {
                resulCarpetas += "<ul>";

                foreach (var dt in dtClasificacionArchivo)
                {
                    string var = "data-jstree='{\"opened\":true,\"selected\":false}'";
                    resulCarpetas += "<li id='" + dt.Id + "'" + var + ">" + dt.Nombre;
                    //resulCarpetas += "<li id='" + dt.Id + "'>" + dt.Nombre;
                    resulCarpetas += ObtenerHCustodia(dt);
                    resulCarpetas += ObtenerDocUbicación(dt);

                    resulCarpetas += "</li>";

                }
                resulCarpetas += "</ul>";
            }

            return resulCarpetas;
        }
        public string ObtenerHCustodia(Models.Cat_ClasificacionArchivo cat_ClasificacionDoc)
        {
            Application.Cat_ClasificacionArchivo cat_ClasificacionArchivo = new Application.Cat_ClasificacionArchivo();
            List<Models.Cat_ClasificacionArchivo> dtSClasificacionArchivo = cat_ClasificacionArchivo.cat_DocumentosSubCustodia(cat_ClasificacionDoc);

            string resulCarpetas = "";
            if (dtSClasificacionArchivo.Count > 0)
            {
                resulCarpetas += "<ul>";

                foreach (var dt in dtSClasificacionArchivo)
                {
                    string var = "data-jstree='{\"opened\":true,\"selected\":false}'";

                    resulCarpetas += "<li id='" + dt.Id + "'" + var + "'>" + dt.Nombre;
                    resulCarpetas += ObtenerHCustodia(dt);
                    resulCarpetas += ObtenerDocUbicación(dt);

                    resulCarpetas += "</li>";

                }
                resulCarpetas += "</ul>";
            }
            return resulCarpetas;
        }
        public string ObtenerDocUbicación(Models.Cat_ClasificacionArchivo cat_ClasificacionDoc)
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            Application.Cat_ClasificacionArchivo cat_ClasificacionArchivo = new Application.Cat_ClasificacionArchivo();
            cat_ClasificacionDoc.IdTres = Usuario.Id;

           
            int Id = Convert.ToInt32(Application.Cifrado.Desencriptar(Request.QueryString["Id"]));
            Models.Documento doc = new Documento();
            doc.Id = Id;

            List<Models.Cat_ClasificacionArchivo> dtSClasificacionArchivo = cat_ClasificacionArchivo.SP_DocCustodiaUbicacion(cat_ClasificacionDoc, doc);

            string resulDoc = "";

            if (dtSClasificacionArchivo.Count > 0)
            {
                resulDoc += "<ul>";

                foreach (var dt in dtSClasificacionArchivo)
                {
                    string variable = "data-jstree='{\"selected\" : true,\"icon\":\"fa fa-file-text-o\"}'";
                    resulDoc += "<li " + variable + " onclick='SeleccionarPorId(" + dt.Id + ")'>" + dt.Nombre;
                    resulDoc += "</li>";

                }
                resulDoc += "</ul>";
            }

            return resulDoc;
        }

        public string ObtenerPCustodia2()
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            Application.Cat_ClasificacionArchivo cat_ClasificacionArchivo = new Application.Cat_ClasificacionArchivo();

            List<Models.Cat_ClasificacionArchivo> dtClasificacionArchivo = cat_ClasificacionArchivo.cat_DocumentosCustodia();
            string resulCarpetas = "";

            if (dtClasificacionArchivo.Count > 0)
            {
                resulCarpetas += "<ul>";

                foreach (var dt in dtClasificacionArchivo)
                {
                    string variable = "data-jstree='{\"icon\":\"fa fa-folder\"}'";

                    //string var = "data-jstree='{\"opened\":true,\"selected\":false}'";
                    resulCarpetas += "<li id='" + dt.Id + "' " + variable + ">" + dt.Nombre;
                    //resulCarpetas += "<li id='" + dt.Id + "'" + var + ">" + dt.Nombre;
                    resulCarpetas += ObtenerHCustodia2(dt);
                    resulCarpetas += getDocument(dt);
                    resulCarpetas += "</li>";

                }
                resulCarpetas += "</ul>";
            }

            return resulCarpetas;
        }
        public string ObtenerHCustodia2(Models.Cat_ClasificacionArchivo cat_ClasificacionDoc)
        {
            Application.Cat_ClasificacionArchivo cat_ClasificacionArchivo = new Application.Cat_ClasificacionArchivo();
            List<Models.Cat_ClasificacionArchivo> dtSClasificacionArchivo = cat_ClasificacionArchivo.cat_DocumentosSubCustodia(cat_ClasificacionDoc);

            string resulCarpetas = "";
            if (dtSClasificacionArchivo.Count > 0)
            {
                resulCarpetas += "<ul>";

                foreach (var dt in dtSClasificacionArchivo)
                {
                    string variable = "data-jstree='{\"icon\":\"fa fa-folder\"}'"; 

                    resulCarpetas += "<li id='" + dt.Id + "' " + variable + ">" + dt.Nombre;
                    resulCarpetas += ObtenerHCustodia2(dt);
                    resulCarpetas += getDocument(dt);
                    resulCarpetas += "</li>";

                }
                resulCarpetas += "</ul>";
            }
            return resulCarpetas;
        }
        public string getDocument(Models.Cat_ClasificacionArchivo cat_ClasificacionDoc)
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            Application.Cat_ClasificacionArchivo cat_ClasificacionArchivo = new Application.Cat_ClasificacionArchivo();
            cat_ClasificacionDoc.IdTres = Usuario.Id;
            List<Models.Cat_ClasificacionArchivo> dtSClasificacionArchivo = cat_ClasificacionArchivo.SP_DocPadreCustodia(cat_ClasificacionDoc);

            string resulDoc = "";

            if (dtSClasificacionArchivo.Count > 0)
            {
                resulDoc += "<ul>";

                foreach (var dt in dtSClasificacionArchivo)
                {
                    string variable = "data-jstree='{\"icon\":\"fa fa-file-text\"}'";
                    //string variable = "data-jstree='{\"icon\":\"fa fa-file-text-o\"}'";
                    resulDoc += "<li id='" + dt.Id + "'  " + variable + "onclick='SeleccionarPorId(" + dt.Id + ")'>" + dt.Nombre; //Cambio para identificar el tipo de documento
                    resulDoc += "</li>";

                }
                resulDoc += "</ul>";
            }

            return resulDoc;
        }

        [HttpPost]
        public JsonResult QuitarArchivo(Models.Documento documento, Application.Documentos AppDoc)
        {

            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            documento.IdUsuario = Usuario.Id;
            Models.Documento Ddocument = AppDoc.SP_QuitarArchivo(documento);

            return Json(Ddocument);
        }

        [HttpPost]
        public JsonResult SeleccionarPorId(Models.List_Doc list_Doc, Application.List_Doc APPlist_Doc)
        {
            List<Models.List_Doc> list_Docs = APPlist_Doc.SP_SeleccionarPorId(list_Doc);

            return Json(list_Docs);
        }

        public JsonResult ClasificacionArchivo_Listar(Application.Cat_ClasificacionArchivo cat_ClasificacionArchivo)
        {
            List<Models.Cat_ClasificacionArchivo> dtClasificacionArchivo = cat_ClasificacionArchivo.Cat_ClasificacionArchivo_Listar();

            return Json(dtClasificacionArchivo);
        }

        public JsonResult SubClasificacionArchivo_Listar(Models.Cat_ClasificacionArchivo cat_ClasificacionArchivo, Application.Cat_ClasificacionArchivo APcat_ClasificacionArchivo)
        {
            List<Models.Cat_ClasificacionArchivo> clasificacionArchivos = APcat_ClasificacionArchivo.Cat_SubClasificacionArchivo_Listar(cat_ClasificacionArchivo);
            return Json(clasificacionArchivos);
        }

        public JsonResult SubEntidad_Listar(Models.Cat_listadoGeneral cat_ListadoGeneral, Application.Cat_listadoGeneral APcat_ListadoGeneral)
        {
            List<Models.Cat_listadoGeneral> cat_ListadoGenerals = APcat_ListadoGeneral.SP_listadoGeneral(cat_ListadoGeneral);
            return Json(cat_ListadoGenerals);
        }

        public JsonResult Departamento_Listar(Models.Cat_ListadoDepartamentos cat_ListadoDepartamentos, Application.Cat_ListadoDepartamentos APcat_ListadoDepartamentos)
        {
            List<Models.Cat_ListadoDepartamentos> cat_ListadoDepartamentoss = APcat_ListadoDepartamentos.SP_LisDep(cat_ListadoDepartamentos);
            return Json(cat_ListadoDepartamentoss);
        }
        public JsonResult User_Listar(Models.LisUser lisUser, Application.LisUser APLisUser)
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            lisUser.Id = Usuario.Id;
            List<Models.LisUser> LisUser = APLisUser.SP_LisUser(lisUser);
            return Json(LisUser);
        }

        [HttpPost]
        public JsonResult CargaDocumentos(List<Models.Documento> ListaDocumentos)
        {
            Session["NuevoDocumento"] = ListaDocumentos;

            return Json(ListaDocumentos);
        }
        public JsonResult CargaDocumentosword(List<Models.Documento> ListaDocumentoword)
        {
            Session["NuevoDocumentoword"] = ListaDocumentoword;

            return Json(ListaDocumentoword);
        }

        [HttpPost]
        public JsonResult ConsultaDocumentosSesion()
        {
            List<Models.Documento> ListaDocumentos = new List<Models.Documento>();

            if (Session["NuevoDocumento"] != null)
            {
                ListaDocumentos = (List<Models.Documento>)Session["NuevoDocumento"];

            }

            return Json(ListaDocumentos);
        } 
        [HttpPost]
        public JsonResult ConsultaDocumentosSesionWord()
        {
            List<Models.Documento> ListaDocumentoword = new List<Models.Documento>();

            if (Session["NuevoDocumentoword"] != null)
            {
                ListaDocumentoword = (List<Models.Documento>)Session["NuevoDocumentoword"];

            }

            return Json(ListaDocumentoword);
        }

        [HttpPost]
        public JsonResult Documentos_Registrar(Models.NuevoDocumento nuevoDocumento, Application.Documentos ApDocumentos, Application.Cat_ClasificacionArchivo cat_ClasificacionArchivo,
            Application.Cat_RutaAlmacenamiento APcat_RutaAlmacenamiento)
        {

            List<Models.Documento> ListaDocumentos = new List<Models.Documento>();
            List<Models.Documento> ListaDocumentoword = new List<Models.Documento>();
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

            if (Session["NuevoDocumentoword"] != null)
            {
                ListaDocumentos = (List<Models.Documento>)Session["NuevoDocumento"];
                ListaDocumentoword = (List<Models.Documento>)Session["NuevoDocumentoword"];

                nuevoDocumento.NmArchivo = ListaDocumentos[0].NmArchivo;
                nuevoDocumento.NmArchivoword = ListaDocumentoword[0].NmArchivoword;
                nuevoDocumento.NmOriginal = ListaDocumentos[0].NmOriginal;
                nuevoDocumento.IdUsuario = Usuario.Id;

                Models.Documento Ndocumento = ApDocumentos.Documento_Agregar(nuevoDocumento);

                Models.Cat_ClasificacionArchivo NewCat_ClasificacionArchivo = new Models.Cat_ClasificacionArchivo();


                Models.Cat_ClasificacionArchivo ListaClasificacion = cat_ClasificacionArchivo.Cat_ClasificacionArchivo_Seleccionar(NewCat_ClasificacionArchivo);

                string folderPath = APcat_RutaAlmacenamiento.Cat_RutaAlmacenamiento_Seleccionar().Ruta;


                if (!Directory.Exists(folderPath + @"\" + ListaClasificacion.NombreClasificacion))
                {
                    Directory.CreateDirectory(folderPath + @"\" + ListaClasificacion.NombreClasificacion);
                }

                string DirectorioUsuario = HttpContext.Server.MapPath("~") + "\\DocumentosTemporales\\";
                string sourceFile = System.IO.Path.Combine(DirectorioUsuario, nuevoDocumento.NmArchivo);

                if (ListaClasificacion.NombreClasificacion.Length > 0)
                {

                        string destFile = System.IO.Path.Combine(folderPath + @"\" + ListaClasificacion.NombreClasificacion, nuevoDocumento.NmArchivo);
                        System.IO.File.Copy(sourceFile, destFile, true);
                }

                Session["NuevoDocumento"] = null;
                Session["NuevoDocumentoword"] = null;

                return Json(Ndocumento);
            }
            else
            {
                ListaDocumentos = (List<Models.Documento>)Session["NuevoDocumento"];


                nuevoDocumento.NmArchivo = ListaDocumentos[0].NmArchivo;
                nuevoDocumento.NmOriginal = ListaDocumentos[0].NmOriginal;
                nuevoDocumento.IdUsuario = Usuario.Id;

                Models.Documento Ndocumento = ApDocumentos.Documento_AgregarPDF(nuevoDocumento);


                Models.Cat_ClasificacionArchivo NewCat_ClasificacionArchivo = new Models.Cat_ClasificacionArchivo();


                Models.Cat_ClasificacionArchivo ListaClasificacion = cat_ClasificacionArchivo.Cat_ClasificacionArchivo_Seleccionar(NewCat_ClasificacionArchivo);

                string folderPath = APcat_RutaAlmacenamiento.Cat_RutaAlmacenamiento_Seleccionar().Ruta;


                if (!Directory.Exists(folderPath + @"\" + ListaClasificacion.NombreClasificacion))
                {
                    Directory.CreateDirectory(folderPath + @"\" + ListaClasificacion.NombreClasificacion);
                }

                string DirectorioUsuario = HttpContext.Server.MapPath("~") + "\\DocumentosTemporales\\";
                string sourceFile = System.IO.Path.Combine(DirectorioUsuario, nuevoDocumento.NmArchivo);

                if (ListaClasificacion.NombreClasificacion.Length > 0)
                {
                        string destFile = System.IO.Path.Combine(folderPath + @"\" + ListaClasificacion.NombreClasificacion, nuevoDocumento.NmArchivo);
                        System.IO.File.Copy(sourceFile, destFile, true);
                }

                Session["NuevoDocumento"] = null;

                return Json(Ndocumento);

            }

        }

        [HttpPost]
        public JsonResult RegistrarClas(Models.Cat_ClasificacionArchivo nuevaClas, Application.Cat_ClasificacionArchivo ApnuevaClas)
        {
            Models.Cat_ClasificacionArchivo nuevaClass = ApnuevaClas.SP_AgregarClasArch(nuevaClas);

            return Json(nuevaClass);
        }

        [HttpPost]
        public JsonResult RegistrarSubClas(Models.Cat_ClasificacionArchivo nuevasubClas, Application.Cat_ClasificacionArchivo ApnuevasubClas)
        {
            Models.Cat_ClasificacionArchivo nuevasubClass = ApnuevasubClas.SP_AgregarSubClasArch(nuevasubClas);

            return Json(nuevasubClass);
        } 
        [HttpPost]
        public JsonResult EliminarCarpeta(Models.Cat_ClasificacionArchivo carpeta, Application.Cat_ClasificacionArchivo Apcarpeta)
        {
            Models.Cat_ClasificacionArchivo carpetaD = Apcarpeta.SP_DelClas(carpeta);

            return Json(carpetaD);
        } 
        [HttpPost]
        public JsonResult Renombrar(Models.Cat_ClasificacionArchivo carpeta, Application.Cat_ClasificacionArchivo Apcarpeta)
        {
            Models.Cat_ClasificacionArchivo carpetaD = Apcarpeta.SP_Renombrar(carpeta);

            return Json(carpetaD);
        } 
        
        [HttpPost]
        public JsonResult ActualizarDirectorio(Models.NuevoDocumento nuevoDocumento, Application.Documentos ApDocumentos)
        {

            Models.Documento Ndocumento = ApDocumentos.Documento_custodiaA(nuevoDocumento);

            return Json(Ndocumento);
        }

        [HttpPost]
        public JsonResult Compartir(Models.CCompartir NCompartir, Application.CCompartir ApNCompartir,
            Application.Documentos Apdocumentos, Application.LisUser APlisUser, Application.Correo correo,
            Application.Notification notificacion, Models.Notification notificationId, Application.Sistema ApSistema)
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            

            Models.CCompartir NCompartirr = ApNCompartir.SP_Compartir(NCompartir);
            if (NCompartirr.Id == 1)
            {

                // consultar eldocumento
                Models.Documento documento1 = new Models.Documento();
                documento1.Id = NCompartir.IdDocumento;
                Models.Documento documento = Apdocumentos.SP_ListarDocumento(documento1);
                Models.Sistema sistema = ApSistema.DataSystem();

                Models.LisUser lisUser1 = new Models.LisUser();
                lisUser1.IdEntidad = NCompartir.IdEntidad;
                lisUser1.IdAsignacion = NCompartir.IdAsignacion;
                lisUser1.Id = Usuario.Id;
                List<Models.LisUser> lisUser = APlisUser.SP_ListUserEntidad(lisUser1);

                notificationId.IdAdmin = Usuario.Id;
                foreach (var dtUsuario in lisUser)
                {
                    correo.EnvioCorreoDocumentoCompartir(documento, dtUsuario, sistema);
                    notificacion.SP_Notification(documento, dtUsuario, notificationId);

                }
            }
            return Json(NCompartirr);
        }

        [HttpPost]
        public JsonResult Ncompartir(Models.CCompartir NCompartir, Application.CCompartir ApNCompartir)
        {
            Models.CCompartir NoCompartir = ApNCompartir.FCompartir(NCompartir);
            return Json(NoCompartir);
        }
        public FileResult descargar()
        {
            if (!String.IsNullOrEmpty(Request.QueryString["doc"]))
            {
                string path = Server.MapPath("~/DocumentosTemporales");
                string filename = Request.QueryString["doc"];
                string fullpath = Path.Combine(path, filename);
                string nombre = Request.QueryString["nom"];
                String FileExtension = Path.GetExtension((Request.QueryString["doc"]).ToLower());

                return File(fullpath, "application/docx", nombre + FileExtension);

            }
            else
            {
                return File("~/Documentos/Restringido.pdf", "application/pdf", "Sin_Acceso.pdf");
            }
        }

        [HttpPost]
        public JsonResult Dobligatorio(Models.Cat_Tipo_Documento NDocumento, Application.Cat_Tipo_Documento ANDocumento)
        {
            Models.Cat_Tipo_Documento NTDocumento = ANDocumento.SP_Dobligatorio(NDocumento);

            return Json(NTDocumento);
        }

        //CREACION DE CARPETAS FISICAS
        public JsonResult AgregarSubCarpeta(Models.Cat_ClasificacionArchivo nuevasubClas, Application.Cat_ClasificacionArchivo ApnuevasubClas)
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            nuevasubClas.IdUser = Usuario.Id;

            Models.Cat_ClasificacionArchivo nuevasubClass = ApnuevasubClas.SP_AgregarSubCarpeta(nuevasubClas);

            return Json(nuevasubClass);
        }
        [HttpPost]
        public JsonResult RenombrarCarpeta(Models.Cat_ClasificacionArchivo carpeta, Application.Cat_ClasificacionArchivo Apcarpeta)
        {
            Models.Cat_ClasificacionArchivo carpetaD = Apcarpeta.RenombrarCarpeta(carpeta);

            return Json(carpetaD);
        }
        public JsonResult EliminarCarpetaC(Models.Cat_ClasificacionArchivo carpeta, Application.Cat_ClasificacionArchivo Apcarpeta)
        {
            Models.Cat_ClasificacionArchivo carpetaD = Apcarpeta.EliminarCarpetaC(carpeta);

            return Json(carpetaD);
        }
        public JsonResult RegistrarCarpeta(Models.Cat_ClasificacionArchivo nuevaClas, Application.Cat_ClasificacionArchivo ApnuevaClas)
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            nuevaClas.IdUser = Usuario.Id;
            Models.Cat_ClasificacionArchivo nuevaClass = ApnuevaClas.RegistrarCarpeta(nuevaClas);

            return Json(nuevaClass);
        }

        //PRESTAR
        [HttpPost]
        public JsonResult Prestar(Models.CCompartir NCompartir, Application.CCompartir ApNCompartir,
            Application.Documentos Apdocumentos, Application.LisUser APlisUser, Application.Correo correo,
            Application.Notification notificacion, Models.Notification notificationId)
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            notificationId.IdAdmin = Usuario.Id;
            Models.Notification notifi = notificacion.SP_Prestamo(notificationId);

            if (notifi.Id == 1) { 
                    Models.LisUser lisUser1 = new Models.LisUser();
                    lisUser1.IdPer = notificationId.IdUsuario;
                    List<Models.LisUser> lisUser = APlisUser.SP_LisUserper(lisUser1);


                    Models.Documento documentoInfo = new Models.Documento();
                    documentoInfo.Id = notificationId.IdDocumento;
                    Models.Documento documento = Apdocumentos.SP_ListarDocumento(documentoInfo);


                    foreach (var dtUsuario in lisUser)
                    {
                        correo.EnvioCorreoPrestamo(documento,dtUsuario);

                    }
            }

            return Json(notifi);
        }

        [HttpPost]
        public JsonResult DevolverDoc(Models.Documento documento, Application.Documentos AppDoc)
        {

            //Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            //documento.IdUsuario = Usuario.Id;
            Models.Documento Ddocument = AppDoc.SP_NPrestar(documento);

            return Json(Ddocument);
        }

        [HttpPost]
        public JsonResult MoverRutasCustodia(Models.Cat_ClasificacionArchivo NdN, Application.Cat_ClasificacionArchivo Apcarpeta)
        {
            Models.Cat_ClasificacionArchivo carpetaD = Apcarpeta.SP_DNDCustodia(NdN);

            return Json(carpetaD);
        }
        public JsonResult MoverRutasDocumentoCustodia(Models.Cat_ClasificacionArchivo NdN, Application.Cat_ClasificacionArchivo Apcarpeta)
        {
            Models.Cat_ClasificacionArchivo carpetaD = Apcarpeta.SP_DNDocumentoCustodia(NdN);

            return Json(carpetaD);
        }

        public JsonResult MoverRutasDocumentos(Models.Cat_ClasificacionArchivo NdN, Application.Cat_ClasificacionArchivo Apcarpeta)
        {
            Models.Cat_ClasificacionArchivo carpetaD = Apcarpeta.SP_DNDCarpetas(NdN);

            return Json(carpetaD);
        }

        public JsonResult MoverDocumento(Models.Cat_ClasificacionArchivo NdN, Application.Cat_ClasificacionArchivo Apcarpeta)
        {
            Models.Cat_ClasificacionArchivo carpetaD = Apcarpeta.SP_DNDocumento(NdN);

            return Json(carpetaD);
        }

        [HttpPost]
        public JsonResult DoCompartido(Models.List_Doc list_Doc, Application.List_Doc APlist_Doc)
        {
           List<Models.List_Doc> LisDoc = APlist_Doc.DetalleDocCompartidoAdmin(list_Doc);

            return Json(LisDoc);
        }

        [HttpPost]
        public JsonResult Documentos_Actualizar(Models.NuevoDocumento nuevoDocumento, Application.Documentos ApDocumentos)
        {

            List<Models.Documento> ListaDocumentos = new List<Models.Documento>();
            List<Models.Documento> ListaDocumentoword = new List<Models.Documento>();
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

            if (Session["NuevoDocumentoword"] != null)
            {
                ListaDocumentos = (List<Models.Documento>)Session["NuevoDocumento"];
                ListaDocumentoword = (List<Models.Documento>)Session["NuevoDocumentoword"];


                nuevoDocumento.NmArchivo = ListaDocumentos[0].NmArchivo;
                nuevoDocumento.NmArchivoword = ListaDocumentoword[0].NmArchivoword;
                nuevoDocumento.NmOriginal = ListaDocumentos[0].NmOriginal;
                nuevoDocumento.IdUsuario = Usuario.Id;

                Models.Documento Ndocumento = ApDocumentos.SP_ActualizarDoc(nuevoDocumento);

                Session["NuevoDocumento"] = null;
                Session["NuevoDocumentoword"] = null;

                return Json(Ndocumento);
            }
            else
            {
                ListaDocumentos = (List<Models.Documento>)Session["NuevoDocumento"];


                nuevoDocumento.NmArchivo = ListaDocumentos[0].NmArchivo;
                nuevoDocumento.NmOriginal = ListaDocumentos[0].NmOriginal;
                nuevoDocumento.IdUsuario = Usuario.Id;

                Models.Documento Ndocumento = ApDocumentos.SP_ActualizarDocPDF(nuevoDocumento);

                Session["NuevoDocumento"] = null;

                return Json(Ndocumento);

            }

        }


        [HttpPost]
        public JsonResult UsuarioPosCompartir(Models.LisUser list_User, Application.LisUser APlisUser)
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            list_User.Id = Usuario.Id;

            List<Models.LisUser> lisUser = APlisUser.SP_ListUserEntidad(list_User);

            return Json(lisUser);
        }

        public JsonResult DocumentoInsertarPermiso(Models.Documento Doc, Application.Documentos ADoc)
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            Doc.IdUsuario = Usuario.Id;
            Models.Documento Res = ADoc.DocumentoInsertarPermiso(Doc);

            return Json(Res);
        } 
        
        public JsonResult HabilitarPermisos(Models.Documento Doc, Application.Documentos ADoc)
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            Doc.IdUsuario = Usuario.Id;
            Models.Documento Res = ADoc.HabilitarPermisos(Doc);

            return Json(Res);
        }

        public JsonResult Bloqueop(Models.Documento Doc, Application.Documentos ADoc)
        {
            Models.Documento Res = ADoc.Bloqueop(Doc);

            return Json(Res);
        }
        public JsonResult BloqueopR(Models.Documento Doc, Application.Documentos ADoc)
        {
            Models.Documento Res = ADoc.BloqueopR(Doc);

            return Json(Res);
        } 
        
        public JsonResult DesbloP(Models.Documento Doc, Application.Documentos ADoc)
        {
           //Buscando la forma de obtener id del personal un documneto
            Models.Documento Res = ADoc.DesbloP(Doc);

            return Json(Res);
        }
        public JsonResult RequiereEditable(Models.Cat_Tipo_Documento TDoc, Application.Cat_Tipo_Documento ATDoc)
        {
            Models.Cat_Tipo_Documento Res = ATDoc.ValidarSolicitiudEdit(TDoc);
            return Json(Res);
        }

        public JsonResult SolicitudPDF(Models.Documento Documento, Application.Documentos ADoc)
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            Documento.IdUsuario = Usuario.Id;


            Models.Documento Res = ADoc.SolicitudPDF(Documento);
            return Json(Res);
        }

        public JsonResult InsertarSolicitud(Models.Documento Documento, Application.Documentos ADoc)
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            Documento.IdUsuario = Usuario.Id;


            Models.Documento Res = ADoc.InsertarSolicitud(Documento);
            return Json(Res);
        }


        ///IMPLEMENTACION COMPARTIR POR GRUPOS
        public JsonResult Grupo_Listar(Models.Cat_ListadoDepartamentos Grupo, Application.Cat_ListadoDepartamentos APgrupo)
        {
            List<Models.Cat_ListadoDepartamentos> resultado = APgrupo.EmpresaGrupo_Listar(Grupo);
            return Json(resultado);
        }


        ////VALIDACION FECHAS
        ///
        public JsonResult FechaInterfaz(Models.Documento documento, Application.Documentos Adocumento)
        {
            List<Models.Documento> Res = Adocumento.FechaInterfaz(documento);
            return Json(Res);
        }

    }
}
