using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIPArbitrageMissForYou.Entities
{
    public class P2PHelper
    {
        public int Id { get; set; }
        public int Id_clients { get; set; }
        public string exchanges { get; set; }
        public string cryptopair { get; set; }
        public decimal price { get; set; }
        public decimal profit { get; set; }
    }
}
