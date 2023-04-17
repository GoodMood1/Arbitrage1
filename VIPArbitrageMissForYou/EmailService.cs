using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;
using VIPArbitrageMissForYou.DL_;

namespace VIPArbitrageMissForYou
{
    public class EmailService
    {
        static string cont = "We sent the letter on your email";
        static string cont2 = "Uncorrect email";
        UpgradeMessageBox uprmess = new UpgradeMessageBox(cont);
        UpgradeMessageBox uprmess2 = new UpgradeMessageBox(cont2);
        const string pattern = @"([A-zА-я])+([0-9\-_\+\.])*([A-zА-я0-9\-_\+\.])*@([A-zА-я])+([0-9\-_\+\.])*([A-zА-я0-9\-_\+\.])*[\.]([A-zА-я])+";
        public void SendEmail(string email, string subjects, string messages)
        {
            try
            {
                if (Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase) && email!=null)
                {
                    AdminoWorld customer = Client.AdminoWorld_.ShowCommandAdmino("1goodmood777@gmail.com");
                    var fromAddress = new MailAddress(customer.MailForNotify, "Good");
                    var toAddress = new MailAddress(email, "Dear Client");
                    string fromPassword = customer.MailPasswordKeyForAccess;
                    string subject = subjects;
                    string body = messages;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                        Timeout = 20000
                    };
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        IsBodyHtml = true,
                        Body = body
                    })
                    {
                        smtp.Send(message);
                    }
                    uprmess.Show();
                }
                else
                {
                    uprmess2.Show();
                }
            }catch (Exception ex)
            {
                cont = ex.Message;
                UpgradeMessageBox uprmess3 = new UpgradeMessageBox(cont);
                uprmess3.Show();
            }
        }
    }
}
