using Shop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace Shop.Web.Infrastructure.Core
{
    public class ApiControllerBase : ApiController
    {
        protected HttpResponseMessage CreateHttpRespone(HttpRequestMessage requestMessage, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage respone = null;
            try
            {
                respone = function.Invoke();
            }
            catch (Exception ex)
            {
                LogError(ex);
                respone = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            
            return respone;
        }

        private void LogError(Exception ex)
        {
            new ErrorLog().WriteLog(ex, "", MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Namespace, "");
        }
    }
}
