using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;

namespace NewWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonClick(object sender, RoutedEventArgs e)
        {
            //формирование письма

            MailMessage mm = new MailMessage("vagapova_n@mail.ru", "vagapova_n@mail.ru");
            mm.Subject = "Заголовок письма";
            mm.Body = "Текст письма";
            mm.IsBodyHtml = false; // Не используем html в теле письма


            // Авторизуемся на smtp-сервере и отправляем письмо
            SmtpClient sc = new SmtpClient("smtp.mail.ru", 25);
            sc.EnableSsl = true;
            sc.DeliveryMethod = SmtpDeliveryMethod.Network;
            sc.UseDefaultCredentials = false;
            
            sc.Credentials = new NetworkCredential(LoginName.Text, PosswordN.SecurePassword);
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
    }
}
