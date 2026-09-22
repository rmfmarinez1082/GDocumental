using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Notification
    {
        ManejoDatos b = new ManejoDatos();


        public Models.Notification SP_Notification(Models.Documento documento, Models.LisUser user,Models.Notification notificationId)
        {
            b.ExecuteCommandSP("SP_Notification");
            b.AddParameter("@IdUsuario", user.Id, SqlDbType.VarChar);
            b.AddParameter("@IdDocumento", documento.Id, SqlDbType.VarChar);
            b.AddParameter("@IdAdmin", notificationId.IdAdmin, SqlDbType.VarChar);
            Models.Notification resultado = new Models.Notification();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {

                resultado.IdUsuario = Convert.ToInt32(reader["IdUsuario"].ToString());
                resultado.IdDocumento = Convert.ToInt32(reader["IdDocumento"].ToString());
                resultado.IdAdmin = Convert.ToInt32(reader["IdAdmin"].ToString());

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        //listar notificación  por id usuario
        public List<Models.Notification> SP_listNotification(Models.Notification notificacion)
        {
            b.ExecuteCommandSP("SP_listNotification");
            b.AddParameter("@IdUser", notificacion.IdUsuario, SqlDbType.VarChar);

            List<Models.Notification> resultado = new List<Models.Notification>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Notification item = new Models.Notification()
                {
                    IdUsuario = Convert.ToInt32(reader["IdUsuario"].ToString()),
                    Id= Convert.ToInt32(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    NombreEmisor = reader["Emisor"].ToString(),
                    Documento = reader["Documento"].ToString(),
                    IdDocumento = Convert.ToInt32(reader["IdDocumento"].ToString()),
                    NmArchivo = reader["NmArchivo"].ToString(),
                    Tnoti = Convert.ToInt32(reader["Tnoti"].ToString()),

                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        //Desactivar  notificacion
        public Models.Notification SP_NotificacionA(Models.Notification notificationA)
        {
            b.ExecuteCommandSP("SP_NotificacionA");
            b.AddParameter("@IdNotificacion", notificationA.Id, SqlDbType.VarChar);
            Models.Notification resultado = new Models.Notification();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {

                resultado.Ids = Convert.ToInt32(reader["Ids"].ToString());

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Notification SP_NotificacionAC(Models.Notification notificationA)
        {
            b.ExecuteCommandSP("SP_NotificacionAC");
            b.AddParameter("@IdUser", notificationA.IdUsuario, SqlDbType.VarChar);
            b.AddParameter("@IdDoc", notificationA.IdDocumento, SqlDbType.VarChar);
            Models.Notification resultado = new Models.Notification();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {

                resultado.Ids = Convert.ToInt32(reader["Ids"].ToString());

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Notification SP_NotificacionPrestamo(Models.Notification notificationA)
        {
            b.ExecuteCommandSP("SP_NotificacionPrestamo");
            b.AddParameter("@Id", notificationA.Id, SqlDbType.VarChar);
            Models.Notification resultado = new Models.Notification();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {

                resultado.Ids = Convert.ToInt32(reader["Ids"].ToString());

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Notification SP_DesactivarNPrestamo(Models.Notification notificationA)
        {
            b.ExecuteCommandSP("SP_DesactivarNPrestamo");
            b.AddParameter("@Id", notificationA.Id, SqlDbType.VarChar);
            Models.Notification resultado = new Models.Notification();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {

                resultado.Ids = Convert.ToInt32(reader["Ids"].ToString());

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        //Conteo de Notificaciones vistas o no vistas

        public Models.Notification SP_DocVisto(Models.Notification DocVisto)
        {
            b.ExecuteCommandSP("SP_DocVisto");
            b.AddParameter("@IdUsuario", DocVisto.IdUsuario, SqlDbType.VarChar);
            Models.Notification resultado = new Models.Notification();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {

                resultado.Ids = Convert.ToInt32(reader["Ids"].ToString());

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public Models.Notification SP_DocNoVisto(Models.Notification DocNoVisto)
        {
            b.ExecuteCommandSP("SP_DocNoVisto");
            b.AddParameter("@IdUsuario", DocNoVisto.IdUsuario, SqlDbType.VarChar);
            Models.Notification resultado = new Models.Notification();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {

                resultado.Ids = Convert.ToInt32(reader["Ids"].ToString());

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        } 
        
        public Models.Notification SP_DocVisto2()
        {
            b.ExecuteCommandSP("SP_DocVisto2");
            Models.Notification resultado = new Models.Notification();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {

                resultado.Ids = Convert.ToInt32(reader["Ids"].ToString());

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public Models.Notification SP_DocNoVisto2()
        {
            b.ExecuteCommandSP("SP_DocNoVisto2");
            Models.Notification resultado = new Models.Notification();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {

                resultado.Ids = Convert.ToInt32(reader["Ids"].ToString());

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Notification SP_Prestamo(Models.Notification notificationId)
        {
            b.ExecuteCommandSP("SP_Prestamo");
            b.AddParameter("@IdUsuario", notificationId.IdUsuario, SqlDbType.VarChar);
            b.AddParameter("@IdDocumento", notificationId.IdDocumento, SqlDbType.VarChar);
            b.AddParameter("@IdAdmin", notificationId.IdAdmin, SqlDbType.VarChar);
            b.AddParameter("@fecha", notificationId.fecha, SqlDbType.DateTime);
            Models.Notification resultado = new Models.Notification();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {

                resultado.Id = Convert.ToInt32(reader["Id"].ToString());


            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Notification SP_ConteoNoti(Models.Notification notificationId)
        {
            b.ExecuteCommandSP("SP_ConteoNoti");
            b.AddParameter("@IdUsuario", notificationId.IdUsuario, SqlDbType.VarChar);
   
            Models.Notification resultado = new Models.Notification();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {

                resultado.Id = Convert.ToInt32(reader["Id"].ToString());


            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Notification SP_NotiFechaTermino()
        {
            b.ExecuteCommandSP("SP_NotiFechaTermino");
            Models.Notification resultado = new Models.Notification();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


    }
}
