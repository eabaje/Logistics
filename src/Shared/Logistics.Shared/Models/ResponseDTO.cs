using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Newtonsoft.Json;

namespace Logistics.Shared.Models
{
   public class ResponseDTO
    {
        // [JsonProperty("IsSuccessful")]


        //  [JsonProperty("ResponseMessage")]

        //[JsonProperty(PropertyName = "ResponseMessage")]
        public string ResponseMessage { get; set; }

        //[JsonProperty(PropertyName = "IsSuccessful")]
        public bool IsSuccessful { get; set; }
    }
}
