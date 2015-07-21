using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mapi.Models
{
    public class Article
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ItemName { get; set; }

        public decimal ImportedSaleTax { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("ItemCategory")]
        public int CategoryId { get; set; }

        [JsonIgnore]
        public virtual ItemCategory ItemCategory { get; set; }
  
    }
}