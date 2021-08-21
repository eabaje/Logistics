using Logistics.Shared.Enumerations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared.Enumerations
{
    public class PaymentDTO
    {
        public string PaymentId { get; set; }
        public string ProductName { get; set; }
        public long Amount { get; set; }
        public string ImageUrl { get; set; }
        public string ReturnUrl { get; set; }

        public DateTime PaymentDate { get; set; }
        public string PaymentSessionId { get; set; }
        public string ReferenceId { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
