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
        public bool EnvioCorreoDocumentoCompartir(Models.Documento documento, Models.LisUser user, Models.Sistema sistema)
        {
            bool validacion = false;
            WSCorreo.CorreoSoapClient correo1 = new WSCorreo.CorreoSoapClient();
            if (correo1.CorreoMetPrivado("mail.asae.com.mx", 25, "soporte-aplicaciones@asae.com.mx", "$%65hgy#19_", user.EMail.Trim(), sistema.NombreSistema, "Notificacion Nuevo Documento Compartido", FormatoHTMLDocumentoCompartir(documento, user, sistema)) == "Correo enviado")
            {
                validacion = true;
            }
            return validacion;
        }

        public string FormatoHTMLDocumentoCompartir(Models.Documento documento, Models.LisUser user, Models.Sistema sistema)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string result = "";

            result += "<!DOCTYPE html>" +
            "<html>" +
            "<head>" +
            "<meta charset='UTF-8'>" +
            "<title>"+sistema.Acronimo+"</title>" +
            "<style>" +
            "body{" +
            "font-family:Arial,sans-serif;" +
            "font-size:16px;" +
            "line-height:1.5;" +
            "color:#333333;" +
            "background-color:#F0F0F0;" +
            "margin:0;" +
            "padding:0;" +
            "}" +
            ".container{" +
            "max-width:600px;" +
            "margin:0 auto;" +
            "text-align:justify;" +
            "height:100vh;" +
            "display:flex;" +
            "flex-direction:column;" +
            "justify-content:center;" +
            "background-color:#F0F0F0;}" +
            "header{" +
            "background-color:#FFFFFF;" +
            "padding:20px;" +
            "border-bottom:1px solid #DDDDDD;" +
            "}" +
            "header h1{" +
            "margin:0;" +
            "font-size:24px;" +
            "color:#333333;" +
            "}" +
            ".content{" +
            "padding:20px;" +
            "background-color:#FFFFFF;"  +
            "}" +
            ".image{" +
            "display:block;" +
            "margin:20px auto;" +
            "max-width:100 %;" +
            "height:auto;" +
            "}" +
            "footer{" +
            "background-color:#FFFFFF;" +
            "padding:20px;" +
            "border-top:1px solid #DDDDDD;" +
            "}" +
            "footer p {" +
            "margin:0;" +
            "font-size:12px;" +
            "color:#666666;" +
            "}" +
            ".content-wrapper{" +
            "padding:10px;" +
            "background-color:#4380c3;" +
            "}" +
            ".content p{" +
            "margin-bottom:1em;" +
            "}" +
            "</style>" +
            "</head>" +
            "<body>" +
            "<div class='container'>" +
            "<header>" +
            "<h1>¡Nuevo documento Compartido en:" + sistema.Acronimo + "</h1>" +
            "</header>" +
            "<div class='content-wrapper'>" +
            "<div class='content'>" +
            "<img src="+sistema.url_Imagen+" width='125' height='120' style='display: block; border: 0px;' />" +
            "<p>Estimado(a) <b style = 'color: red'> " + user.Nombre + " </b>.</p>" +
            "<p> Se ha compartido información importante en un Nuevo Documento, te agradecemos que ingreses al sistema " + sistema.Acronimo + " (" + sistema.NombreSistema + ") con tus credenciales de acceso.En caso de no conocer la liga del sistema, ingresa a la página de "+sistema.NombreEmpresa+"(<b style = 'color: #00f' > "+sistema.url_Sitio+ " </b>) en el apartado de la intranet donde muy fácilmente podrás ingresar.</p>" +
            "<div style = 'border:groove; border-radius: 3px; text-align: center;'> " +
            "<h2><b>Información del Documento.</b></h2>" +
            "</div>" +
            "<ul style='list-style:none;'>" +
            "<li><b> Título:</b>" + documento.Nombre + " </li>" +
            "<p style='margin:0px'>" +
            //"<img src='https://i.postimg.cc/xC96cFGj/ASAEito.png' align='right' width='100px' height='130px' style='margin-left: 20px'>" +
            "<li style='text-align:start;'><b>Descripción:</b>" + documento.Descripcion + "</li>" +
            "<li><b>Versión:</b>" + documento.Version + "</li>" +
            //"<li><b>Fecha de publicación:</b> 3-03-2023</li>" +
            "</p>" +
            "</ul>" +
            "<p>Gracias por su atención.</p>" +
            "</div>" +
            "</div><br>" +
            "<br>" +
            "<footer>" +
            "<p style='margin: 0; font-size: 5px;'>Este correo es de carácter informativo, favor de no responder a esta dirección de correo, ya que no se encuentra habilitada para recibir mensajes.Si necesitas ayuda o deseas contactarnos ponemos a su disposición a los teléfonos correspondientes.</p>" +
            "</footer>" +
            "</div>" +
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
                                    "<h1 style='font-size: 40px;font-family: 'Roboto', sans-serif; font-weight: 600; margin: 3; '>Nuevo prestamo !</h1>" +
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
                                    "<p style='font-size: 17px;font-family: 'Roboto', sans-serif; font-weight: 10;'>Estimado/a usuario/a: <b style='color: red'> " + user.Nombre + "</b> <br> se te ha otorgado la custia del documento: " + documento.Nombre + "</p>" +
                                    "<p> te agradecemos que ingreses al sistema CICA (Centro de Información Corporativa de Asae) con tus credenciales de acceso.En caso de no conocer la liga del sistema, ingresa a la página de Asae (<b style='color: #00f'>www.asae.com.mx</b>) en el apartado de la intranet donde muy fácilmente podrás ingresar.</p>" +
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
                                        "<p>Gracias por su atención.</p>" +
                            //"<a style='text-decoration: none; font-size: 20px; font-weight: 600; color: #ffffff; padding-top: 20px; padding-bottom: 20px; padding-left: 40px; padding-right: 40px; background-color: #005BBB;' href='https://" + host + "'><span>Más Información</span></a>" +
                            "</td>" +
                            "</tr>" +
                            "</tr>" +
                            "</tr>" +
                            "</br>" +
                            "<tr>" +
                                "<td bgcolor='#ffffff' align='left' style='padding: 0px 30px 20px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 10px; font-weight: 100; line-height: 25px;'>" +
                                    "<p style='margin: 0; font-size: 15px;'>Este correo es de carácter informativo, favor de no responder a esta dirección de correo, ya que no se encuentra habilitada para recibir mensajes. Si necesitas ayuda o deseas contactarnos ponemos a su disposición a los teléfonos correspondientes.</p>" +
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
            if (correo1.CorreoMetPrivado("mail.asae.com.mx", 25, "soporte-aplicaciones@asae.com.mx", "$%65hgy#19_", user.EMail.Trim(), "Centro de Información Corporativa de ASAE (CICA)", "Notificacion Prestamo Expirado", FormatoHTMLDocumentoExpirado(user)) == "Correo enviado")
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
                            "<h1 style='font-size: 40px;font-family: 'Roboto', sans-serif; font-weight: 600; margin: 3; '>Prestamo Expirado</h1>" +
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
                            "<p> te agradecemos que ingreses al sistema CICA (Centro de Información Corporativa de Asae) con tus credenciales de acceso.En caso de no conocer la liga del sistema, ingresa a la página de Asae (<b style='color: #00f'>www.asae.com.mx</b>) en el apartado de la intranet donde muy fácilmente podrás ingresar.</p>" +
                        "</td>" +
                    "</tr>" +
                   
                    "<tr>" +
                        "<td bgcolor='#ffffff' align='left' style='padding: 20px 30px 40px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 400; line-height: 25px;'>" +
                             "</br>" +
                            //"<a style='text-decoration: none; font-size: 20px; font-weight: 600; color: #ffffff; padding-top: 20px; padding-bottom: 20px; padding-left: 40px; padding-right: 40px; background-color: #005BBB;' href='https://" + host + "'><span>Más Información</span></a>" +
                            "<p>Gracias por su atención.</p>" +
                    "</td>" +
                    "</tr>" +
                    "</tr>" +
                    "</tr>" +
                    "</br>" +
                    "<tr>" +
                    "<td bgcolor='#f4f4f4' align='center' style='padding: 0px 10px 0px 10px;'>" +
                        "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
                            "<tr>" +
                                "<td bgcolor='#f4f4f4' align='left' style='padding: 0px 30px 30px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 100; line-height: 18px;'> <br>" +
                                    "<p style='margin: 0; font-size: 15px;'>Este correo es de carácter informativo, favor de no responder a esta dirección de correo, ya que no se encuentra habilitada para recibir mensajes. Si necesitas ayuda o deseas contactarnos ponemos a su disposición a los teléfonos correspondientes.</p>" +
                                "</td>" +
                            "</tr>" +
                        "</table>" +
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
