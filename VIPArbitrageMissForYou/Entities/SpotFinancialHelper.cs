using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIPArbitrageMissForYou.Entities
{
    public class SpotFinancialHelper
    {
        public int Id { get; set; }
        public int Id_clients { get; set; }
        public string cryptopair { get; set; }
        public string exchanges { get; set; }
        public int investments { get; set; }
        public decimal profitofthemash { get; set; }
        public DateTime? timehistory { get; set; }
    }
}
