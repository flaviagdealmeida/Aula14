using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using Projeto.Util.Models;

namespace Projeto.Util.Services
{
    public class EmailService
    {
        //método para executar o envio do email
        public static void Send(EmailModel model)
        {
            //ler os parametrod do \Web.config.xml
            var from = ConfigurationManager.AppSettings["From"];
            var password = ConfigurationManager.AppSettings["Password"];
            var smtp = ConfigurationManager.AppSettings["Smtp"];
            var port = ConfigurationManager.AppSettings["Port"];

            //criando o email para envio
            var emailFrom = new MailAddress(from);
            var emailTo = new MailAddress(model.To);

            MailMessage mail = new MailMessage(emailFrom, emailTo);
            mail.Subject = model.Subject;
            mail.Body = model.Body;
            mail.IsBodyHtml = model.IsHtml;

            //enviando o email
            SmtpClient client = new SmtpClient(smtp, int.Parse(port));
            client.EnableSsl = true; //habilitar envio encriptado da mensagem
            client.Credentials = new NetworkCredential(from, password);
            client.Send(mail); //enviando a mensagem..
        }
    }
}
