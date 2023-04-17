using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VIPArbitrageMissForYou.DL_;

namespace VIPArbitrageMissForYou
{
    internal class ExchangeRESTOKX
    {
        public class Order
        {
            [JsonProperty("ordId")]
            public string OrderID { get; set; }
        }

        public class OrderFull
        {
            [JsonProperty("code")]
            public int code { get; set; }
            [JsonProperty("msg")]
            public string Msg { get; set; }
            [JsonProperty("data")]
            public List<Order> Data { get; set; }
        }

        public class Balances
        {
            [JsonProperty("ccy")]
            public string Coin { get; set; }
            [JsonProperty("availEq")]
            public double? Available1 { get; set; }
            [JsonProperty("availBal")]
            public double? Available2 { get; set; }
        }

        public class BalancesX
        {
            [JsonProperty("details")]
            public List<Balances> Details { get; set; }
        }

        public class BalancesFull
        {
            [JsonProperty("code")]
            public int code { get; set; }
            [JsonProperty("msg")]
            public string Msg { get; set; }
            [JsonProperty("data")]
            public List<BalancesX> Data { get; set; }
        }

        public class Instrument
        {
            [JsonProperty("instId")]
            public string symbol { get; set; }
            [JsonProperty("tickSz")]
            public double TickSize { get; set; }
            [JsonProperty("lotSz")]
            public double LotSize { get; set; }
            [JsonProperty("minSz")]
            public double MinSize { get; set; }
            [JsonProperty("baseCcy")]
            public string Base { get; set; }
            [JsonProperty("quoteCcy")]
            public string Quote { get; set; }
        }

        public class InstrumentFull
        {
            [JsonProperty("code")]
            public int code { get; set; }
            [JsonProperty("msg")]
            public string Msg { get; set; }
            [JsonProperty("data")]
            public List<Instrument> Data { get; set; }
        }

        public class CandlesFull
        {
            [JsonProperty("code")]
            public int code { get; set; }
            [JsonProperty("msg")]
            public string Msg { get; set; }
            [JsonProperty("data")]
            public List<double[]> Data { get; set; }
        }

        public class Candles
        {
            public double open { get; set; }
            public double high { get; set; }
            public double low { get; set; }
            public double close { get; set; }
        }

        ////AdminoWorld admW = Client.AdminoWorld_.ShowCommandAdmino("Binance");
        public static string ApiUrl = "https://www.okx.com";
        public static string ErrorString = "";
        public static ArbitrageClients arbwitrageClients = Client.Client_.ValidationClients(Login.log, Login.d);
        public static string Secret = arbwitrageClients.API3UniswapSecretKey.ToString();
        public static string ApiKey = arbwitrageClients.API3Uniswap.ToString();
        public static string Pass = "";
        public static List<string> Symbols = new List<string>();
        public static Dictionary<string, double> TickSize = new Dictionary<string, double>();
        public static Dictionary<string, double> LotSize = new Dictionary<string, double>();
        public static Dictionary<string, double> MinSize = new Dictionary<string, double>();
        public static Dictionary<string, string> Base1 = new Dictionary<string, string>();
        public static Dictionary<string, string> Quote2 = new Dictionary<string, string>();
        public static Dictionary<string, double> FreeBalance = new Dictionary<string, double>();

        public static string HmacSHA256(string infoStr, string secret)
        {
            byte[] sha256Data = Encoding.UTF8.GetBytes(infoStr);
            byte[] secretData = Encoding.UTF8.GetBytes(secret);
            using (var hmacsha256 = new HMACSHA256(secretData))
            {
                byte[] buffer = hmacsha256.ComputeHash(sha256Data);
                return Convert.ToBase64String(buffer);
            }
        }

        private static async Task<string> OpenCodeRequest(string url)
        {
            string result = "ERROR:Null";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
                SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            try
            {
                using (var client = new HttpClient())
                {
                    using (var r = await client.GetAsync(new Uri(url)))
                    {
                        result = await r.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                result = "ERROR:" + ex.ToString();
            }

            return result;
        }
        private static async Task<string> SecretCodeRequestGET(string url)
        {
            string result = "ERROR:Null";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
                SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            try
            {
                var now = DateTime.Now;
                var timeStamp = TimeZoneInfo.ConvertTimeToUtc(now).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                Uri baseURI = new Uri(ApiUrl + url);
                string urlPath = baseURI.PathAndQuery;      
                string sign = HmacSHA256($"{timeStamp}GET{urlPath}", Secret);
                UpgradeMessageBox gh = new UpgradeMessageBox(Pass);
                gh.Show();
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("OK-ACCESS-KEY", ApiKey);
                    client.DefaultRequestHeaders.Add("OK-ACCESS-SIGN", sign);
                    client.DefaultRequestHeaders.Add("OK-ACCESS-TIMESTAMP", timeStamp);
                    client.DefaultRequestHeaders.Add("OK-ACCESS-PASSPHRASE", Pass);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var r = await client.GetAsync(baseURI))
                    {
                        result = await r.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                result = "ERROR:" + ex.ToString();
            }

            return result;
        }

        private static async Task<string> SecretCodeRequestPOST(string json, string url)
        {
            string result = "ERROR: Null";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            try
            {
                var bufferX = System.Text.Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(bufferX);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var now = DateTime.Now;
                var timeStamp = TimeZoneInfo.ConvertTimeToUtc(now).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                Uri baseURI = new Uri(ApiUrl + url);
                string utlPath = baseURI.PathAndQuery;
                string sign = HmacSHA256($"{timeStamp}POST{utlPath}{json}", Secret);
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("OK-ACCESS-KEY", ApiKey);
                    client.DefaultRequestHeaders.Add("OK-ACCESS-TIMESTAMP", timeStamp.ToString());
                    client.DefaultRequestHeaders.Add("OK-ACCESS-PASSPHRASE", Pass);
                    client.DefaultRequestHeaders.Add("OK-ACCESS-SIGN", sign);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var r = await client.PostAsync(baseURI, byteContent))
                    {
                        var buffer = await r.Content.ReadAsByteArrayAsync();
                        result = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
                    }
                }

            }
            catch (Exception exception)
            {
                result = "ERROR: " + exception.ToString();
            }

            return result;
        }

