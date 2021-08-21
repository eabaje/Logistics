using System;
using System.Collections.Generic;
using System.Text;

namespace Logistics.Service.API.Entities
{
    public partial class EmailTemplate : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Instruction { get; set; }
        public override int EntityId => Id;
    }
}
