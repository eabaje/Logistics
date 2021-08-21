// [JsonProperty.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Logistics.Shared.Models
{
    public class TransactionDTO
    {
        public Guid TransactionId { get; set; }


        [DisplayName("Transaction Ref")]
        public string TransactionRef { get; set; }



        [DisplayName("Transaction Date")]
        public DateTime TransactionDate { get; set; }


        [DisplayName("Amount")]
        public decimal Amount { get; set; }


        [DisplayName("Transaction Status")]
        public string TransactionStatus { get; set; }
    }
}
