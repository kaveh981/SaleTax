using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapi.DataLayer;
using Mapi.Models;

namespace Mapi.BusinessLayer
{
    public class Item : IItem
    {
        IUnitOfWork _unitOfWork =null;

        public Item (IUnitOfWork unitOfWork)
        {
            _unitOfWork =  unitOfWork;
        }

        public IEnumerable<ItemCategory> GetItemCategories()
        {
            
            return _unitOfWork.Repository<ItemCategory>().Get(t => t.Category == "Cat1" && t.SaleTax > 3, t => t.OrderBy(s => s.Category), t => t.Items);
        }
        public void PostItemCategories(ItemCategory itemCategory)
        {
            _unitOfWork.Repository<ItemCategory>().Insert(itemCategory);
            _unitOfWork.Save();
        }
        public void DeleteItemCategory(int id)
        {
            _unitOfWork.Repository<ItemCategory>().Delete(id);
            _unitOfWork.Save();
        }

        public void UpdateItemCategory(ItemCategory itemCategory)
        {
            _unitOfWork.Repository<ItemCategory>().Update(itemCategory);
            _unitOfWork.Save();
        }

        public IEnumerable<Mapi.Models.Article> GetItems()
        {
            return _unitOfWork.Repository<Mapi.Models.Article>().Get();
        }
        public void PostItem(Mapi.Models.Article item)
        {
            _unitOfWork.Repository<Mapi.Models.Article>().Insert(item);
            _unitOfWork.Save();
            //genericUnitOfWork.Dispose();
        }
        public void DeleteItem(int id)
        {
            _unitOfWork.Repository<Article>().Delete(id);
            _unitOfWork.Save();
        }

        public void UpdateItem(Article item)
        {
            _unitOfWork.Repository<Article>().Update(item);
            _unitOfWork.Save();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

    }
}
