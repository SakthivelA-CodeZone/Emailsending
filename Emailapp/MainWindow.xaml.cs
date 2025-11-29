using MimeKit;
using MailKit.Net.Smtp;
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

namespace Emailapp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        public async Task Sendmail()
        {
            MimeMessage  mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress("Sample", "Developermail56@gmail.com"));
            mimeMessage.To.Add(new MailboxAddress("Sakthivel", "sakthiwebnet@gmail.com"));
            mimeMessage.Subject = "Welcome to .net core ";

            
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync("Developermail56@gmail.com", "fybvyxyxmuqhbwxm");
            await smtp.SendAsync(mimeMessage);
            await smtp.DisconnectAsync(true);
            MessageBox.Show("Email send");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Register success");
            Sendmail();

        }
    }
    
}