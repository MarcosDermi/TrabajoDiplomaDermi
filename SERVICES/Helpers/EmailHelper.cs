using BE;
using System;
using System.Net;
using System.Net.Mail;

namespace SERVICES.Helpers
{

    public class EmailHelper
    {
        public void EnviarConfirmacionTurno(BEReserva oBEReserva, int iIdReserva)
        {
            var remitente = "cortezemailhelper@gmail.com";
            var contraseña = "fxfu rzgn bfhx dvja";

            var mensaje = new MailMessage();
            mensaje.From = new MailAddress(remitente, "Barberia de Juan Perez");
            mensaje.To.Add(oBEReserva.Cliente.Mail);
            mensaje.Subject = "Confirmación de turno";
            mensaje.Body = $"Hola, tu turno ha sido confirmado para el {oBEReserva.FechaInicio:dddd dd/MM/yyyy HH:mm}. \n Powered by Cortez";
            mensaje.IsBodyHtml = false;

            var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(remitente, contraseña),
                EnableSsl = true
            };

            smtp.Send(mensaje);
        }

        public void EnviarCancelacionTurno(BEReserva oBEReserva, int iIdReserva)
        {
            var remitente = "cortezemailhelper@gmail.com";
            var contraseña = "fxfu rzgn bfhx dvja";

            var mensaje = new MailMessage();
            mensaje.From = new MailAddress(remitente, "Barberia de Juan Perez");
            mensaje.To.Add(oBEReserva.Cliente.Mail);
            mensaje.Subject = "Cancelación de turno";
            mensaje.Body = $"Hola, tu turno del dia {oBEReserva.FechaInicio:dddd dd/MM/yyyy HH:mm}, ha sido cancelado. \n Powered by Cortez";
            mensaje.IsBodyHtml = false;

            var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(remitente, contraseña),
                EnableSsl = true
            };

            smtp.Send(mensaje);
        }
    }

}
