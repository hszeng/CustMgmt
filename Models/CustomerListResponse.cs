using CustMgmt.Models;
using System.Collections.Generic;

namespace CustMgmt.Models
{
    public class CustomerListResponse
    {
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }

        public List<CustomerDto> Customers;

    }
}