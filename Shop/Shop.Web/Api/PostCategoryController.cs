using Shop.Data;
using Shop.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shop.Web.Api
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategories postCategory)
        {
            return CreateHttpRespone(request, () =>
             {
                 HttpResponseMessage response = null;
                 if(ModelState.IsValid)
                 {
                     request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                 }
                 else
                 {
                     postCategory.Insert();
                     response = request.CreateResponse(HttpStatusCode.Created, postCategory);
                 }
                 return response;
             });
        }
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategories postCategory)
        {
            return CreateHttpRespone(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    postCategory.Update();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpRespone(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    new PostCategories().Delete(id);
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }

        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpRespone(request, () =>
            {
                HttpResponseMessage response = null;
                List<PostCategories> lstPostCategory = new PostCategories().GetAll();
                response = request.CreateResponse(HttpStatusCode.OK, lstPostCategory);
                return response;
            });
        }
    }
}