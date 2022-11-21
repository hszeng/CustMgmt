using CustMgmt.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Text;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace CustMgmt.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        public JsonExceptionFilter(IWebHostEnvironment env, ILogger<Program> logger)
        {
            Environment = env;
            Logger = logger;
        }

        public IWebHostEnvironment Environment { get; }
        public ILogger Logger { get; }

        public void OnException(ExceptionContext context)
        {
            var error = new ApiError();
            if (Environment.IsDevelopment())
            {
                error.Message = context.Exception.Message;
                error.Detail = context.Exception.ToString();
            }
            else
            {
                error.Message = "Service internal error";
                error.Detail = context.Exception.Message;// We may need to eliminate "Detail" in production environment.
            }

            if (context.Exception is DbUpdateConcurrencyException)
            {
                context.Result = new ObjectResult(error)
                {
                    StatusCode = StatusCodes.Status409Conflict
                };
            }
            else
            {
                context.Result = new ObjectResult(error)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Exception in Service: {context.Exception.Message}");
            sb.AppendLine(context.Exception.ToString());
            Logger.LogCritical(sb.ToString());
        }
    }

    public class ApiError
    {
        public string Detail { get; set; }
        public string Message { get; set; }
    }
}