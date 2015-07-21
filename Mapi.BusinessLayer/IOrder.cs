using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapi.Models;

namespace Mapi.BusinessLayer
{
   public interface IOrder
    {
       IEnumerable<Mapi.Models.Order> getOrders();
       IEnumerable<OrderDetail> getOrderDetailsByOrderId(int id);
       void PostOrder(Mapi.Models.Order order);

       void DeleteOrder(int id);

       decimal calculateTax(decimal price, decimal tax);

       PrintOrder getOrdeForPrint(int id);
    }
}
