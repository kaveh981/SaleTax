using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mapi.Models
{
    public class ItemCategory
    {
         [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Category  { get; set; }

        public decimal SaleTax { get; set; }

        public  List<Article> Items  { get; set; }
    }
}