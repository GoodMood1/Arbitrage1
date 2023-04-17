using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
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

namespace VIPArbitrageMissForYou
{
    /// <summary>
    /// Логика взаимодействия для SpotAnalyser.xaml
    /// </summary>
    public partial class SpotAnalyser : Page
    {
        static string cont = "";
        public MainWindow _mainWindow;
        ExcelClass file = new ExcelClass();
        FilesOpenSave file2 = new FilesOpenSave();
        UpgradeMessageBox uprmess = new UpgradeMessageBox(cont);
        ObservableCollection<string> arbres3, arbres4;
        ObservableCollection<double> arbres1, arbres2;
        double price = 1.00005;
        double profit = 6.578978892314;
        string exchanges = "Binance";
        string crypto = "BTC/ETH";
        public SpotAnalyser(MainWindow mainWindow)
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

        private void FinancialHelper(object sender, RoutedEventArgs e)
        {
            //add parameters
            _mainWindow.OpenPage(MainWindow.pages.SpotFinancial);
        }
        private void OnComputerExcel(object sender, RoutedEventArgs e)
        {
            // Create an excel object
            file.getExcelFile("ExcelResults", arbres1, arbres2, arbres3, arbres4);
        }
        private void OnComputerTXT(object sender, RoutedEventArgs e)
        {

            file2.CreateTXTDoc(arbres1, arbres2, arbres3, arbres4);
        }
            private void EmailClick(object sender, RoutedEventArgs e)
        {
            EmailService emailService = new EmailService();
            emailService.SendEmail(textgmail.Text,"Dear customer!","You can see your results below.");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.OpenPage(MainWindow.pages.General);
        }
        private void TipsMainPage(object sender, RoutedEventArgs e)
        {
            if (uprmess.IsActive == false)
            {
                cont = "Choose appropriate pairs => Click the button \"Go to the Financial assistant\", if you want to make the financial transactions => Congrats! P.S. If you don't chose anything pairs, program automatically select the best combination";
                uprmess = new UpgradeMessageBox(cont); uprmess.Show(); }
            else uprmess.Hide();
        }

        private void HereAnalyse(object sender, RoutedEventArgs e)
        {
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
                string fileName2 = @"C:\hello2.py";
               
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(@"C:\Python\Python311\python.exe", fileName2)
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
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