        public static async Task<bool> GetSymbolInfoSpot()
        {
            string url = ApiUrl + "/api/v5/public/instruments?instType=SPOT";
            string res = await OpenCodeRequest(url);
            ErrorString = url + "\n" + res;

            if (res.Length < 5) return false;
            if (res.Substring(0, 5) == "ERROR") return false;

            try
            {
                if (Symbols != null) Symbols.Clear();
                if (LotSize != null) LotSize.Clear();
                if (TickSize != null) TickSize.Clear();
                if (MinSize != null) MinSize.Clear();
                if (Base1 != null) Base1.Clear();
                if (Quote2 != null) Quote2.Clear();

                InstrumentFull result = JsonConvert.DeserializeObject<InstrumentFull>(res);

                if ((result == null) || (result.Data == null) || (result.Data.Count <= 0)) return false;

                for (int i = 0; i < result.Data.Count; i++)
                {
                    Symbols.Add(result.Data[i].symbol);
                    LotSize.Add(result.Data[i].symbol, result.Data[i].LotSize);
                    TickSize.Add(result.Data[i].symbol, result.Data[i].TickSize);
                    MinSize.Add(result.Data[i].symbol, result.Data[i].MinSize);
                    Base1.Add(result.Data[i].symbol, result.Data[i].Base);
                    Quote2.Add(result.Data[i].symbol, result.Data[i].Quote);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static async Task<List<Candles>> GetOHLC(string symbol, string timeframe)
        {
            string url = ApiUrl + "/api/v5/market/candles?instId=" + symbol + "&bar=" + timeframe;
            string res = await OpenCodeRequest(url);
            ErrorString = url + "\n" + res;

            if (res.Length < 5) return null;
            if (res.Substring(0, 5) == "ERROR") return null;

            List<Candles> result2 = new List<Candles>();
            try
            {
                CandlesFull result = JsonConvert.DeserializeObject<CandlesFull>(res);

                if ((result == null) || (result.Data == null) || (result.Data.Count <= 0)) return null;

                for (int i = 0; i < result.Data.Count; i++)
                {
                    Candles cndl = new Candles();
                    cndl.open = result.Data[i][1];
                    cndl.high = result.Data[i][2];
                    cndl.low = result.Data[i][3];
                    cndl.close = result.Data[i][4];
                    result2.Add(cndl);
                }
            }
            catch
            {
                return null;
            }

            return result2;
        }

        public static async Task<bool> GetBalances()
        {
            if (FreeBalance != null) FreeBalance.Clear();

            string url = "/api/v5/account/balance";
            string res = await SecretCodeRequestGET(url);
            ErrorString = url + "\n" + res;

            if (res.Length < 5) return false;
            if (res.Substring(0, 5) == "ERROR") return false;

            try
            {
                BalancesFull result = JsonConvert.DeserializeObject<BalancesFull>(res);

                if ((result == null) || (result.Data == null) || (result.Data.Count <= 0) || (result.Data[0].Details == null)) return false;
                if (result.code > 0) return false;

                for (int i = 0; i < result.Data[0].Details.Count; i++)
                {
                    if (result.Data[0].Details[i].Available1 != null)
                        FreeBalance.Add(result.Data[0].Details[i].Coin, (double)result.Data[0].Details[i].Available1);
                    else if (result.Data[0].Details[i].Available2 != null)
                        FreeBalance.Add(result.Data[0].Details[i].Coin, (double)result.Data[0].Details[i].Available2);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static async Task<Order> SendMarketOrder(string symbol, string side, double quantity)
        {
            string qt = quantity.ToString("0." + new string('#', 339)).Replace(",", ".");
            string url = "/api/v5/trade/order";
            string json = "{\"instId\":\"" + symbol + "\",\"side\":\"" + side.ToLower() + "\",\"sz\":\"" + qt + "\",\"tdMode\":\"cash\",\"tgtCcy\":\"base_ccy\",\"ordType\":\"market\"}";


            string res = await SecretCodeRequestPOST(json, url);
            ErrorString = url + "\n" + json + "\n" + res;

            if (res.Length < 5) return null;
            if (res.Substring(0, 5) == "ERROR") return null;

            try
            {
                OrderFull result = JsonConvert.DeserializeObject<OrderFull>(res);

                if ((result == null) || (result.Data == null) || (result.Data.Count <= 0)) return null;

                if (result.code > 0) return null;


                return result.Data[0];
            }
            catch
            {
                return null;
            }

        }

    }
}
