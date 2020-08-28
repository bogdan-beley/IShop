using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace IShop.Filters
{
    public class FileNotFoundExFilter : IExceptionFilter
    {
        public bool AllowMultiple => false;

        public async Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            if (actionExecutedContext.Exception != null && actionExecutedContext.Exception is FileNotFoundException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, "File not found!");
            }
        }
    }
}