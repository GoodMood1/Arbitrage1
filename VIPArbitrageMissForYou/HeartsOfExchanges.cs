using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using VIPArbitrageMissForYou.DL_;

namespace VIPArbitrageMissForYou
{
    public partial class HeartsOfExchanges
    {
        List<string> symbolsAll = new List<string>();
        UpgradeMessageBox box = new UpgradeMessageBox("");
        Char separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
        string balStr = "";
        List<string> Symbols = new List<string>();
        string Symbols_ = "BTC-USDT";
        string TF = "5m";
        List<int> PeriodShort = new List<int>();
        List<int> PeriodLong = new List<int>();
        decimal Volume = 20;




        public async void ConnectionBot1(string coin1, string coin2,string coin3) {
            #region Проверка API и Баланса
            bool x = await ExchangeRESTOKX.GetBalances();

            if (!x)
            {
                box = new UpgradeMessageBox("Error with API\n" + ExchangeRESTOKX.ErrorString + "\n");
                box.Show();
                return;
            }
            box = new UpgradeMessageBox("Validation API++\n");
            box.Show();
            #endregion

            #region Отримуємо дані від ОКХ і налаштування
            bool xx = await ExchangeRESTOKX.GetSymbolInfoSpot();

            if (!xx)
            {
                box = new UpgradeMessageBox("I can't receive values from instruments\n" + ExchangeRESTOKX.ErrorString + "\n");
                box.Show();
                return;
            }
            if ((ExchangeRESTOKX.Symbols == null) || (ExchangeRESTOKX.Symbols.Count <= 0))
            {
                box = new UpgradeMessageBox("The pair is not received\n");
                box.Show();
                return;
            }


            for (int i = 0; i < ExchangeRESTOKX.Symbols.Count; i++)
            {
                var temp = "";
                if (coin3 == "") { temp = coin1 + "-" + coin2; }
                else { temp = coin3; }
                if (temp == ExchangeRESTOKX.Symbols[i]) symbolsAll.Add(ExchangeRESTOKX.Symbols[i]);
            }
            symbolsAll.Sort();
            #endregion
            int checkpoint = 0;
            try
            {
                #region Отримуємо і виводимо баланс
                if (!await ExchangeRESTOKX.GetBalances())
                {
                    box = new UpgradeMessageBox("Occurs error with balance(can't receive)\n" + ExchangeRESTOKX.ErrorString + "\n");
                    box.Show();
                    return;
                }

                if (ExchangeRESTOKX.FreeBalance == null)
                {
                    box = new UpgradeMessageBox("No money for trading. First of all, add MONEY to your account!\n");
                    box.Show();
                    return;
                }

                checkpoint = 1;
                foreach (var el in ExchangeRESTOKX.FreeBalance)
                    if (el.Value > 0)
                    {
                        balStr = "Balance: " + el.Value.ToString("0." + new string('#', 339)) + " " + el.Key;
                        box = new UpgradeMessageBox(balStr.ToString());
                        box.Show();
                    }
                #endregion
                //Add pair for trading
                Symbols_ = symbolsAll[0];
            }catch (Exception ex)
            {
                box = new UpgradeMessageBox("Exception: " + ex.Message + " (чекпоинт " + checkpoint + ")\n");
                box.Show();
            }
            }
    public async void Trading(decimal volume1,string tm,int pr,int pr2)
        {
            TF = tm;
            Volume = volume1;
            PeriodShort.Add(pr);
            PeriodLong.Add(pr2);
            int checkpoint = 2;
            try { 
                #region Базова підготовка
                    checkpoint = 2;
                    box = new UpgradeMessageBox("\n>>> Trading pair " + Symbols_ + "\n");
                    box.Show();
                    string curr1 = ExchangeRESTOKX.Base1[Symbols_];
                    string curr2 = ExchangeRESTOKX.Quote2[Symbols_];

                    double depo1free = 0;
                    double depo2free = 0;

                    if (ExchangeRESTOKX.FreeBalance.ContainsKey(curr1)) depo1free = ExchangeRESTOKX.FreeBalance[curr1];
                    if (ExchangeRESTOKX.FreeBalance.ContainsKey(curr2)) depo2free = ExchangeRESTOKX.FreeBalance[curr2];

                    box = new UpgradeMessageBox("Balance " + depo1free + " " + curr1 + "\n"+ "Balance " + depo2free + " " + curr2 + "\n");
                    box.Show();

                    bool isOpenPos = false;
                    if (depo1free > ExchangeRESTOKX.MinSize[Symbols_])
                    {
                        isOpenPos = true;
                        box = new UpgradeMessageBox("Open position by " + Symbols_+ "\n");
                        box.Show();
                    }
                    #endregion

                    #region Отримуємо сигнали
                    checkpoint = 3;
                    bool isSMAbuy = false;
                    bool isSMAsell = false;

                    List<ExchangeRESTOKX.Candles> candles = await ExchangeRESTOKX.GetOHLC(Symbols_, TF);

                    if ((candles == null) || (candles.Count <= 0))
                    {
                        box = new UpgradeMessageBox("Cannot receive indicators\n" + ExchangeRESTOKX.ErrorString + "\n");
                        box.Show();
                }

                double[] movShort;
                double[] movLong;

                bool resShort = SMA(candles, PeriodShort[0], out movShort);
                if (!resShort)
                {
                    box = new UpgradeMessageBox("Short moving average calculation error\n");
                    box.Show();
                }

                bool resLong = SMA(candles, PeriodLong[0], out movLong);
                if (!resLong)
                {
                    box = new UpgradeMessageBox("Long moving average calculation error\n");
                    box.Show();
                }

                box = new UpgradeMessageBox("Short SMA data: " + movShort[1] + " / " + movShort[2] + "\n");
                box.Show();
                box = new UpgradeMessageBox("Long SMA data: " + movLong[1] + " / " + movLong[2] + "\n");
                box.Show();

                if ((movShort[2] < movLong[2]) && (movShort[1] > movLong[1]))
                {
                    box = new UpgradeMessageBox("There is a buy signal\n");
                    box.Show();
                    isSMAbuy = true;
                }

                if ((movShort[2] > movLong[2]) && (movShort[1] < movLong[1]))
                {
                    box = new UpgradeMessageBox("There is a sale signal\n");
                    box.Show();
                    isSMAsell = true;
                }
                #endregion

                #region Відкриваємо позицію
                checkpoint = 4;
                if ((!isOpenPos) && (isSMAbuy))
                {
                    decimal temp = (decimal)ExchangeRESTOKX.LotSize[Symbols_];
                    decimal realPos = temp * Math.Floor(Volume / temp);
                    box = new UpgradeMessageBox("Working space " + realPos.ToString("0." + new string('#', 339)) + " " + curr2 + "\n");
                    box.Show();
                    if (realPos < 2 * (decimal)ExchangeRESTOKX.MinSize[Symbols_])
                    {
                        realPos = 2 * (decimal)ExchangeRESTOKX.MinSize[Symbols_];
                        box = new UpgradeMessageBox("Working space increased on " + realPos.ToString("0." + new string('#', 339)) + " " + curr2 + "\n");
                        box.Show();
                    }

                    ExchangeRESTOKX.Order ord = await ExchangeRESTOKX.SendMarketOrder(Symbols_, "buy", (double)realPos);
                    if (ord == null)
                    {
                        box = new UpgradeMessageBox("Error with opening position\n" + ExchangeRESTOKX.ErrorString + "\n");
                        box.Show();
                    }
                    else
                    {
                        box = new UpgradeMessageBox("Order was successfull sent " + ord.OrderID + "\n");
                        box.Show();
                    }
                }
                #endregion

                #region Закриття позиції
                checkpoint = 5;
                if ((isOpenPos) && (isSMAsell))
                {
                    double realPos = ExchangeRESTOKX.LotSize[Symbols_] * Math.Floor(depo1free / ExchangeRESTOKX.LotSize[Symbols_]);
                    box = new UpgradeMessageBox("Working space " + realPos.ToString("0." + new string('#', 339)) + " " + curr1 + " (for sell)\n");
                    box.Show();
                    ExchangeRESTOKX.Order ord = await ExchangeRESTOKX.SendMarketOrder(Symbols_, "sell", realPos);
                    if (ord == null)
                    {
                        box = new UpgradeMessageBox("Wrong with closing position\n" + ExchangeRESTOKX.ErrorString + "\n");
                        box.Show();
                    }
                    else
                    {
                        var now = DateTime.Now;
                        //var timeStamp = TimeZoneInfo.ConvertTimeToUtc(now).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                        Client.History_.AddHistory(Login.log.ToString(), Login.d, "OKEX", (decimal)realPos, 0, now);
                        box = new UpgradeMessageBox("Order was successfull sent " + ord.OrderID + "\n");
                        box.Show();
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                box = new UpgradeMessageBox("Exception: " + ex.Message + " (чекпоинт " + checkpoint + ")\n");
                box.Show();
            }
        }
        private bool SMA(List<ExchangeRESTOKX.Candles> candles, int period, out double[] moving)
        {
            moving = new double[candles.Count];

            if (candles.Count < (period + 3))
            {
                box = new UpgradeMessageBox("Quantity of input data less for the period\n");
                box.Show();
                return false;
            }

            int candlesData = 3;
            for (int i = 0; i < candlesData; i++)
            {
                for (int j = i; j < i + period; j++)
                    moving[i] = moving[i] + candles[j].close;

                moving[i] = moving[i] / period;
            }
            return true;
        }

        }
        }
