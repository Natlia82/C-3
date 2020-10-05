using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace NewWPF
{
    class SendMail
    {
        private string from = "vagapova_n@mail.ru";
        private string to = "vagapova_n@mail.ru";
        private string pass;
        private string topic = "тема Х";
        private string letter = "письмо";


        public SendMail(string from, string pass, string to, string topic, string letter)
        {
            this.from = from;
            this.pass = pass;
            this.to = to;
            this.topic = topic;
            this.letter = letter;
        }

        private void MailOut()
        {
            //формирование письма
             
            MailMessage mm = new MailMessage(this.from, this.from);
            mm.Subject = this.topic;
            mm.Body = this.letter;
            mm.IsBodyHtml = false; // Не используем html в теле письма


            // Авторизуемся на smtp-сервере и отправляем письмо
            SmtpClient sc = new SmtpClient(SmtpServer(this.from), Port(SmtpServer(this.from)));
            sc.EnableSsl = true;
            sc.DeliveryMethod = SmtpDeliveryMethod.Network;
            sc.UseDefaultCredentials = false;
            
            sc.Credentials = new NetworkCredential(this.from, this.pass);
            // sc.Send(mm);
            try
            {
                sc.Send(mm);
                MessageBox.Show("письмо отправлено!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
            }

        }

        private string SmtpServer(string adres)
        {
            if (adres.Contains("mail.ru"))
            {
                adres = "smtp.mail.ru";
            }
            else if (adres.Contains("gmail.com"))
            {
                adres = "smtp.gmail.com";
            }
            else if (adres.Contains("yandex.ru"))
            {
                adres = "smtp.yandex.ru";
            }

            return adres;

        }

        private int Port(string adress)
        { int n;
            switch (adress)
            {
                case "smtp.mail.ru":
                    n = 25;
                    break;
                case "smtp.gmail.com":
                    n = 58;
                    break;
                default:
                    n = 25;
                    break;
            }

            return n; 
        }

        public void Primer()
        {
            MailOut();
        }

    }
}
