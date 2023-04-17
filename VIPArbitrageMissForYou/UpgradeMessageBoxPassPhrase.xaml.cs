﻿using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using VIPArbitrageMissForYou.DL_;

namespace VIPArbitrageMissForYou
{
    /// <summary>
    /// Логика взаимодействия для UpgradeMessageBox.xaml
    /// </summary>
    public partial class UpgradeMessageBoxPassPhrase : Window
    {
        public UpgradeMessageBoxPassPhrase(string d)
        {
            InitializeComponent();
           tipdescr.Text = d;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExchangeRESTOKX.Pass = as1.Text;
                 Client.Client_.AddPhrase(0, Login.log.ToString(), Login.d, as1.Text);
            Hide();
        }
    }
}
