using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using VIPArbitrageMissForYou.DL_;
namespace VIPArbitrageMissForYou
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        MainWindow _mainWindow;
        static string cont = "";
        UpgradeMessageBox uprmess = new UpgradeMessageBox(cont);
        public static string d = "";
        public static string log = "";
        public Login(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            d = passfield.Password.ToString();
            log = mail1.Text.ToString();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                        d = passfield.Password.ToString();
                        log = mail1.Text.ToString();
                        ArbitrageClients customer = Client.Client_.ValidationClients(log, d);
                        if (customer.Login_ != null || customer.Password_ != null)
                        {
                            cont = "User logged in";
                    uprmess = new UpgradeMessageBox(cont);
                    uprmess.Show();
                            _mainWindow.OpenPage(MainWindow.pages.General);
                        }
                        else
                        {
                            cont = "Empty";
                    uprmess = new UpgradeMessageBox(cont);
                    uprmess.Show();
                        }
            }
            catch (Exception)
            {
                cont = "Error!";
                uprmess = new UpgradeMessageBox(cont);
                uprmess.Show();
            }
        }

        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.OpenPage(MainWindow.pages.SignUp);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string pattern = @"([A-zА-я])+([0-9\-_\+\.])*([A-zА-я0-9\-_\+\.])*@([A-zА-я])+([0-9\-_\+\.])*([A-zА-я0-9\-_\+\.])*[\.]([A-zА-я])+";
            if (Regex.IsMatch(mail1.Text, pattern, RegexOptions.IgnoreCase))
            {
                ArbitrageClients customer =  Client.Client_.SendMail_(mail1.Text.ToString());
                if (customer.Password_ != null)
                {
                    EmailService emailService = new EmailService();
                    emailService.SendEmail(mail1.Text.ToString(), "Your password from VIPArbitrageMissForYou!", $"<center><p>Dear customer<hr>You can see the password below.</p><h1><b>Your password:<br>{customer.Password_}</b></h1><p><b>P.S.Please don't forget about us anymore.</b></center>");
                }
                else
                {
                    cont = "Wrong email!";
                    uprmess = new UpgradeMessageBox(cont);
                    uprmess.Show();
                }
            }
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
