using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        static string cont = "";
        UpgradeMessageBox uprmess = new UpgradeMessageBox(cont);
        MainWindow _mainWindow;
        public static string d = "";
        public string log1 = "";
        public SignUp(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.OpenPage(MainWindow.pages.Login);
        }

        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string pattern = @"([A-zА-я])+([0-9\-_\+\.])*([A-zА-я0-9\-_\+\.])*@([A-zА-я])+([0-9\-_\+\.])*([A-zА-я0-9\-_\+\.])*[\.]([A-zА-я])+";
                if (Regex.IsMatch(log.Text, pattern, RegexOptions.IgnoreCase))
                {
                    if (passfield.Password.Length >= 10 && passfield.Password.Length <= 55)
                    {
                        d = passfield.Password.ToString();
                        log1 = log.Text.ToString();
                        ArbitrageClients customer = Client.Client_.Add1(log.Text.ToString(), d);
                        _mainWindow.OpenPage(MainWindow.pages.Login);
                    }
                    else
                    {
                        cont = "Uncorrect password(min 10 symbols, max 55 symbols)";
                        uprmess = new UpgradeMessageBox(cont);
                        uprmess.Show();
                    }
                }
                else
                {
                    cont = "Uncorrect email";
                    uprmess = new UpgradeMessageBox(cont);
                    uprmess.Show();
                }
            }
            catch (Exception x)
            {
                cont = x.Message;
                uprmess = new UpgradeMessageBox(cont);
                uprmess.Show();           
        }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
