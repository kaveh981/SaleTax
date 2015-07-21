using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapi.Models
{
    public class PrintOrder
    {
        public int id { get; set; }
        public decimal total { get; set; }

        public decimal totalImportedSaleTax { get; set; }

        public decimal totalSaleTax { get; set; }
        public List<PrintOrderDetail> printOrderDetails { get; set; }
    }

    public class PrintOrderDetail
    {
        public string name { get; set; }

        public decimal importedSaleTax { get; set; }

        public decimal saleTax { get; set; }

        public decimal price   { get; set; }

    }
}