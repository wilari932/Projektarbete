using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel.DataAnnotations;
namespace Projektarbete
{
    class SendMail
    {
        private string CompanyMail;
        private string CompanyPassword;
        private string MailBody;
        public string CustomerMail;

        // Hämtar en sträng i från en text fil och skickar det till Mailbody
        private void GetMailBody(string Order)
        {
            string path = @"Resources/Order/" + Order;
            string ReadMailBody = File.ReadAllText(path);
            MailBody = ReadMailBody;

        }
       
        // skickar mail till kunden eller visar fel om mailen inte har skickas.
        public void SendMailNow(string Order)
        {
            if (Order != null)
            {
                GetMailBody(Order);
                GetMailFiles();

                try
                {
                    SmtpClient client = new SmtpClient();
                    client.Port = 587;
                    client.Host = "smtp.gmail.com";
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential(CompanyMail, CompanyPassword);

                    MailMessage message = new MailMessage(CompanyMail, CustomerMail, "Items you buy", MailBody);
                    message.BodyEncoding = UTF8Encoding.UTF8;

                    message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                    client.Send(message);
                    MessageBox.Show("Your order is complete, wait for you email.");
                }
                catch
                {
                    MessageBox.Show("There is a Error with Email-sender and we cannot send you a email. But the order is completed!");
                }
            }
            else
            {
                MessageBox.Show("The was a error with your order. The order could not be Created!");
            }
        }

        // skickar false  om indatan är ogiltilig (Email)
        public  bool MailIsValid(string Email)
        {
          var Checkmail = new EmailAddressAttribute();
            return Checkmail.IsValid(Email);
        }
        // Hämatar FöretagsMailen i från en txtFil och sparar värden i CompanyMail

       

        private void GetMailFiles()
        {
            try
            {
              


                string path = @"Resources /ProgramFIles/Yourmail.txt";
                List<string> ReadMailfiles = new List<string>();
                ReadMailfiles = File.ReadLines(path).ToList();
                foreach (string s in ReadMailfiles)
                {
                    string[] separator = s.Split(',');

                    CompanyMail = separator[0];
                    CompanyPassword = separator[1];
                }
            }
            catch
            {
               
                MessageBox.Show("Your order was completed, but we cant not send mail right now.");
            }
        }
    }
}