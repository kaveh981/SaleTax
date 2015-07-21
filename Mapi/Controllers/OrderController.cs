using Mapi.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mapi.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrder _Order;


        public OrderController(IOrder order)
        {
            _Order = order;
        }

        [HttpGet]
        public HttpResponseMessage getOrders()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _Order.getOrders());
        }

        [HttpGet]
        public HttpResponseMessage getOrdeForPrint(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _Order.getOrdeForPrint(id));
        }

        private decimal calculateTax(decimal price, decimal tax)
        {
            return _Order.calculateTax(price, tax);
        }

        [HttpGet]
        public HttpResponseMessage getOrderDetailsByOrderId(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _Order.getOrderDetailsByOrderId(id));
        }
        public HttpResponseMessage PostOrder([FromBody]Mapi.Models.Order order)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                _Order.PostOrder(order);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, order);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        [HttpDelete]
        public HttpResponseMessage DeleteOrder(int id)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                _Order.DeleteOrder(id);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, id);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

    }
}

