using Mapi.BusinessLayer;
using Mapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mapi.Controllers
{
    public class ItemController : ApiController
    {
        private readonly IItem _Item;


        public ItemController(IItem item)
        {
            _Item = item;
        }


        [HttpGet]
        public HttpResponseMessage getItems()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _Item.GetItems().Select(s => new { s.ItemCategory.Category,s.CategoryId,s.Id,s.ImportedSaleTax,s.ItemName,s.Price}));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            }
        }

        public HttpResponseMessage PostItem(Article item)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                _Item.PostItem(item);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, item);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        [HttpPut]
        public HttpResponseMessage UpdateItem(Article item)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                _Item.UpdateItem(item);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, item);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        [HttpDelete]
        public HttpResponseMessage DeleteItem(int id)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                _Item.DeleteItem(id);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, id);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpGet]
        public HttpResponseMessage getItemCategories()
        {
            
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _Item.GetItemCategories());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            }
        }
        public HttpResponseMessage PostItemCategory([FromBody]ItemCategory itemCategory)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                _Item.PostItemCategories(itemCategory);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, itemCategory);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        [HttpPut]
        public HttpResponseMessage UpdateItemCategory([FromBody]ItemCategory itemCategory)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                _Item.UpdateItemCategory(itemCategory);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, itemCategory);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        [HttpDelete]
        public HttpResponseMessage DeleteItemCategory(int id)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                _Item.DeleteItemCategory(id);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, id);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        protected override void Dispose(bool disposing)
        {
            _Item.Dispose();
            base.Dispose(disposing);
        }
    }
}
