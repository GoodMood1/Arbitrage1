using Newtonsoft.Json.Linq;
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

namespace VIPArbitrageMissForYou
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OpenPage(pages.Login);
        }
        public enum pages
        {
            Login,
            General,
            SignUp,
            P2PAnalyser,
            SpotAnalyser,
            SpotFinancial,
        }
        public void OpenPage(pages pages)
        {
            if (pages == pages.Login) { frame.Navigate(new Login(this)); }
            else if (pages == pages.General){frame.Navigate(new General(this));}
            else if (pages == pages.SignUp) frame.Navigate(new SignUp(this));
            else if (pages == pages.P2PAnalyser) frame.Navigate(new P2PAnalyser(this));
            else if (pages == pages.SpotAnalyser) frame.Navigate(new SpotAnalyser(this));
            else if (pages == pages.SpotFinancial) frame.Navigate(new SpotFinancial(this));
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    FilesOpenSave filesOpenSave = new FilesOpenSave();
        //    filesOpenSave.FilesOpen("Document");
        //}
        //private void RadioButton1_Checked(object sender, RoutedEventArgs e)
        //{
        //    RadioButton pressed = (RadioButton)sender;
        //    MessageBox.Show(pressed.Content.ToString());
        //}
    }
}
