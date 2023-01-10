using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoBase.Application
{
    public class Correo
    {
        public bool EnvioCorreoDocumentoCompartir(Models.Documento documento, Models.LisUser user)
        {
            bool validacion = false;
            WSCorreo.CorreoSoapClient correo1 = new WSCorreo.CorreoSoapClient();
            if (correo1.CorreoMetPrivado("mail.asae.com.mx", 25, "soporte-aplicaciones@asae.com.mx", "$%65hgy#19_", user.EMail.Trim(), "Centro de Información Corporativa de ASAE (CICA)", "Notificacion Nuevo Documento Compartido", FormatoHTMLDocumentoCompartir(documento, user)) == "Correo enviado")
            {
                validacion = true;
            }
            return validacion;
        }

        public string FormatoHTMLDocumentoCompartir(Models.Documento documento, Models.LisUser user)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string result = "";

            result += "<!DOCTYPE html>" +
                      "<html> " +
                      "<head>" +
                        "<title></title>" +
                        "<meta http-equiv='Content-Type' content='text/html; charset=utf-8' />" +
                        "<meta name='viewport' content='width=device-width, initial-scale=1'>" +
                        "<meta http-equiv='X-UA-Compatible' content='IE=edge' />" +
                        "<style type='text/css'>" +
                        "@media screen {" +
                        "@font-face {" +
                        "font-family: 'Lato';" +
                        "font-style: normal;" +
                        "font-weight: 400;" +
                        "src: local('Lato Regular'), local('Lato-Regular'), url(https://fonts.gstatic.com/s/lato/v11/qIIYRU-oROkIk8vfvxw6QvesZW2xOQ-xsNqO47m55DA.woff) format('woff');" +
                        "}" +
                        "@font-face {" +
                        "font-family: 'Lato';" +
                        "font-style: normal;" +
                        "font-weight: 700;" +
                        "src: local('Lato Bold'), local('Lato-Bold'), url(https://fonts.gstatic.com/s/lato/v11/qdgUG4U09HnJwhYI-uK18wLUuEpTyoUstqEm5AMlJo4.woff) format('woff');" +
                        "}" +
                        "@font -face {" +
                        "font-family: 'Lato';" +
                        "font-style: italic;" +
                        "font-weight: 400;" +
                        "src: local('Lato Italic'), local('Lato-Italic'), url(https://fonts.gstatic.com/s/lato/v11/RYyZNoeFgb0l7W3Vu1aSWOvvDin1pK8aKteLpeZ5c0A.woff) format('woff');" +
                        "}" +
                        "@font-face {" +
                        "font-family: 'Lato';" +
                        "font-style: italic;" +
                        "font-weight: 700;" +
                        "src: local('Lato Bold Italic'), local('Lato-BoldItalic'), url(https://fonts.gstatic.com/s/lato/v11/HkF_qI1x_noxlxhrhMQYELO3LdcAZYWl9Si6vvxL-qU.woff) format('woff');" +
                        "}" +
                        "}" +
                        "</style>" +
                    "</head>" +
"<body style='background-color: #f4f4f4; margin: 0 !important; padding: 0 !important;font-family: 'Roboto', sans-serif;'>" +
    "<div style='display: none; font-size: 1px; color: #fefefe; line-height: 1px; font-family: 'Lato', Helvetica, Arial, sans-serif; max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden;'>" +
    "</div>" +
    "<table border='0' cellpadding='0' cellspacing='0' width='100%'>" +
        "<tr>" +
            "<td bgcolor='#448ecd' align='center'>" +
                "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
                    "<tr>" +
                        "<td align='center' valign='top' style='padding: 40px 10px 40px 10px;'> </td>" +
                    "</tr>" +
                "</table>" +
            "</td>" +
        "</tr>" +
        "<tr>" +
            "<td bgcolor='#448ecd' align='center' style='padding: 0px 10px 0px 10px;'>" +
                "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
                    "<tr>" +
                        "<td bgcolor='#ffffff' align='center' valign='top' style='padding: 40px 20px 20px 20px; border-radius: 4px 4px 0px 0px; color: #111111; font-family: 'Roboto', sans-serif; font-size: 48px; font-weight: 400; letter-spacing: 3px; line-height: 48px;'>" +
                            "<img src='https://tickets.asae.com.mx/Imagenes/LogoAsaeTikets.png' width='125' height='120' style='display: block; border: 0px;' />" +
                            "<h1 style='font-size: 40px;font-family: 'Roboto', sans-serif; font-weight: 600; margin: 3; '>Nevo Documento compartido Gestión Documental!</h1>" +
                        "</td>" +
                    "</tr>" +
                "</table>" +
            "</td>" +
        "</tr>" +
        "<tr>" +
            "<td bgcolor='#f4f4f4' align='center' style='padding: 0px 10px 0px 10px;'>" +
                "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
                    "<tr>" +
                        "<td bgcolor='#ffffff' align='left' style='padding: 20px 30px 40px 30px; color: #666666; font-family: 'Roboto', sans-serif;; font-size: 18px; font-weight: 400; line-height: 25px;'>" +
                            "<p style='font-size: 17px;font-family: 'Roboto', sans-serif; font-weight: 10;'>Estimado/a usuario/a: " + user.Nombre + " <br> Se le ha compartido un <strong> Nuevo Documento:" + documento.Nombre + " </strong> , se solicita su apoyo para su lectura.</p>" +
                        "</td>" +
                    "</tr>" +
                    "<tr>" +
                        "<td bgcolor='#AAD2F7' align='center' style='padding: 2px 3px 4px 3px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;'>" +
                            "<h2 style='font-size: 20px;font-family: 'Roboto', sans-serif; font-weight: 10;'><strong>Información del Documento.</strong> </h2>" +
                        "</td>" +
                    "</tr>" +
                    "<tr>" +
                        "<td bgcolor='#ffffff' align='left' style='padding: 20px 30px 40px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 400; line-height: 25px;'>" +
                              //"<p style='margin: 0;font-size: 15px;font-family: 'Roboto', sans-serif; font-weight: 10;'><strong>Empresa :</strong> </p>" +
                              "<p style='margin: 0;font-size: 15px;font-family: 'Roboto', sans-serif; font-weight: 10;'><strong>Titulo :" + documento.Nombre + "</strong> </p>" +
                             // "<p style='margin: 0;font-size: 15px;font-family: 'Roboto', sans-serif; font-weight: 10;'><strong>Compartido por :</strong> </p>" +
                             //"<p style='margin: 0;font-size: 15px;font-family: 'Roboto', sans-serif; font-weight: 10;'><strong>Vigencia :" + documento.Vigencia + "</strong> </p>" +
                             "<p style='margin: 0;font-size: 15px;font-family: 'Roboto', sans-serif; font-weight: 10;'><strong>Descripción :" + documento.Descripcion + "</strong> </p>" +
                             "<p style='margin: 0;font-size: 15px;font-family: 'Roboto', sans-serif; font-weight: 10;'><strong>Versión :" + documento.Version + " </strong> </p>" +
                             "</br>" +
                             "<a style='text-decoration: none; font-size: 20px; font-weight: 600; color: #ffffff; padding-top: 20px; padding-bottom: 20px; padding-left: 40px; padding-right: 40px; background-color: #005BBB;' href='https://" + host + "/Administracion/Vista?Id=" + documento.Id + "'><span>Ver Documento</span></a>" +
                    "</td>" +
                    "</tr>" +
                    "</tr>" +
                    "</tr>" +
                    "</br>" +
                    "<tr>" +
                        "<td bgcolor='#ffffff' align='left' style='padding: 0px 30px 20px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;'>" +
                            "<p style='margin: 0;'>Este correo es de carácter informativo, favor de no responder a esta dirección de correo, ya que no se encuentra habilitada para recibir mensajes. Si necesitas ayuda o deseas contactarnos ponemos a su disposición a los teléfonos correspondientes.</p>" +
                        "</td>" +
                    "</tr>" +
                "</table>" +
            "</td>" +
        "</tr>" +
        "<tr>" +
            "<td bgcolor='#f4f4f4' align='center' style='padding: 30px 10px 0px 10px;'>" +
                "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
                    "<tr>" +
                        "<td bgcolor='#D1E9FF' align='center' style='padding: 30px 30px 30px 30px; border-radius: 4px 4px 4px 4px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;'>" +
                        "</td>" +
                    "</tr>" +
                "</table>" +
            "</td>" +
        "</tr>" +
        "<tr>" +
            "<td bgcolor='#f4f4f4' align='center' style='padding: 0px 10px 0px 10px;'>" +
                "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
                    "<tr>" +
                        "<td bgcolor='#f4f4f4' align='left' style='padding: 0px 30px 30px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 400; line-height: 18px;'> <br>" +
                            "<p style='margin: 0;'>Queda prohibida cualquier revisión, retransmisión, distribución o cualquier otro uso o acción relacionada con esta información, hecha por personas o entidades distintas a los destinatarios a los que ha sido dirigida.</p>" +
                        "</td>" +
                    "</tr>" +
                "</table>" +
            "</td>" +
        "</tr>" +
    "</table>" +
"</body>" +
"</html>";
            return result;
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool EnvioCorreoPrestamo(Models.Documento documento, Models.LisUser user)
        {
            bool validacion = false;
            WSCorreo.CorreoSoapClient correo1 = new WSCorreo.CorreoSoapClient();
            if (correo1.CorreoMetPrivado("mail.asae.com.mx", 25, "soporte-aplicaciones@asae.com.mx", "$%65hgy#19_", user.EMail.Trim(), "Centro de Información Corporativa de ASAE (CICA)", "Notificacion Nuevo Documento Prestado", FormatoHTMLDocumentoPrestamo(documento, user)) == "Correo enviado")
            {
                validacion = true;
            }
            return validacion;
        }

        public string FormatoHTMLDocumentoPrestamo(Models.Documento documento,Models.LisUser user)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string result = "";

            result += "<!DOCTYPE html>" +
                      "<html> " +
                      "<head>" +
                        "<title></title>" +
                        "<meta http-equiv='Content-Type' content='text/html; charset=utf-8' />" +
                        "<meta name='viewport' content='width=device-width, initial-scale=1'>" +
                        "<meta http-equiv='X-UA-Compatible' content='IE=edge' />" +
                        "<style type='text/css'>" +
                        "@media screen {" +
                        "@font-face {" +
                        "font-family: 'Lato';" +
                        "font-style: normal;" +
                        "font-weight: 400;" +
                        "src: local('Lato Regular'), local('Lato-Regular'), url(https://fonts.gstatic.com/s/lato/v11/qIIYRU-oROkIk8vfvxw6QvesZW2xOQ-xsNqO47m55DA.woff) format('woff');" +
                        "}" +
                        "@font-face {" +
                        "font-family: 'Lato';" +
                        "font-style: normal;" +
                        "font-weight: 700;" +
                        "src: local('Lato Bold'), local('Lato-Bold'), url(https://fonts.gstatic.com/s/lato/v11/qdgUG4U09HnJwhYI-uK18wLUuEpTyoUstqEm5AMlJo4.woff) format('woff');" +
                        "}" +
                        "@font -face {" +
                        "font-family: 'Lato';" +
                        "font-style: italic;" +
                        "font-weight: 400;" +
                        "src: local('Lato Italic'), local('Lato-Italic'), url(https://fonts.gstatic.com/s/lato/v11/RYyZNoeFgb0l7W3Vu1aSWOvvDin1pK8aKteLpeZ5c0A.woff) format('woff');" +
                        "}" +
                        "@font-face {" +
                        "font-family: 'Lato';" +
                        "font-style: italic;" +
                        "font-weight: 700;" +
                        "src: local('Lato Bold Italic'), local('Lato-BoldItalic'), url(https://fonts.gstatic.com/s/lato/v11/HkF_qI1x_noxlxhrhMQYELO3LdcAZYWl9Si6vvxL-qU.woff) format('woff');" +
                        "}" +
                        "}" +
                        "</style>" +
                    "</head>" +
"<body style='background-color: #f4f4f4; margin: 0 !important; padding: 0 !important;font-family: 'Roboto', sans-serif;'>" +
    "<div style='display: none; font-size: 1px; color: #fefefe; line-height: 1px; font-family: 'Lato', Helvetica, Arial, sans-serif; max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden;'>" +
    "</div>" +
    "<table border='0' cellpadding='0' cellspacing='0' width='100%'>" +
        "<tr>" +
            "<td bgcolor='#448ecd' align='center'>" +
                "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
                    "<tr>" +
                        "<td align='center' valign='top' style='padding: 40px 10px 40px 10px;'> </td>" +
                    "</tr>" +
                "</table>" +
            "</td>" +
        "</tr>" +
        "<tr>" +
            "<td bgcolor='#448ecd' align='center' style='padding: 0px 10px 0px 10px;'>" +
                "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
                    "<tr>" +
                        "<td bgcolor='#ffffff' align='center' valign='top' style='padding: 40px 20px 20px 20px; border-radius: 4px 4px 0px 0px; color: #111111; font-family: 'Roboto', sans-serif; font-size: 48px; font-weight: 400; letter-spacing: 3px; line-height: 48px;'>" +
                            "<img src='https://tickets.asae.com.mx/Imagenes/LogoAsaeTikets.png' width='125' height='120' style='display: block; border: 0px;' />" +
                            "<h1 style='font-size: 40px;font-family: 'Roboto', sans-serif; font-weight: 600; margin: 3; '>Nevo Documento compartido Gestión Documental!</h1>" +
                        "</td>" +
                    "</tr>" +
                "</table>" +
            "</td>" +
        "</tr>" +
        "<tr>" +
            "<td bgcolor='#f4f4f4' align='center' style='padding: 0px 10px 0px 10px;'>" +
                "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
                    "<tr>" +
                        "<td bgcolor='#ffffff' align='left' style='padding: 20px 30px 40px 30px; color: #666666; font-family: 'Roboto', sans-serif;; font-size: 18px; font-weight: 400; line-height: 25px;'>" +
                            "<p style='font-size: 17px;font-family: 'Roboto', sans-serif; font-weight: 10;'>Estimado/a usuario/a: " + user.Nombre + " <br> se te ha otorgado la custia del documento: " + documento.Nombre + "</p>" +
                        "</td>" +
                    "</tr>" +
                    "<tr>" +
                        "<td bgcolor='#AAD2F7' align='center' style='padding: 2px 3px 4px 3px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;'>" +
                            "<h2 style='font-size: 20px;font-family: 'Roboto', sans-serif; font-weight: 10;'><strong>Información del Documento.</strong> </h2>" +
                        "</td>" +
                    "</tr>" +
                    "<tr>" +
                        "<td bgcolor='#ffffff' align='left' style='padding: 20px 30px 40px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 400; line-height: 25px;'>" +
                              //"<p style='margin: 0;font-size: 15px;font-family: 'Roboto', sans-serif; font-weight: 10;'><strong>Empresa :</strong> </p>" +
                              "<p style='margin: 0;font-size: 15px;font-family: 'Roboto', sans-serif; font-weight: 10;'><strong>Titulo :" + documento.Nombre + "</strong> </p>" +
                             // "<p style='margin: 0;font-size: 15px;font-family: 'Roboto', sans-serif; font-weight: 10;'><strong>Compartido por :</strong> </p>" +
                             //"<p style='margin: 0;font-size: 15px;font-family: 'Roboto', sans-serif; font-weight: 10;'><strong>Vigencia :" + documento.Vigencia + "</strong> </p>" +
                             "<p style='margin: 0;font-size: 15px;font-family: 'Roboto', sans-serif; font-weight: 10;'><strong>Descripción :" + documento.Descripcion + "</strong> </p>" +
                             "<p style='margin: 0;font-size: 15px;font-family: 'Roboto', sans-serif; font-weight: 10;'><strong>Versión :" + documento.Version + " </strong> </p>" +
                             "</br>" +
                             "<a style='text-decoration: none; font-size: 20px; font-weight: 600; color: #ffffff; padding-top: 20px; padding-bottom: 20px; padding-left: 40px; padding-right: 40px; background-color: #005BBB;' href='https://" + host + "'><span>Más Información</span></a>" +
                    "</td>" +
                    "</tr>" +
                    "</tr>" +
                    "</tr>" +
                    "</br>" +
                    "<tr>" +
                        "<td bgcolor='#ffffff' align='left' style='padding: 0px 30px 20px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;'>" +
                            "<p style='margin: 0;'>Este correo es de carácter informativo, favor de no responder a esta dirección de correo, ya que no se encuentra habilitada para recibir mensajes. Si necesitas ayuda o deseas contactarnos ponemos a su disposición a los teléfonos correspondientes.</p>" +
                        "</td>" +
                    "</tr>" +
                "</table>" +
            "</td>" +
        "</tr>" +
        "<tr>" +
            "<td bgcolor='#f4f4f4' align='center' style='padding: 30px 10px 0px 10px;'>" +
                "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
                    "<tr>" +
                        "<td bgcolor='#D1E9FF' align='center' style='padding: 30px 30px 30px 30px; border-radius: 4px 4px 4px 4px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;'>" +
                        "</td>" +
                    "</tr>" +
                "</table>" +
            "</td>" +
        "</tr>" +
        "<tr>" +
            "<td bgcolor='#f4f4f4' align='center' style='padding: 0px 10px 0px 10px;'>" +
                "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
                    "<tr>" +
                        "<td bgcolor='#f4f4f4' align='left' style='padding: 0px 30px 30px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 400; line-height: 18px;'> <br>" +
                            "<p style='margin: 0;'>Queda prohibida cualquier revisión, retransmisión, distribución o cualquier otro uso o acción relacionada con esta información, hecha por personas o entidades distintas a los destinatarios a los que ha sido dirigida.</p>" +
                        "</td>" +
                    "</tr>" +
                "</table>" +
            "</td>" +
        "</tr>" +
    "</table>" +
"</body>" +
"</html>";
            return result;
        }
        //-------------------------------------------------------------------------------------------

        public bool EnvioCorreoExpira(Models.LisUser user)
        {
            bool validacion = false;
            WSCorreo.CorreoSoapClient correo1 = new WSCorreo.CorreoSoapClient();
            if (correo1.CorreoMetPrivado("mail.asae.com.mx", 25, "soporte-aplicaciones@asae.com.mx", "$%65hgy#19_", user.EMail.Trim(), "Centro de Información Corporativa de ASAE (CICA)", "Notificacion Documento Expirado", FormatoHTMLDocumentoExpirado(user)) == "Correo enviado")
            {
                validacion = true;
            }
            return validacion;
        }

        public string FormatoHTMLDocumentoExpirado(Models.LisUser user)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string result = "";

            result += "<!DOCTYPE html>" +
                      "<html> " +
                      "<head>" +
                        "<title></title>" +
                        "<meta http-equiv='Content-Type' content='text/html; charset=utf-8' />" +
                        "<meta name='viewport' content='width=device-width, initial-scale=1'>" +
                        "<meta http-equiv='X-UA-Compatible' content='IE=edge' />" +
                        "<style type='text/css'>" +
                        "@media screen {" +
                        "@font-face {" +
                        "font-family: 'Lato';" +
                        "font-style: normal;" +
                        "font-weight: 400;" +
                        "src: local('Lato Regular'), local('Lato-Regular'), url(https://fonts.gstatic.com/s/lato/v11/qIIYRU-oROkIk8vfvxw6QvesZW2xOQ-xsNqO47m55DA.woff) format('woff');" +
                        "}" +
                        "@font-face {" +
                        "font-family: 'Lato';" +
                        "font-style: normal;" +
                        "font-weight: 700;" +
                        "src: local('Lato Bold'), local('Lato-Bold'), url(https://fonts.gstatic.com/s/lato/v11/qdgUG4U09HnJwhYI-uK18wLUuEpTyoUstqEm5AMlJo4.woff) format('woff');" +
                        "}" +
                        "@font -face {" +
                        "font-family: 'Lato';" +
                        "font-style: italic;" +
                        "font-weight: 400;" +
                        "src: local('Lato Italic'), local('Lato-Italic'), url(https://fonts.gstatic.com/s/lato/v11/RYyZNoeFgb0l7W3Vu1aSWOvvDin1pK8aKteLpeZ5c0A.woff) format('woff');" +
                        "}" +
                        "@font-face {" +
                        "font-family: 'Lato';" +
                        "font-style: italic;" +
                        "font-weight: 700;" +
                        "src: local('Lato Bold Italic'), local('Lato-BoldItalic'), url(https://fonts.gstatic.com/s/lato/v11/HkF_qI1x_noxlxhrhMQYELO3LdcAZYWl9Si6vvxL-qU.woff) format('woff');" +
                        "}" +
                        "}" +
                        "</style>" +
                    "</head>" +
"<body style='background-color: #f4f4f4; margin: 0 !important; padding: 0 !important;font-family: 'Roboto', sans-serif;'>" +
    "<div style='display: none; font-size: 1px; color: #fefefe; line-height: 1px; font-family: 'Lato', Helvetica, Arial, sans-serif; max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden;'>" +
    "</div>" +
    "<table border='0' cellpadding='0' cellspacing='0' width='100%'>" +
        "<tr>" +
            "<td bgcolor='#448ecd' align='center'>" +
                "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
                    "<tr>" +
                        "<td align='center' valign='top' style='padding: 40px 10px 40px 10px;'> </td>" +
                    "</tr>" +
                "</table>" +
            "</td>" +
        "</tr>" +
        "<tr>" +
            "<td bgcolor='#448ecd' align='center' style='padding: 0px 10px 0px 10px;'>" +
                "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
                    "<tr>" +
                        "<td bgcolor='#ffffff' align='center' valign='top' style='padding: 40px 20px 20px 20px; border-radius: 4px 4px 0px 0px; color: #111111; font-family: 'Roboto', sans-serif; font-size: 48px; font-weight: 400; letter-spacing: 3px; line-height: 48px;'>" +
                            "<img src='https://tickets.asae.com.mx/Imagenes/LogoAsaeTikets.png' width='125' height='120' style='display: block; border: 0px;' />" +
                            "<h1 style='font-size: 40px;font-family: 'Roboto', sans-serif; font-weight: 600; margin: 3; '>Nevo Documento compartido Gestión Documental!</h1>" +
                        "</td>" +
                    "</tr>" +
                "</table>" +
            "</td>" +
        "</tr>" +
        "<tr>" +
            "<td bgcolor='#f4f4f4' align='center' style='padding: 0px 10px 0px 10px;'>" +
                "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
                    "<tr>" +
                        "<td bgcolor='#ffffff' align='left' style='padding: 20px 30px 40px 30px; color: #666666; font-family: 'Roboto', sans-serif;; font-size: 18px; font-weight: 400; line-height: 25px;'>" +
                            "<p style='font-size: 17px;font-family: 'Roboto', sans-serif; font-weight: 10;'>Estimado/a usuario/a: " + user.Nombre + " <br> el tiempo de custodia del documento: " + user.Documento + " a expirado.</p>" +
                        "</td>" +
                    "</tr>" +
                   
                    "<tr>" +
                        "<td bgcolor='#ffffff' align='left' style='padding: 20px 30px 40px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 400; line-height: 25px;'>" +
                             "</br>" +
                             "<a style='text-decoration: none; font-size: 20px; font-weight: 600; color: #ffffff; padding-top: 20px; padding-bottom: 20px; padding-left: 40px; padding-right: 40px; background-color: #005BBB;' href='https://" + host + "'><span>Más Información</span></a>" +
                    "</td>" +
                    "</tr>" +
                    "</tr>" +
                    "</tr>" +
                    "</br>" +
                    "<tr>" +
                        "<td bgcolor='#ffffff' align='left' style='padding: 0px 30px 20px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;'>" +
                            "<p style='margin: 0;'>Este correo es de carácter informativo, favor de no responder a esta dirección de correo, ya que no se encuentra habilitada para recibir mensajes. Si necesitas ayuda o deseas contactarnos ponemos a su disposición a los teléfonos correspondientes.</p>" +
                        "</td>" +
                    "</tr>" +
                "</table>" +
            "</td>" +
        "</tr>" +
        "<tr>" +
            "<td bgcolor='#f4f4f4' align='center' style='padding: 30px 10px 0px 10px;'>" +
                "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
                    "<tr>" +
                        "<td bgcolor='#D1E9FF' align='center' style='padding: 30px 30px 30px 30px; border-radius: 4px 4px 4px 4px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;'>" +
                        "</td>" +
                    "</tr>" +
                "</table>" +
            "</td>" +
        "</tr>" +
        "<tr>" +
            "<td bgcolor='#f4f4f4' align='center' style='padding: 0px 10px 0px 10px;'>" +
                "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
                    "<tr>" +
                        "<td bgcolor='#f4f4f4' align='left' style='padding: 0px 30px 30px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 400; line-height: 18px;'> <br>" +
                            "<p style='margin: 0;'>Queda prohibida cualquier revisión, retransmisión, distribución o cualquier otro uso o acción relacionada con esta información, hecha por personas o entidades distintas a los destinatarios a los que ha sido dirigida.</p>" +
                        "</td>" +
                    "</tr>" +
                "</table>" +
            "</td>" +
        "</tr>" +
    "</table>" +
"</body>" +
"</html>";
            return result;
        }


    }
}
