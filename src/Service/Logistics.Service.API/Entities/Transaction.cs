using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logistics.Service.API.Entities
{
    public class Transaction
    {
   
        [Key]
        public Guid TransactionId { get; set; }

     
        [DisplayName("Transaction Ref")]
        public string TransactionRef { get; set; }

        public string UserId { get; set; }

        [DisplayName("Transaction Date")]
        public DateTime TransactionDate { get; set; }

   
        [DisplayName("Amount")]
        public decimal Amount { get; set; }

    
        [DisplayName("Transaction Status")]
        public string TransactionStatus { get; set; }

       
    }
}
