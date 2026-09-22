using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Notification
    {
        Data.Notification _notification = new Data.Notification();

        public Models.Notification SP_Notification(Models.Documento documento, Models.LisUser user, Models.Notification notificationId)
        {
            return _notification.SP_Notification(documento,user, notificationId);
        }
        public Models.Notification SP_Prestamo(Models.Notification notificationId)
        {
            return _notification.SP_Prestamo(notificationId);

        }


        public List<Models.Notification> SP_listNotification(Models.Notification notificacion)
        {
            return _notification.SP_listNotification(notificacion);
        }

        public Models.Notification SP_NotificacionA(Models.Notification notificationA)
        {
            return _notification.SP_NotificacionA(notificationA);
        }

        public Models.Notification SP_NotificacionAC(Models.Notification notificationA)
        {
            return _notification.SP_NotificacionAC(notificationA);
        } 
        public Models.Notification SP_NotificacionPrestamo(Models.Notification notificationA)
        {
            return _notification.SP_NotificacionPrestamo(notificationA);
        }
        public Models.Notification SP_DesactivarNPrestamo(Models.Notification notificationA)
        {
            return _notification.SP_DesactivarNPrestamo(notificationA);
        }

        public Models.Notification SP_DocVisto(Models.Notification DocVisto)
        {
            return _notification.SP_DocVisto(DocVisto);
        }

        public Models.Notification SP_DocNoVisto(Models.Notification DocNoVisto)
        {
            return _notification.SP_DocNoVisto(DocNoVisto);
        } 
        public Models.Notification SP_DocVisto2()
        {
            return _notification.SP_DocVisto2();
        }

        public Models.Notification SP_DocNoVisto2()
        {
            return _notification.SP_DocNoVisto2();
        }
        public Models.Notification SP_ConteoNoti(Models.Notification notificationId)
        {
            return _notification.SP_ConteoNoti(notificationId);

        }
        public Models.Notification SP_NotiFechaTermino()
        {
            return _notification.SP_NotiFechaTermino();
        }
    }
}
