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

                    int Id = Convert.ToInt32(Application.UrlCifrardo.Decrypt(Request.QueryString["Id"]));
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


                    //int Id = 0;
                    //Id = Convert.ToInt32(Request.QueryString["Id"]);
                    //Models.Documento doc = new Documento();
                    //doc.Id = Id;

                    //Models.Documento documento = documentos.SP_DocumentoInfo(doc);
                    //ViewBag.nombredoc = documento.Nombre;
                    //ViewBag.Descripcion = documento.Descripcion;
                    //ViewBag.version = documento.Version;
                    //ViewBag.NArchivo = documento.NmArchivo;

                    //string folderPath = HttpContext.Server.MapPath("~") + "DocumentosTemporales";
                    ////string folderPath = Acat_RutaAlmacenamiento.Cat_RutaAlmacenamiento_temporal().Ruta;
                    //string Portada = HttpContext.Server.MapPath("~") + "\\Images\\PDF\\Portada3.pdf";



                    //PdfReader reader = new PdfReader(Portada);

                    //MemoryStream ms = new MemoryStream();

                    ////rutas de nuestros pdf
                    //string pathPDF = Portada;

                    ////Objeto para leer el pdf original
                    //PdfReader oReader = new PdfReader(pathPDF);
                    ////Objeto que tiene el tamaño de nuestro documento
                    //Rectangle oSize = oReader.GetPageSizeWithRotation(1);
                    ////documento de itextsharp para realizar el trabajo asignandole el tamaño del original
                    //Document oDocument = new Document(oSize);

                    //// Creamos el objeto en el cual haremos la inserción
                    ////FileStream oFS = new FileStream(pathPDF2, FileMode.Create, FileAccess.Write);
                    //PdfWriter oWriter = PdfWriter.GetInstance(oDocument, ms);

                    //oDocument.Open();

                    //string ruta = folderPath + @"\" + documento.NmArchivo;
                    //PdfContentByte cb = oWriter.DirectContent;
                    //var pdfReader2 = new PdfReader(ruta);
                    //var n = pdfReader2.NumberOfPages;
                    //for (var page = 0; page < n;)
                    //{
                    //    oDocument.NewPage();
                    //    PdfImportedPage pagina = oWriter.GetImportedPage(pdfReader2, ++page);
                    //    cb.AddTemplate(pagina, 0, 0);
                    //}

                    //oDocument.Close();

                    //Byte[] FileBuffer = ms.ToArray();

                    //if (FileBuffer != null)
                    //{
                    //    Response.ContentType = "application/pdf";
                    //    Response.AddHeader("content-length", FileBuffer.Length.ToString());
                    //    Response.BinaryWrite(FileBuffer);
                    //}



                    //return View();
                }
                else { return View(); }

        }
    }
}