using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Helper
{
    public class ResponseEditMiddleware
    {
        private RequestDelegate nextDelegate;
        public ResponseEditMiddleware(RequestDelegate next)
        {
            nextDelegate = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            await nextDelegate.Invoke(httpContext);
            if (httpContext.Response.StatusCode == 404)
            {
                await httpContext.Response
                .WriteAsync("Not Found 404 ", Encoding.UTF8);
            }
        }
    }
}
