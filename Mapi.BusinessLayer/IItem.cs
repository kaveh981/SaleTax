using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapi.Models;

namespace Mapi.BusinessLayer
{
    public interface IItem
    {
        IEnumerable<Mapi.Models.Article> GetItems();
        IEnumerable<ItemCategory> GetItemCategories();

        void PostItem(Mapi.Models.Article item);
        void PostItemCategories(ItemCategory item);

        void DeleteItem(int id);
        void UpdateItem(Article item);
        void DeleteItemCategory(int id);
        void UpdateItemCategory(ItemCategory itemCategory);

        void Dispose();
    }
}
