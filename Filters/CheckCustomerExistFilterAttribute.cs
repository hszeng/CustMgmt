using CustMgmt.Entities;
using CustMgmt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CustMgmt.Filters
{
    public class CheckCustomerExistFilterAttribute : ActionFilterAttribute
    {


        public CustMgmtDbContext _dbContext { get; private set; }
        public CheckCustomerExistFilterAttribute(CustMgmtDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var CustomerIdParameter = context.ActionArguments.Single(m => m.Key == "customerId");
            Guid CustomerId = (Guid)CustomerIdParameter.Value;

            var isExist =  _dbContext.Set<Customer>().Any( cust => cust.Id == CustomerId);
            if (!isExist)
            {
                context.Result = new NotFoundResult();
            }

            await base.OnActionExecutionAsync(context, next);
        }
    }
}