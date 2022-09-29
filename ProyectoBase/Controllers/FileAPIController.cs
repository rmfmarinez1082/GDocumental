using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ProyectoBase.Controllers
{
    public class FileAPIController : ApiController
    {
        // GET: FileAPI
        [Route("api/FileAPI/UploadFilesArticulo")]
        [HttpPost]
        public HttpResponseMessage UploadFilesArticulo()
        {
            string DirectorioUsuario = HttpContext.Current.Server.MapPath("~") + "\\DocumentosTemporales\\";
            string DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\DocumentosTemporales\\";
            Application.Control_Archivos control_Archivos = new Application.Control_Archivos();
            List<Models.Documento> LstDocumento = new List<Models.Documento>();

            for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
            {
                HttpPostedFile POT = HttpContext.Current.Request.Files[i];
                Models.Documento _documento = new Models.Documento();
                _documento = control_Archivos.NuevoArchivo(POT, DirectorioUsuario, DirectorioURL);
                if (_documento.NmArchivo != null)
                {
                    LstDocumento.Add(_documento);
                }
            }

            //Send OK Response to Client.
            return Request.CreateResponse(HttpStatusCode.OK, LstDocumento);
        }  
        public HttpResponseMessage SubirWord()
        {
            string DirectorioUsuario = HttpContext.Current.Server.MapPath("~") + "\\DocumentosTemporales\\";
            string DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\DocumentosTemporales\\";
            Application.Control_Archivos control_Archivos = new Application.Control_Archivos();
            List<Models.Documento> LstDocumento = new List<Models.Documento>();

            for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
            {
                HttpPostedFile POT = HttpContext.Current.Request.Files[i];
                Models.Documento _documento = new Models.Documento();
                _documento = control_Archivos.NuevoArchivoword(POT, DirectorioUsuario, DirectorioURL);
                if (_documento.NmArchivoword != null)
                {
                    LstDocumento.Add(_documento);
                }
            }

            //Send OK Response to Client.
            return Request.CreateResponse(HttpStatusCode.OK, LstDocumento);
        }
    }
}
