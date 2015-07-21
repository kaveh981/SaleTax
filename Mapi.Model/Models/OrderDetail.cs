using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mapi.Models
{
    public class OrderDetail
    {

        [Key, Column(Order = 1), ForeignKey("Item")]
        public int ItemId { get; set; }

        [Key, Column(Order = 0), ForeignKey("Order")]
        public int OrderId { get; set; }

        public decimal price { get; set; }

        public decimal importedSaleTax { get; set; }

        public decimal saleTax { get; set; }
        [JsonIgnore]
        public virtual Order Order { get; set; }
        [JsonIgnore]
        public virtual Article Item { get; set; }
    }
}