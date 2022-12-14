using ProyectoBase.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProyectoBase.Controllers
{
    public class DocumentosController : Controller
    {
        public ActionResult DirectorioFDC(Models.Notification _notification, Application.Notification Anotification, Models.List_Doc _list_Doc, Application.List_Doc Alist_Doc)
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            if (Usuario != null)
            {
                ViewBag.Nombre = Usuario.Nombre + " " + Usuario.Apellidos;
                ViewBag.Rol = Usuario.NombreRol;

                _notification.IdUsuario = Usuario.Id;
                List<Models.Notification> notificar = Anotification.SP_listNotification(_notification);
                ViewBag.lisnotifi = notificar;

                string Carpetas = ObtenerPCustodia2();
                ViewBag.carpetas = Carpetas;

                return View();
            }
            else { return RedirectToAction("Index", "Home"); }
        }

        public ActionResult DCustodia(Models.Notification _notification, Application.Notification Anotification, Models.List_Doc _list_Doc, Application.List_Doc Alist_Doc)
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            if (Usuario != null)
            {
                ViewBag.Nombre = Usuario.Nombre + " " + Usuario.Apellidos;
                ViewBag.Rol = Usuario.NombreRol;

                _notification.IdUsuario = Usuario.Id;
                List<Models.Notification> notificar = Anotification.SP_listNotification(_notification);
                ViewBag.lisnotifi = notificar;

                _list_Doc.IdSesion = Usuario.Id;
                List<Models.List_Doc> dtList_Doc = Alist_Doc.SP_ListarDocumentosCustodia(_list_Doc);
                ViewBag.dtList_Doc = dtList_Doc;

                return View();
            }
            else { return RedirectToAction("Index", "Home"); }
        }

        public ActionResult EditarCustodia(Models.Notification _notification, Application.Notification Anotification, Application.Documentos documentos)
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            if (Usuario != null)
            {
                ViewBag.Nombre = Usuario.Nombre + " " + Usuario.Apellidos;
                ViewBag.Rol = Usuario.NombreRol;

                //DATOS DEL DOCUMENTO
                int Id = 0;
                Id = Convert.ToInt32(Request.QueryString["Id"]);
                Models.Documento doc = new Documento();
                doc.Id = Id;


                Models.Documento documento = documentos.SP_DocumentoInfo(doc);
                ViewBag.nombredoc = documento.Nombre;

                _notification.IdUsuario = Usuario.Id;
                List<Models.Notification> notificar = Anotification.SP_listNotification(_notification);
                ViewBag.lisnotifi = notificar;

                string Carpetas = ObtenerPCustodia();
                ViewBag.carpetas = Carpetas;

                return View();
            }
            else { return RedirectToAction("Index", "Home"); }
        }
        // GET: Documentos
        public ActionResult NuevoDocumento(Application.Cat_Tipo_Documento cat_Tipo_Documento,
            Application.Cat_TipoArchivo cat_TipoArchivo, Application.Cat_Almacenamiento_Documento cat_Almacenamiento_Documento,
            Application.Cat_ClasificacionDoc cat_ClasificacionDoc, Application.Cat_ClasificacionArchivo cat_ClasificacionArchivo,
             Models.Notification _notification, Application.Notification Anotification)
        {

            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
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

                string Carpetas = getParents();
                ViewBag.carpetas = Carpetas;

                return View();
            }
            else { return RedirectToAction("Index", "Home"); }

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
                    string var = "data-jstree='{\"opened\":true,\"selected\":false}'";
                    resulCarpetas += "<li id='" + dt.Id + "'" + var + ">" + dt.Nombre;
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
                    resulCarpetas += "<li id='" + dt.Id +"'>" + dt.Nombre;
                    resulCarpetas += getChildren(dt);
                    resulCarpetas += "</li>";

                }
                resulCarpetas += "</ul>";
            }
            return resulCarpetas;
        }  
        
        
        public string ObtenerPCustodia()
        {
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
                    resulCarpetas += ObtenerHCustodia(dt);
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
                    resulCarpetas += "<li id='" + dt.Id +"'>" + dt.Nombre;
                    resulCarpetas += ObtenerHCustodia(dt);
                    resulCarpetas += "</li>";

                }
                resulCarpetas += "</ul>";
            }
            return resulCarpetas;
        }
        
        public string ObtenerPCustodia2()
        {
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
                    resulCarpetas += "<li id='" + dt.Id +"'>" + dt.Nombre;
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
                    string variable = "data-jstree='{\"icon\":\"fa fa-file-text-o\"}'";
                    resulDoc += "<li " + variable + " onclick='SeleccionarPorId(" + dt.Id + ")'>" + dt.Nombre;
                    resulDoc += "</li>";

                }
                resulDoc += "</ul>";
            }

            return resulDoc;
        }



        //VISTAS USUARIO PRINCIPAL
        public ActionResult VisualizarDocumento(Models.List_Doc _list_Doc, Application.List_Doc Alist_Doc,
            Application.Cat_Entidades entidades, Application.EmpresasListado empresasListado,
            Application.ProvedorListado provedoresListado, Models.Notification _notification, Application.Notification Anotification)
        {

            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            if (Usuario != null)
            {
                ViewBag.Nombre = Usuario.Nombre + " " + Usuario.Apellidos;
                ViewBag.Rol = Usuario.NombreRol;
                ViewBag.Usuario = Usuario;

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

                return View();
            }
            else { return RedirectToAction("Index", "Home"); }
        }

        public ActionResult DocCompartidos(Models.ListarCompartir _listarCompartir, Application.ListarCompartir AlistarCompartir
            , Models.Notification _notification, Application.Notification Anotification)
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            if (Usuario != null)
            {
                ViewBag.Nombre = Usuario.Nombre + " " + Usuario.Apellidos;
                ViewBag.Rol = Usuario.NombreRol;

                _listarCompartir.IdUsuario = Usuario.Id;

                List<Models.ListarCompartir> Lcompartir = AlistarCompartir.SP_ListarCompartir(_listarCompartir);
                ViewBag.Compartir = Lcompartir;

                _notification.IdUsuario = Usuario.Id;
                List<Models.Notification> notificar = Anotification.SP_listNotification(_notification);
                ViewBag.lisnotifi = notificar;


                return View();
            }
            else { return RedirectToAction("Index", "Home"); }
        }


        public ActionResult VistaDetalle(Models.Notification _notification, Application.Notification Anotification,
            Application.Documentos documentos, Application.Menu menu, Models.Notification Dnotificacion, Application.Notification Apnotificacion,
            Application.List_Doc ADetails)
        {

            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadenaCompleta = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;


            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

            if (Usuario != null)
            {

                ViewBag.Nombre = Usuario.Nombre + " " + Usuario.Apellidos;
                 ViewBag.Rol = Usuario.NombreRol;

                _notification.IdUsuario = Usuario.Id;
                List<Models.Notification> notificar = Anotification.SP_listNotification(_notification);
                ViewBag.lisnotifi = notificar;

                //VISTA PROCEDIMIENTOS

                if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    //DATOS DEL DOCUMENTO
                    int Id = 0;
                    Id = Convert.ToInt32(Request.QueryString["Id"]);
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
                    List < Models.List_Doc> DetailsDoc = ADetails.DetalleDocCompartido(info);
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
        public ActionResult VistaDetalleAdmin(Models.Notification _notification, Application.Notification Anotification,
            Application.Documentos documentos, Application.Menu menu, Models.Notification Dnotificacion, Application.Notification Apnotificacion,
            Application.List_Doc ADetails)
        {

            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadenaCompleta = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;


            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

            if (Usuario != null)
            {

                ViewBag.Nombre = Usuario.Nombre + " " + Usuario.Apellidos;
                ViewBag.Rol = Usuario.NombreRol;

                _notification.IdUsuario = Usuario.Id;
                List<Models.Notification> notificar = Anotification.SP_listNotification(_notification);
                ViewBag.lisnotifi = notificar;

                //VISTA PROCEDIMIENTOS

                if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    //DATOS DEL DOCUMENTO
                    int Id = 0;
                    Id = Convert.ToInt32(Request.QueryString["Id"]);
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

                //if (nuevoDocumento.IdClasificacionArchivo > 0)
                //{
                //    if (nuevoDocumento.IdSubClasificacionArchivo > 0)
                //    {
                //        if (nuevoDocumento.IdNombre3 > 0)
                //        {
                //            NewCat_ClasificacionArchivo.Id = nuevoDocumento.IdNombre3;
                //        }
                //        else
                //        {
                //            NewCat_ClasificacionArchivo.Id = nuevoDocumento.IdSubClasificacionArchivo;
                //        }
                //    }
                //    else
                //    {
                //        NewCat_ClasificacionArchivo.Id = nuevoDocumento.IdClasificacionArchivo;
                //    }

                //}

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
                    //if (ListaClasificacion.NombreSubcalsificacion.Length > 0)
                    //{
                    //    if (ListaClasificacion.Nombre3.Length > 0)
                    //    {
                    //        if (!Directory.Exists(folderPath + @"\" + ListaClasificacion.NombreClasificacion + @"\" + ListaClasificacion.NombreSubcalsificacion + @"\" + ListaClasificacion.Nombre3))
                    //        {
                    //            Directory.CreateDirectory(folderPath + @"\" + ListaClasificacion.NombreClasificacion + @"\" + ListaClasificacion.NombreSubcalsificacion + @"\" + ListaClasificacion.Nombre3);
                    //        }
                    //        string destFile = System.IO.Path.Combine(folderPath + @"\" + ListaClasificacion.NombreClasificacion + @"\" + ListaClasificacion.NombreSubcalsificacion + @"\" + ListaClasificacion.Nombre3, nuevoDocumento.NmArchivo);
                    //        System.IO.File.Copy(sourceFile, destFile, true);
                    //    }
                    //    else
                    //    {
                    //        if (!Directory.Exists(folderPath + @"\" + ListaClasificacion.NombreClasificacion + @"\" + ListaClasificacion.NombreSubcalsificacion))
                    //        {
                    //            Directory.CreateDirectory(folderPath + @"\" + ListaClasificacion.NombreClasificacion + @"\" + ListaClasificacion.NombreSubcalsificacion);
                    //        }
                    //        string destFile = System.IO.Path.Combine(folderPath + @"\" + ListaClasificacion.NombreClasificacion + @"\" + ListaClasificacion.NombreSubcalsificacion, nuevoDocumento.NmArchivo);
                    //        System.IO.File.Copy(sourceFile, destFile, true);
                    //    }
                    //}
                    //else
                    //{
                        string destFile = System.IO.Path.Combine(folderPath + @"\" + ListaClasificacion.NombreClasificacion, nuevoDocumento.NmArchivo);
                        System.IO.File.Copy(sourceFile, destFile, true);
                    //}
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

                //if (nuevoDocumento.IdClasificacionArchivo > 0)
                //{
                //    if (nuevoDocumento.IdSubClasificacionArchivo > 0)
                //    {
                //        if (nuevoDocumento.IdNombre3 > 0)
                //        {
                //            NewCat_ClasificacionArchivo.Id = nuevoDocumento.IdNombre3;
                //        }
                //        else
                //        {
                //            NewCat_ClasificacionArchivo.Id = nuevoDocumento.IdSubClasificacionArchivo;
                //        }
                //    }
                //    else
                //    {
                //        NewCat_ClasificacionArchivo.Id = nuevoDocumento.IdClasificacionArchivo;
                //    }

                //}

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
                    //if (ListaClasificacion.NombreSubcalsificacion.Length > 0)
                    //{
                    //    if (ListaClasificacion.Nombre3.Length > 0)
                    //    {
                    //        if (!Directory.Exists(folderPath + @"\" + ListaClasificacion.NombreClasificacion + @"\" + ListaClasificacion.NombreSubcalsificacion + @"\" + ListaClasificacion.Nombre3))
                    //        {
                    //            Directory.CreateDirectory(folderPath + @"\" + ListaClasificacion.NombreClasificacion + @"\" + ListaClasificacion.NombreSubcalsificacion + @"\" + ListaClasificacion.Nombre3);
                    //        }
                    //        string destFile = System.IO.Path.Combine(folderPath + @"\" + ListaClasificacion.NombreClasificacion + @"\" + ListaClasificacion.NombreSubcalsificacion + @"\" + ListaClasificacion.Nombre3, nuevoDocumento.NmArchivo);
                    //        System.IO.File.Copy(sourceFile, destFile, true);
                    //    }
                    //    else
                    //    {
                    //        if (!Directory.Exists(folderPath + @"\" + ListaClasificacion.NombreClasificacion + @"\" + ListaClasificacion.NombreSubcalsificacion))
                    //        {
                    //            Directory.CreateDirectory(folderPath + @"\" + ListaClasificacion.NombreClasificacion + @"\" + ListaClasificacion.NombreSubcalsificacion);
                    //        }
                    //        string destFile = System.IO.Path.Combine(folderPath + @"\" + ListaClasificacion.NombreClasificacion + @"\" + ListaClasificacion.NombreSubcalsificacion, nuevoDocumento.NmArchivo);
                    //        System.IO.File.Copy(sourceFile, destFile, true);
                    //    }
                    //}
                    //else
                    //{
                        string destFile = System.IO.Path.Combine(folderPath + @"\" + ListaClasificacion.NombreClasificacion, nuevoDocumento.NmArchivo);
                        System.IO.File.Copy(sourceFile, destFile, true);
                    //}
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
            Application.Notification notificacion, Models.Notification notificationId)
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];


            Models.CCompartir NCompartirr = ApNCompartir.SP_Compartir(NCompartir);
            if (NCompartirr.Id == 1)
            {

                // consultar eldocumento
                Models.Documento documento1 = new Models.Documento();
                documento1.Id = NCompartir.IdDocumento;
                Models.Documento documento = Apdocumentos.SP_ListarDocumento(documento1);

                Models.LisUser lisUser1 = new Models.LisUser();
                //lisUser1.IdAdmin = Usuario.Id;
                lisUser1.IdEntidad = NCompartir.IdEntidad;
                lisUser1.IdAsignacion = NCompartir.IdAsignacion;
                List<Models.LisUser> lisUser = APlisUser.SP_ListUserEntidad(lisUser1);

                notificationId.IdAdmin = Usuario.Id;
                foreach (var dtUsuario in lisUser)
                {
                    correo.EnvioCorreoDocumentoCompartir(documento, dtUsuario);
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
    }
}
