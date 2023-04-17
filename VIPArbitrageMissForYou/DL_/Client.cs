using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VIPArbitrageMissForYou.DL_
{
    public static class Client
    {
        public static class Client_
        {
            public static ArbitrageClients Add1(string s, string s2)
            {
                using (var db = new ArbitraEntities1())
                {
                    ArbitrageClients customer = new ArbitrageClients();
                    var result = db.stp_AddClients(s, s2);
                    customer.Login_ = s;
                    customer.Password_ = s2;
                    return customer;
                }
            }
            public static ArbitrageClients AddAPI(int ii,string s, string s2, string s3, string s4)
            {
                using (var db = new ArbitraEntities1())
                {
                    ArbitrageClients customer = new ArbitrageClients();
                    var result = db.stp_AddClientAPI(ii,s, s2,s3,s4);
                    return customer;
                }
            }
            public static ArbitrageClients AddPhrase(int ii, string s, string s2, string s3)
            {
                using (var db = new ArbitraEntities1())
                {
                    ArbitrageClients customer = new ArbitrageClients();
                    var result = db.stp_AddPhrase(ii, s, s2, s3);
                    return customer;
                }
            }
            public static ArbitrageClients ValidationClients(string s, string s2)
            {
                using (var db = new ArbitraEntities1())
                {
                    ArbitrageClients customer = new ArbitrageClients();
                    var result = db.stp_ClientsInfo(s, s2).First();
                    customer.Id = result.Id;
                    customer.Login_ = result.Login_;
                    customer.Password_ = result.Password_;
                    customer.API1Huobi = result.API1Huobi;
                    customer.API1HuobiSecretKey = result.API1HuobiSecretKey;
                    customer.API2Binance = result.API2Binance;
                    customer.API2BinanceSecretKey = result.API2BinanceSecretKey;
                    customer.API3Uniswap = result.API3Uniswap;
                    customer.API3UniswapSecretKey = result.API3UniswapSecretKey;
                    customer.API4Kraken = result.API4Kraken;
                    customer.API4KrakenSecretKey = result.API4KrakenSecretKey;
                    customer.API5Pancakeswap = result.API5Pancakeswap;
                    customer.API5PancakeswapSecretKey = result.API5PancakeswapSecretKey;
                    customer.Passphrase = result.Passphrase;
                    customer.Passphrase2 = result.Passphrase2;
                    return customer;
                }

            }
            public static ArbitrageClients SendMail_(string s)
            {
                using (var db = new ArbitraEntities1())
                {
                    ArbitrageClients customer = new ArbitrageClients();
                    var result = db.stp_SendMail(s);
                    foreach (var item in result)
                    {
                        customer.Password_ = item.ToString();
                    }
                    return customer;
                }

            }

        }
        public static class History_
        {
            public static History ShowHistory(string s, string s2)
            {
                using (var db = new ArbitraEntities1())
                {
                    History adm = new History();
                    var result = db.stp_ShowHistorywithValidation(s, s2,0);
                    var result2 = db.stp_ShowHistorywithValidation(s, s2, 1);
                    var result4 = db.stp_ShowHistorywithValidation(s, s2, 3);
                    foreach (var item in result)
                    {
                        SpotFinancial.arbres2.Add((decimal)item);
                    }
                    foreach (var item in result2)
                    {
                        SpotFinancial.arbres1.Add((decimal)item);
                    }
                    foreach (var item in result4)
                    {
                        SpotFinancial.arbres4.Add((decimal)item);
                    }
                    //adm.Id = result.Id;
                    //adm.Id_clients = result.Id_clients;
                    //adm.exchanges = result.exchanges;
                    //adm.sold = result.sold;
                    //adm.bought = result.bought;
                    //adm.timehistory = result.timehistory;
                    return adm;
                }
            }
            public static History ShowHistory2(string s, string s2)
            {
                using (var db = new ArbitraEntities1())
                {
                    History history = new History();
                    var result = db.stp_ShowHistory2(s, s2);
                    foreach (var item in result)
                    {
                        SpotFinancial.arbres3.Add(item.ToString());
                    }
                    return history;
                }
            }
            public static History ClearHistory(string s, string s2)
            {
                using (var db = new ArbitraEntities1())
                {
                    History history = new History();
                    var result = db.stp_ClearHistory(s, s2);
                    return history;
                }
            }
            public static History AddHistory(string s,string s2, string exch, decimal sold, decimal bought, DateTime time1)
            {
                using (var db = new ArbitraEntities1())
                {
                    History adm = new History();
                    var result = db.stp_AddHistory(s, s2, exch, sold, bought, time1);
                    return adm;
                }
            }
        }
        public static class AdminoWorld_
        {
            public static AdminoWorld ShowCommandAdmino(string s)
            {
                using (var db = new ArbitraEntities1())
                {
                    AdminoWorld adm = new AdminoWorld();
                    var result = db.stp_AdminoInfo(s).First();
                    adm.APICommand1 = result.APICommand1;
                    adm.APICommand2 = result.APICommand2;
                    adm.APICommand3 = result.APICommand3;
                    adm.APICommand4 = result.APICommand4;
                    adm.APICommand5 = result.APICommand5;
                    adm.MailPasswordToAccount = result.MailPasswordToAccount;
                    adm.MailPasswordKeyForAccess = result.MailPasswordKeyForAccess;
                    adm.MailForNotify = result.MailForNotify;
                    adm.Exchanges = result.Exchanges;
                    return adm;
                }
            }
        }


    }

}
