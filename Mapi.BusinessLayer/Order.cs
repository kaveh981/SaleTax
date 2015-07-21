using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapi.DataLayer;
using Mapi.Models;
namespace Mapi.BusinessLayer
{
   public class Order:IOrder
    {
        
        IUnitOfWork _unitOfWork =null;

        public Order (IUnitOfWork unitOfWork)
        {
            _unitOfWork =  unitOfWork;
        }

        public IEnumerable<Mapi.Models.Order> getOrders()
        {
            return _unitOfWork.Repository<Mapi.Models.Order>().Get();
        }

        public IEnumerable<OrderDetail> getOrderDetailsByOrderId(int id)
        {
            return _unitOfWork.Repository<OrderDetail>().Get(i => i.OrderId == id);
        }

        public void PostOrder(Mapi.Models.Order order)
        {
            foreach (var orderDetail in order.OrderDetails)
            {
                var item = _unitOfWork.Repository<Mapi.Models.Article>().GetById(o => o.Id == orderDetail.ItemId);
                orderDetail.saleTax = item.ItemCategory.SaleTax;
                orderDetail.importedSaleTax = item.ImportedSaleTax;
            }
            _unitOfWork.Repository<Mapi.Models.Order>().Insert(order);
            _unitOfWork.Save();
        }

       public void DeleteOrder(int id)
        {
            _unitOfWork.Repository<Mapi.Models.Order>().Delete(id);
            _unitOfWork.Save();
        }



        public decimal calculateTax(decimal price, decimal tax)
        {
            return (tax == 0 || tax == null) ? 0 : Math.Ceiling((price * tax / 100) * 20) / 20;
        }

        public PrintOrder getOrdeForPrint(int id)
        {
            var order = _unitOfWork.Repository<Mapi.Models.Order>().GetById(o => o.Id == id, p => p.OrderDetails, p => p.OrderDetails.Select(s => s.Item), p => p.OrderDetails.Select(s => s.Item.ItemCategory));
            PrintOrder printOrder = new PrintOrder();
            decimal totalSaleTax = 0;
            decimal totalImportedSaleTax = 0;
            decimal totalPrice = 0;
            List<PrintOrderDetail> PrintOrderDetails = new List<PrintOrderDetail>();
            foreach (var orderDetail in order.OrderDetails)
            {
                var saleTax = calculateTax(orderDetail.price, orderDetail.saleTax);
                var importingSaleTax = calculateTax(orderDetail.price, orderDetail.importedSaleTax);
                PrintOrderDetail printOrderDetail = new PrintOrderDetail();
                printOrderDetail.importedSaleTax = importingSaleTax;
                printOrderDetail.saleTax = saleTax;
                printOrderDetail.price = orderDetail.price;
                printOrderDetail.name = orderDetail.Item.ItemName;
                PrintOrderDetails.Add(printOrderDetail);

                totalImportedSaleTax += importingSaleTax;
                totalSaleTax += saleTax;
                totalPrice += orderDetail.price;
            }
            printOrder.printOrderDetails = PrintOrderDetails;
            printOrder.total = totalPrice;
            printOrder.totalImportedSaleTax = totalImportedSaleTax;
            printOrder.totalSaleTax = totalSaleTax;
            return printOrder;
        }

 
    }
}
