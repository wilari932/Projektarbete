using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Windows.Forms;
using System.IO;
namespace Projektarbete
{
    class SendMail
    {
        private string CompanyMail;
        private string CompanyPassword;
        public string CustomerMail;
      

        private void DefaulSendMail()
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(CompanyMail,CompanyPassword);

            MailMessage mm = new MailMessage(CustomerMail, CustomerMail, "Items you Buy", "test");
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);

        }

    private void GetMailFiles()
        {
            try
            {
                string path = @"Resources/ProgramFIles/YourMail.txt";
                List<string> ReadMailfiles = new List<string>();
                ReadMailfiles = File.ReadLines(path).ToList();
                foreach (string s in ReadMailfiles)
                {
                    string[] separator = s.Split(',');

                    separator[0] = CompanyMail;
                    separator[1] = CompanyPassword;
                  

                }


            }
            catch
            {
                MessageBox.Show("Something Is wrong");

            }

            
        }




    }



        }


