using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
using static ServiceStack.Diagnostics.Events;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using CheckBox = System.Windows.Controls.CheckBox;

namespace VIPArbitrageMissForYou
{
    /// <summary>
    /// Логика взаимодействия для P2PAnalyser.xaml
    /// </summary>
    public partial class P2PAnalyser : Page
    {
        static string cont = "";
        public MainWindow _mainWindow;
        ExcelClass file = new ExcelClass();
        FilesOpenSave file2 = new FilesOpenSave();
        UpgradeMessageBox uprmess = new UpgradeMessageBox(cont);
        ObservableCollection<string> arbres3, arbres4;
        ObservableCollection<double> arbres1, arbres2;
        public double price {get; set; }
        public double profit { get; set; }
        public string exchanges { get; set; }
        public string crypto { get; set; }
        public string selectedindex { get; set; }
        public P2PAnalyser(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            arbres1 = new ObservableCollection<double> {};
            arbres2 = new ObservableCollection<double> {};
            arbres3 = new ObservableCollection<string> {};
            arbres4 = new ObservableCollection<string> {};
            arbitrageListProfit.ItemsSource = arbres1;
            arbitrageListProfit.BorderBrush = Brushes.White;
            arbitrageListPrice.ItemsSource = arbres2;
            arbitrageListPair.BorderBrush = Brushes.White;
            arbitrageListPair.ItemsSource = arbres3;
            arbitrageListPair.BorderBrush = Brushes.White;
            arbitrageListExchanges.ItemsSource = arbres4;
            arbitrageListExchanges.BorderBrush = Brushes.White;

        }

        private void OnComputer(object sender, RoutedEventArgs e)
        {
            file2.CreateTXTDoc(arbres1, arbres2, arbres3, arbres4);
        }
        private void OnComputerExcel(object sender, RoutedEventArgs e)
        {
            file.getExcelFile("ExcelResults", arbres1, arbres2, arbres3, arbres4);
        }
        private void EmailClick(object sender, RoutedEventArgs e)
        {
            string text = "<br>~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Results~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~<br>";
            for (int j = 1; arbres1.Count >= j; j++)
            {
                text += arbres4[j - 1].ToString() + "  |  ";
                text += arbres3[j - 1].ToString() + "  |  ";
                text += arbres2[j - 1].ToString() + "  |  ";
                text += arbres1[j - 1].ToString() + "<br>";
            }
            text += "<br>~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~<br>";
            EmailService emailService = new EmailService();
            emailService.SendEmail(textgmail.Text, "Dear customer!", "You can see your results below.<br>"+ text);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.OpenPage(MainWindow.pages.General);
        }
        private void TipsMainPage(object sender, RoutedEventArgs e)
        {
            if (uprmess.IsActive == false)
            {
                cont = "Choose appropriate pairs => Click the button \"Let's make money\", if you want to make the financial transactions => Congrats!Also, you can just analyse by clicking the button \"Let's analyse\"\nP.S. If you don't chose anything pairs, program automatically select them.";
                uprmess = new UpgradeMessageBox(cont);
            }
            else uprmess.Hide();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            HeartsOfExchanges heartsOf = new HeartsOfExchanges();
            heartsOf.Trading(20, "1", 10, 25);
        }

        private void Makemoney(object sender, RoutedEventArgs e)
        {
            string crypto = arbitrageListPair.Items[arbitrageListChoice.SelectedIndex].ToString();
            HeartsOfExchanges heartsOf = new HeartsOfExchanges();
            heartsOf.ConnectionBot1("", "", crypto);
            General.t.Interval = 30000; // specify interval time as you want
            General.t.Tick += new EventHandler(timer_Tick);
            General.t.Start();

        }
        private void HereAnalyse(object sender, RoutedEventArgs e)
        {
            string fileName = @"C:\hello2.py";

            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(@"C:\Python\Python311\python.exe", fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            p.Start();
            StringBuilder q = new StringBuilder();
            while (!p.HasExited)
            {
                q.Append(p.StandardOutput.ReadToEnd());
                System.Windows.MessageBox.Show(q.ToString());
            }

            try
            {
                if (arbres1.Count > 0) { arbres1.Clear(); arbres2.Clear(); arbres3.Clear(); arbres4.Clear(); arbitrageListChoice.Items.Clear(); }

                arbres1.Add(profit);
                arbres2.Add(price);
                arbres3.Add(crypto);
                arbres4.Add(exchanges);

                for (int i = 0; i < arbitrageListProfit.Items.Count; i++)
                {
                    CheckBox chb = new CheckBox();
                    chb.IsChecked = false;
                    chb.Name = "checkboxanalysespot";
                    arbitrageListChoice.Items.Add(chb);
                }
            }
            catch (Exception ex) { System.Windows.MessageBox.Show(ex.Message); }
        }
    }
    }

