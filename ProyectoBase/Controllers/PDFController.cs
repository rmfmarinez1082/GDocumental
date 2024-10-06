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
    public class PDFController : Controller
    {
        // GET: PDF
        public ActionResult Index(Application.Documentos documentos, Application.Cat_RutaAlmacenamiento Acat_RutaAlmacenamiento)
        {
                //VISTA PROCEDIMIENTOS

                if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
                {

                    int Id = Convert.ToInt32(Application.Cifrado.Desencriptar(Request.QueryString["Id"]));
                    Models.Documento doc = new Documento();
                    doc.Id = Id;

                    Models.Documento documento = documentos.SP_DocumentoInfo(doc);
                    ViewBag.nombredoc = documento.Nombre;
                    ViewBag.Descripcion = documento.Descripcion;
                    ViewBag.version = documento.Version;
                    ViewBag.NArchivo = documento.NmArchivo;

                    

                    string filePath = HttpContext.Server.MapPath("~") + "DocumentosTemporales" + @"\" + documento.NmArchivo; ;
                    Response.AddHeader("Content-Disposition", "inline; filename=" + documento.NmArchivo);        

                    return File(filePath, "application/pdf");
                }
                else { return View(); }

        }
    }
}