using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistics.Service.API.Helper
{
    public class MailJetSettings
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public string Email { get; set; }

        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }
}
