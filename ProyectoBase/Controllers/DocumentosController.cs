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
        // GET: Documentos
        public ActionResult NuevoDocumento(Application.Cat_Tipo_Documento cat_Tipo_Documento,
            Application.Cat_TipoArchivo cat_TipoArchivo, Application.Cat_Almacenamiento_Documento cat_Almacenamiento_Documento,
            Application.Cat_ClasificacionDoc cat_ClasificacionDoc, Application.Cat_ClasificacionArchivo cat_ClasificacionArchivo,
             Models.Notification _notification, Application.Notification Anotification)
        {
            
                Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            if (Usuario != null)
            {
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

            return View();
            }
            else { return RedirectToAction("Index", "Home"); }

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

                if (nuevoDocumento.IdClasificacionArchivo > 0) {
                    if (nuevoDocumento.IdSubClasificacionArchivo > 0) {
                        if (nuevoDocumento.IdNombre3 > 0) {
                            NewCat_ClasificacionArchivo.Id = nuevoDocumento.IdNombre3;
                        }
                        else
                        {
                            NewCat_ClasificacionArchivo.Id = nuevoDocumento.IdSubClasificacionArchivo;
                        }
                    }
                    else
                    {
                        NewCat_ClasificacionArchivo.Id = nuevoDocumento.IdClasificacionArchivo;
                    }

                }

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
                    if (ListaClasificacion.NombreSubcalsificacion.Length > 0)
                    {
                        if (ListaClasificacion.Nombre3.Length > 0)
                        {
                            if (!Directory.Exists(folderPath + @"\" + ListaClasificacion.NombreClasificacion + @"\" + ListaClasificacion.NombreSubcalsificacion + @"\" + ListaClasificacion.Nombre3))
                            {
                                Directory.CreateDirectory(folderPath + @"\" + ListaClasificacion.NombreClasificacion + @"\" + ListaClasificacion.NombreSubcalsificacion + @"\" + ListaClasificacion.Nombre3);
                            }
                            string destFile = System.IO.Path.Combine(folderPath + @"\" + ListaClasificacion.NombreClasificacion + @"\" + ListaClasificacion.NombreSubcalsificacion + @"\" + ListaClasificacion.Nombre3, nuevoDocumento.NmArchivo);
                            System.IO.File.Copy(sourceFile, destFile, true);
                        }
                        else
                        {
                            if (!Directory.Exists(folderPath + @"\" + ListaClasificacion.NombreClasificacion + @"\" + ListaClasificacion.NombreSubcalsificacion))
                            {
                                Directory.CreateDirectory(folderPath + @"\" + ListaClasificacion.NombreClasificacion + @"\" + ListaClasificacion.NombreSubcalsificacion);
                            }
                            string destFile = System.IO.Path.Combine(folderPath + @"\" + ListaClasificacion.NombreClasificacion + @"\" + ListaClasificacion.NombreSubcalsificacion, nuevoDocumento.NmArchivo);
                            System.IO.File.Copy(sourceFile, destFile, true);
                        }
                    }
                    else
                    {
                        string destFile = System.IO.Path.Combine(folderPath + @"\" + ListaClasificacion.NombreClasificacion, nuevoDocumento.NmArchivo);
                        System.IO.File.Copy(sourceFile, destFile, true);
                    }
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

                if (nuevoDocumento.IdClasificacionArchivo > 0)
                {
                    if (nuevoDocumento.IdSubClasificacionArchivo > 0)
                    {
                        if (nuevoDocumento.IdNombre3 > 0)
                        {
                            NewCat_ClasificacionArchivo.Id = nuevoDocumento.IdNombre3;
                        }
                        else
                        {
                            NewCat_ClasificacionArchivo.Id = nuevoDocumento.IdSubClasificacionArchivo;
                        }
                    }
                    else
                    {
                        NewCat_ClasificacionArchivo.Id = nuevoDocumento.IdClasificacionArchivo;
                    }

                }

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
                    if (ListaClasificacion.NombreSubcalsificacion.Length > 0)
                    {
                        if (ListaClasificacion.Nombre3.Length > 0)
                        {
                            if (!Directory.Exists(folderPath + @"\" + ListaClasificacion.NombreClasificacion + @"\" + ListaClasificacion.NombreSubcalsificacion + @"\" + ListaClasificacion.Nombre3))
                            {
                                Directory.CreateDirectory(folderPath + @"\" + ListaClasificacion.NombreClasificacion + @"\" + ListaClasificacion.NombreSubcalsificacion + @"\" + ListaClasificacion.Nombre3);
                            }
                            string destFile = System.IO.Path.Combine(folderPath + @"\" + ListaClasificacion.NombreClasificacion + @"\" + ListaClasificacion.NombreSubcalsificacion + @"\" + ListaClasificacion.Nombre3, nuevoDocumento.NmArchivo);
                            System.IO.File.Copy(sourceFile, destFile, true);
                        }
                        else
                        {
                            if (!Directory.Exists(folderPath + @"\" + ListaClasificacion.NombreClasificacion + @"\" + ListaClasificacion.NombreSubcalsificacion))
                            {
                                Directory.CreateDirectory(folderPath + @"\" + ListaClasificacion.NombreClasificacion + @"\" + ListaClasificacion.NombreSubcalsificacion);
                            }
                            string destFile = System.IO.Path.Combine(folderPath + @"\" + ListaClasificacion.NombreClasificacion + @"\" + ListaClasificacion.NombreSubcalsificacion, nuevoDocumento.NmArchivo);
                            System.IO.File.Copy(sourceFile, destFile, true);
                        }
                    }
                    else
                    {
                        string destFile = System.IO.Path.Combine(folderPath + @"\" + ListaClasificacion.NombreClasificacion, nuevoDocumento.NmArchivo);
                        System.IO.File.Copy(sourceFile, destFile, true);
                    }
                }

                Session["NuevoDocumento"] = null;

                return Json(Ndocumento);

            }

        }

        [HttpPost]
        public JsonResult RegistrarClas(Models.Cat_ClasificacionArchivo nuevaClas, Application.Cat_ClasificacionArchivo ApnuevaClas)
        {
            List<Models.Cat_ClasificacionArchivo> nuevaClass = ApnuevaClas.SP_AgregarClasArch(nuevaClas);

            return Json(nuevaClass);
        }

        [HttpPost]
        public JsonResult RegistrarSubClas(Models.Cat_ClasificacionArchivo nuevasubClas, Application.Cat_ClasificacionArchivo ApnuevasubClas)
        {
            List<Models.Cat_ClasificacionArchivo> nuevasubClass = ApnuevasubClas.SP_AgregarSubClasArch(nuevasubClas);

            return Json(nuevasubClass);
        }

        [HttpPost]
        public JsonResult Compartir(Models.CCompartir NCompartir, Application.CCompartir ApNCompartir,
            Application.Documentos Apdocumentos,Application.LisUser APlisUser,Application.Correo correo,
            Application.Notification notificacion,Models.Notification notificationId)
        {
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            

            Models.CCompartir NCompartirr = ApNCompartir.SP_Compartir(NCompartir);
            if(NCompartirr.Id == 1) { 

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
                    notificacion.SP_Notification(documento,dtUsuario, notificationId);

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
            if (!String.IsNullOrEmpty(Request.QueryString["doc"])) {
                string path = Server.MapPath("~/DocumentosTemporales");
                string filename = Request.QueryString["doc"];
                string fullpath = Path.Combine(path, filename);
                string nombre = Request.QueryString["nom"];
                return File(fullpath, "application/docx", nombre+".docx");
            
            }else
            {
                return File("~/Documentos/Restringido.pdf", "application/pdf",  "Sin_Acceso.pdf");
            }
        }
    }
}
