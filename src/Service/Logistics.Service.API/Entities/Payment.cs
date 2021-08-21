
using Logistics.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logistics.Service.API.Entities
{
    public class Payment : BaseCompany
    {
        [Key]
        public Guid PaymentId { get; set; }

        public override Guid EntityId => PaymentId;
        public string CustomerId { get; set; }

        public DateTime PaymentDate { get; set; }
        public string OrderId { get; set; }
        public decimal TotalPrice { get; set; }

        public string PaymentSessionId { get; set; }
        public string ReferenceId { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public  PaymentMethod PaymentMethod { get; set; }

    }

   
}
