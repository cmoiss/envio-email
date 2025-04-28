using System;
using static System.Console;
using System.Net.Mail;
using System.Net;

namespace Programa
{
    class Email
    {
        private const string emailPrincipal = "ocaiomoises@gmail.com";
        private const string emailSecundario = "cmextreme60@gmail.com";
        private const string appPassword = "dodn qnti bwfy kqzr"; // "Senha de app" gerada pelo gmail

        public static void ProcessarEmail()
        {
            try {
                var msg = ConfigurarMensagem();
                var smtp = ConfigurarSmtp();
            
                smtp.Send(msg);
                WriteLine("Email enviado!");
            } catch (System.Exception e) {
                WriteLine(e.StackTrace);
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

            return smtp;
        }
    }
}