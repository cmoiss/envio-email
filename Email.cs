using System;
using static System.Console;
using System.Net.Mail;
using System.Net;

namespace teste_email
{
    class Email
    {
        private const string emailPrincipal = "ocaiomoises@gmail.com";
        private const string emailSecundario = "cmextreme60@gmail.com";
        private const string appPassword = "zkne zmfm lxqo rwoj"; // "Senha de app" gerada pelo gmail

        public static void ProcessarEmail()
        {
            try
            {
                var msg = ConfigurarMensagem();
                var smtp = ConfigurarSmtp();

                smtp.Send(msg);
                smtp.Dispose();
                WriteLine("Email enviado!");
            }
            catch (Exception e)
            {
                WriteLine(e.StackTrace);
                WriteLine(e.Message);
            }
        }

        private static MailMessage ConfigurarMensagem()
        {
            var msg = new MailMessage();

            msg.From = new MailAddress(emailPrincipal, "Caio Souza");
            msg.To.Add(new MailAddress(emailSecundario));
            msg.Subject = "Título do email";
            msg.Body = "Corpo do email";

            return msg;
        }

        private static SmtpClient ConfigurarSmtp()
        {
            var smtp = new SmtpClient();

            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(emailPrincipal, appPassword);
            smtp.Port = 587;

            return smtp;
        }
    }
}