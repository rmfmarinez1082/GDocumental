using ProyectoBase.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class ImagenController : Controller
    {
        // GET: Imagen
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubirImagen(IEnumerable<HttpPostedFileBase> files)
        {
            var lista = Session["ImgList"] as List<Img> ?? new List<Img>();

            var carpetaDestino = @"C:\filesCID";
            if (!Directory.Exists(carpetaDestino))
                Directory.CreateDirectory(carpetaDestino);

            foreach (var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var ext = Path.GetExtension(file.FileName).ToLower();
                    var nombreOriginal = Path.GetFileName(file.FileName);
                    var nombreEncriptado = Guid.NewGuid().ToString() + ext;
                    var rutaCompleta = Path.Combine(carpetaDestino, nombreEncriptado);

                    file.SaveAs(rutaCompleta);

                    lista.Add(new Img
                    {
                        NmArchivo = nombreEncriptado,
                        NmOriginal = nombreOriginal,
                        Extension = ext
                    });
                }
            }

            Session["ImgList"] = lista;

            return Json(new { success = true });
        }


        [HttpGet]
        public ActionResult ObtenerImagenesSesion()
        {
            var lista = Session["ImgList"] as List<Img> ?? new List<Img>();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public FileResult VerImagen(string nombre)
        {
            var ruta = Path.Combine(@"C:\filesCID", nombre);
            var tipoMime = MimeMapping.GetMimeMapping(nombre);
            return File(ruta, tipoMime);
        }

        [HttpPost]
        public ActionResult EliminarImagen(string nombre)
        {
            var lista = Session["ImgList"] as List<Img>;
            if (lista == null) return Json(new { success = false, message = "No hay sesión." });

            var imagen = lista.FirstOrDefault(i => i.NmArchivo == nombre);
            if (imagen != null)
            {
                // Eliminar el archivo físico
                //var ruta = Path.Combine(@"C:\filesCID", imagen.NmArchivo);
                //if (System.IO.File.Exists(ruta))
                //    System.IO.File.Delete(ruta);

                // Eliminar de la lista en sesión
                lista.Remove(imagen);
                Session["ImgList"] = lista;
                return Json(new { success = true });
            }

            return Json(new { success = false, message = "Imagen no encontrada." });
        }

        [HttpPost]
        public JsonResult RegistrarImg(Models.NuevoDocumento Registro, Application.Documentos ApDocumentos, Application.Cat_ClasificacionArchivo cat_ClasificacionArchivo,
            Application.Cat_RutaAlmacenamiento APcat_RutaAlmacenamiento)
        {
            var listaImg = Session["ImgList"] as List<Img> ?? new List<Img>();
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            Registro.IdUsuario = Usuario.Id;

            Models.Documento Ndocumento = ApDocumentos.DocumentoImagenAgregar(Registro);

            foreach (Img img in listaImg) {
                img.IdDoc = Ndocumento.Id;
                //FOREACH A LA LISTA listaImg
                ApDocumentos.INSERTARImagenDocumento(img);
            }

            Session["ImgList"] = null;
            return Json(Ndocumento);
        }

    }
}