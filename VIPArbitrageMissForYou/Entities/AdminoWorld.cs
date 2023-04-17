using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIPArbitrageMissForYou.Entities
{
    public class AdminoWorld
    {
        public int Id { get; set; }
        public string Exchanges { get; set; }
        public string APICommand1 { get; set; }
        public string APICommand2 { get; set; }
        public string APICommand3 { get; set; }
        public string APICommand4 { get; set; }
        public string APICommand5 { get; set; }
        public string MailForNotify { get; set; }
        public string MailPasswordKeyForAccess { get; set; }
        public string MailPasswordToAccount { get; set; }
    }
}
