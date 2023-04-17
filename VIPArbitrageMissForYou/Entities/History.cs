using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIPArbitrageMissForYou.Entities
{
    public class History
    {
        public int Id { get; set; }
        public int Id_clients { get; set; }
        public string exchanges { get; set; }
        public decimal profit { get; set; }
        public decimal sold { get; set; }
        public decimal bought { get; set; }
        public DateTime? timehistory { get; set; }
        public decimal totalprofit { get; set; }
    }
}
