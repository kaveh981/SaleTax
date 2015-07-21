using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mapi.Models
{
    public class SaleTaxDatabaseInitializer  :  DropCreateDatabaseAlways<SaleTaxContext>
    {
        protected override void Seed(SaleTaxContext context)
        {
            IList<ItemCategory> defaultCategories = new List<ItemCategory>();

            defaultCategories.Add(new ItemCategory() { Category = "Cat1", SaleTax=4 });
            defaultCategories.Add(new ItemCategory() { Category = "Cat2", SaleTax = 4 });
            defaultCategories.Add(new ItemCategory() { Category = "Cat3", SaleTax = 4 });
            defaultCategories.Add(new ItemCategory() { Category = "Cat4", SaleTax = 4 });
            foreach (ItemCategory item in defaultCategories)
           {
               context.ItemCategoryies.Add(item);
           }
            base.Seed(context);
        }
    }
}

