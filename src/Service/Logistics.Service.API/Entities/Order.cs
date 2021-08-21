
using Logistics.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logistics.Service.API.Entities
{
    public class Order : BaseCompany
    {
        [Key]

        public Guid OrderId { get; set; }

        public override Guid EntityId => OrderId;
        public string CustomerId { get; set; }
   
       
        public decimal TotalPrice { get; set; }

        public string PaymentSessionId { get; set; }
        public bool IsPaymentSuccessful { get; set; } = false;
        public OrderStatus OrderStatus { get; set; }
     //   public ICollection<OrderItem> OrderItem { get; set; }

    }

   

   
}
