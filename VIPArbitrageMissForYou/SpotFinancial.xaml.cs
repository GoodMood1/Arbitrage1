using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
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
using VIPArbitrageMissForYou.DL_;
using Path = System.IO.Path;


namespace VIPArbitrageMissForYou
{
    /// <summary>
    /// Логика взаимодействия для SpotFinancial.xaml
    /// </summary>
    public partial class SpotFinancial : Page
    {
        MainWindow _mainWindow;
        static string cont = "Start trading with the bot\nFill in the fields (table on the left)=>Click the button \"Start\"On the right side, you can see your history.You can clear its by the button \"Clear statistic table(history)\"";
        UpgradeMessageBox uprmess = new UpgradeMessageBox(cont);
        public static ObservableCollection<string> arbres3;
        public static ObservableCollection<decimal> arbres1, arbres2,arbres4;
        public ObservableCollection<CryptoClass> Images { get; set; }
        public ObservableCollection<CryptoClass> Images1 { get; set; }
        public SpotFinancial(MainWindow mainWindow)
        {
            this.DataContext = this;
            Images = new ObservableCollection<CryptoClass>();
            Images1 = new ObservableCollection<CryptoClass>();
            InitializeComponent();
            _mainWindow = mainWindow;
            arbres1 = new ObservableCollection<decimal> {};
            arbres2 = new ObservableCollection<decimal> {};
            arbres3 = new ObservableCollection<string> {};
            arbres4 = new ObservableCollection<decimal> {};

            string directory = @"Resources/cryptopair/";
            string dir2 = Path.GetFullPath(directory);
            dir2 = dir2.Replace(@"bin\Debug\", "");
            string[] fullfilesPath =
    Directory.GetFiles(dir2, "*.png");
            foreach (string myFile in fullfilesPath)
            {
                Images.Add(new CryptoClass
                {
                    Img = new BitmapImage(new Uri(myFile)),
                    ImgName = Path.GetFileNameWithoutExtension(myFile).ToUpper()
                });
            }
            string directory2 = @"Resources/";
            string di = Path.GetFullPath(directory2);
            di = di.Replace(@"bin\Debug\", "");
            string[] fullfilesPath2 =
    Directory.GetFiles(di, "*.png");
            foreach (string myFile in fullfilesPath2)
            {
                string r = Path.GetFileNameWithoutExtension(myFile);
                if (r.ToUpper() == "OKEX" ||  r.ToUpper() == "HUOBI" || r.ToUpper() == "KRAKEN" || r.ToUpper() == "BINANCE")
                {
                    Images1.Add(new CryptoClass
                    {
                        Img1 = new BitmapImage(new Uri(myFile)),
                        ImgName1 = r.ToUpper()
                    });
                }
            }
            bought.BorderBrush = Brushes.White;
            sold.BorderBrush = Brushes.White;
            exchange.BorderBrush = Brushes.White;
            profitt.BorderBrush = Brushes.White;


        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.OpenPage(MainWindow.pages.General);
        }

        private void ClearStatistic(object sender, RoutedEventArgs e)
        {
            bought.Items.Clear();
            sold.Items.Clear();
            profitt.Items.Clear();
            exchange.Items.Clear();
            Client.History_.ClearHistory(Login.log.ToString(), Login.d);
        }
        private void UpdateStatistic(object sender, RoutedEventArgs e)
        {
            bought.Items.Clear();
            arbres1.Clear();
            sold.Items.Clear();
            arbres2.Clear();
            profitt.Items.Clear();
            arbres3.Clear();
            exchange.Items.Clear();
            arbres4.Clear();
            Client.History_.ShowHistory(Login.log.ToString(), Login.d);
            Client.History_.ShowHistory2(Login.log.ToString(), Login.d);
            foreach (var item in arbres1)
            {
                bought.Items.Add(item);
            
            }
            foreach (var item in arbres2)
            {
                sold.Items.Add(item);
            }
            foreach (var item in arbres3)
            {
                exchange.Items.Add(item);
            }
            foreach (var item in arbres4)
            {
                profitt.Items.Add(item);
            }
        }

        private void Combobox_Selected(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.Items.Count > 1)
            {
                // Save the selected employee's name, because we will remove
                // the employee's name from the list.
                var selectedEmployee = comboBox.SelectedItem;
                var selectedEmployee2 = comboBox.Text;
                var selectedEmployee3 = comboBox.Tag;
                MessageBox.Show(selectedEmployee + "\n" + selectedEmployee2 + "\n" + selectedEmployee3 + "\n" + Combobox.Items.IndexOf(Combobox.SelectedIndex) + "\n" + Combobox.SelectedIndex);
            }
        }

        private void TipsMainPage(object sender, RoutedEventArgs e)
        {
            if (uprmess.IsActive == false)
            {
                cont = "Start trading with the bot\nFill in the fields(table on the left) => Click the button \"Start\"On the right side, you can see your history.You can clear its by the button \"Clear statistic table(history)\"";
                uprmess = new UpgradeMessageBox(cont);
            }
            else uprmess.Hide();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            HeartsOfExchanges heartsOf = new HeartsOfExchanges();
            heartsOf.Trading(Convert.ToDecimal(vol.Text), tframe.Text, Convert.ToInt32(p1.Text), Convert.ToInt32(p2.Text));
        }
             private void StartClick(object sender, RoutedEventArgs e)
        {
            ArbitrageClients customer = Client.Client_.ValidationClients(Login.log, Login.d);
            string fileName = @"C:\hello.py";
            string fileName2 = @"C:\hello2.py";
            string text = $"api1 = {customer.API2Binance}\napis1 = {customer.API2BinanceSecretKey}\napi2 = {customer.API3Uniswap}\napis2 = {customer.API3UniswapSecretKey}\napi3 = {customer.API1Huobi}\napis3 = {customer.API1HuobiSecretKey}\napi4 = {customer.API5Pancakeswap}\napis4 = {customer.API5PancakeswapSecretKey}\npaper_trading = false\n";
            using (StreamReader reader = new StreamReader(fileName))
            {
                text += reader.ReadToEnd();
                using (StreamWriter writer = new StreamWriter(fileName2, false))
                {
                    writer.WriteLine(text);
                }
            }
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

            ////If OKX
            //HeartsOfExchanges heartsOf = new HeartsOfExchanges();
            //heartsOf.ConnectionBot1("BTC","USDT","");
            //General.t.Interval = 10000; // specify interval time as you want
            //General.t.Tick += new EventHandler(timer_Tick);
            //General.t.Start();
        }
    }
}