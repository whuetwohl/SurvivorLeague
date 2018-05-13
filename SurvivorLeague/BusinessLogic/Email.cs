using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using SurvivorLeague.Models;

namespace SurvivorLeague.BusinessLogic
{
    public class Email
    {
        public static void SendConfirmationEmail(Player p, string domain)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Credentials = new NetworkCredential("whuetwohl@gmail.com", "Home7778");
            client.EnableSsl = true;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("whuetwohl@gmail.com");
            msg.To.Add(p.Email);
            msg.Subject = "Test from SurvivorLeague";
            msg.Body = string.Format(@"
                <html>
                <body>
                <div>
                <div>
                <h2 style =""text-align:center""> Welcome to Football Survivor League </h2>
                </div>
                <div>
                <p style=""text-align:center"">You have successfully registered your account.Please <a href=""http://{0}/Account/Confirm?Code={1}""> Click Here </a> to confirm your account</p>
                </div>
                </div>
                </body>
                </html> ", domain, p.ConfirmationCode);
            msg.IsBodyHtml = true;
            client.Send(msg);
            client.Dispose();
            msg.Dispose();
        }
    }
}