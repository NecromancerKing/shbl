using SHBL.SPT.BASE.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace SHBL.SPT.UI.WebApi.Helper
{
    public class MailHleper : SafeSingletonProvider<MailHleper>
    {
        public void SendMail(string to, string subject, string body)
        {
            var fromAddress = new MailAddress("oratio.spt@gmail.com");
            var toAddress = new MailAddress(to);
            const string fromPassword = "Fidilio7";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}