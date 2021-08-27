using Logistics.Shared.Enumerations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logistics.Shared.Models
{
    public class OrderDTO 
    {
        public string OrderId { get; set; }
        public string CustomerId { get; set; }

        public string PaymentSessionId { get; set; }

        public string Email { get; set; }
        public string SalonId { get; set; }
        public string ServiceTypeId { get; set; }
        public decimal TotalPrice { get; set; }

        public bool IsPaymentSuccessful { get; set; } = false;

        public PaymentMethod PaymentMethod { get; set; }

        public OrderStatus OrderStatus { get; set; }

        //public OrderItemDTO OrderItemDTO { get; set; }
        //public ICollection<OrderItemDTO> OrderItemsDTO { get; set; }
    }

 
}
