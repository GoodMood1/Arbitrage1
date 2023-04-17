using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using VIPArbitrageMissForYou.DL_;

namespace VIPArbitrageMissForYou
{
    /// <summary>
    /// Логика взаимодействия для General.xaml
    /// </summary>
    public partial class General : Page
    {
        static string cont = "";
        public MainWindow _mainWindow;
        public static Timer t = new System.Windows.Forms.Timer();
        UpgradeMessageBox uprmess = new UpgradeMessageBox(cont);
        static public string Pass_="";
        public General(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
                }

        ////private void RadioButton1_Checked(object sender, RoutedEventArgs e)
        ////{
        ////    RadioButton pressed = (RadioButton)sender;
        ////    MessageBox.Show(pressed.Content.ToString());
        ////}
        private void Button_Start(object sender, RoutedEventArgs e)
        {
            try
            {
                ////////////////ArbitrageClients customer = Client.Client_.AddAPI(0, Login.log, Login.d,);
                cont = "Add parameters for APY(Check the exchanges -> Add API for this exchange)"; uprmess = new UpgradeMessageBox(cont);
                if (birja1.IsChecked == true && (aa1.Text == "" || a1.Text == "")) { uprmess.Show(); return; }
                else if (birja2.IsChecked == true && (aa2.Text == "" || a2.Text == "")) { uprmess.Show(); return; }
                else if (birja3.IsChecked == true && (aa3.Text == "" || a3.Text == "")) { uprmess.Show(); return; }
                else if (birja4.IsChecked == true){if(aa4.Text == "" || a4.Text == "") { uprmess.Show(); return; }
                    UpgradeMessageBoxPassPhrase upgradeMessageBoxPassPhrase = new UpgradeMessageBoxPassPhrase("Enter passphrase for OKEX");
                    upgradeMessageBoxPassPhrase.Show();
                }
                Client.Client_.AddAPI(0, Login.log.ToString(), Login.d, a2.Text, aa2.Text);
                Client.Client_.AddAPI(1, Login.log.ToString(), Login.d, a1.Text, aa1.Text);
                Client.Client_.AddAPI(2, Login.log.ToString(), Login.d, a4.Text, aa4.Text);
                Client.Client_.AddAPI(3, Login.log.ToString(), Login.d, a3.Text, aa3.Text);
                var res = spot.IsChecked == true ? "S" : p2p.IsChecked == true ? "P" : "";
                res += finanalyse.IsChecked == true ? "Fin" : simpleanalyse.IsChecked == true ? "An" : "";
                switch (res)
                {
                    case "SFin":
                        { _mainWindow.OpenPage(MainWindow.pages.SpotFinancial); }
                        break;
                    case "SAn":
                        { _mainWindow.OpenPage(MainWindow.pages.SpotAnalyser); }
                        break;
                    case "PAn":
                        { _mainWindow.OpenPage(MainWindow.pages.P2PAnalyser); }
                        break;
                    case "PFin":
                        {
                            cont = "Financial P2P assistant don't accept, yet.";
                            uprmess = new UpgradeMessageBox(cont);
                            uprmess.Show();
                        }
                        break;
                    default:
                        cont = "Select the opinion";
                        uprmess = new UpgradeMessageBox(cont);
                        uprmess.Show();
                        break;
                }
            }
            catch (Exception ex) { cont = ex.Message.ToString(); uprmess = new UpgradeMessageBox(cont); uprmess.Show(); }
        }
        
        private void TipsMainPage(object sender, RoutedEventArgs e)
        {
            cont = "Choose the required options(navigator on the top) => \nIn the \"Exchange API and Secret key\" fields, write access and secret keys => \nClick the \"Let's go\" button.\nP.S. if something is not filled out, the program will not skip further";
            uprmess = new UpgradeMessageBox(cont);
            if (uprmess.IsActive == false) { uprmess.Show(); }
            else uprmess.Hide();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            t.Stop();
            ExchangeRESTOKX.Pass = "";
            _mainWindow.OpenPage(MainWindow.pages.Login);
        }

        private void p2p_Checked(object sender, RoutedEventArgs e)
        {
            earnbetween.IsEnabled = true;
        }

        private void spot_Checked(object sender, RoutedEventArgs e)
        {
            earnbetween.IsEnabled = true;
        }

        private void Image_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                DialogResult res = (DialogResult)System.Windows.MessageBox.Show("Are you sure you want to close all your deals?", "Confirmation", (MessageBoxButton)MessageBoxButtons.OKCancel, (MessageBoxImage)MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    cont = "All your deals was successfully closed"; uprmess = new UpgradeMessageBox(cont); uprmess.Show();
                    t.Stop();
                    //NEED to CLOSING THE DEAL 
                }
                else { cont = "All your deals was successfully saved"; uprmess = new UpgradeMessageBox(cont); uprmess.Show(); }
            }catch(Exception ex)
            {
                cont = ex.Message; uprmess = new UpgradeMessageBox(cont); uprmess.Show();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ArbitrageClients customer = Client.Client_.ValidationClients(Login.log.ToString(), Login.d);
            a2.Text = customer.API1Huobi; aa2.Text = customer.API1HuobiSecretKey;
            a1.Text = customer.API2Binance; aa1.Text = customer.API2BinanceSecretKey;
           a3.Text = customer.API4Kraken; aa3.Text = customer.API4KrakenSecretKey;
           a4.Text = customer.API3Uniswap; aa4.Text = customer.API3UniswapSecretKey;

        }
    }
}
