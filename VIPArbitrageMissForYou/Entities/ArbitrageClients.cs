using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIPArbitrageMissForYou.Entities
{
    public class ArbitrageClients
    {
        public int Id { get; set; }
        public string Login_ { get; set; }
        public string Password_ { get; set; }
        public string API1Huobi { get; set; }
        public string API1HuobiSecretKey { get; set; }
        public string API2Binance { get; set; }
        public string API2BinanceSecretKey { get; set; }
        public string API3Uniswap { get; set; }
        public string API3UniswapSecretKey { get; set; }
        public string API4Kraken { get; set; }
        public string API4KrakenSecretKey { get; set; }
        public string API5Pancakeswap { get; set; }
        public string API5PancakeswapSecretKey { get; set; }
        public string Passphrase { get; set; }
        public string Passphrase2 { get; set; }
    }
}
