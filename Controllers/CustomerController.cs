using AutoMapper;
using CustMgmt.Entities;
using CustMgmt.Models;
using CustMgmt.Models;
using CustMgmt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustMgmt.Controllers
{
    [Route("api/Customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ILogger<CustomerController> _logger { get; }
        private CustomerService _customerService { get; }

        public CustomerController(CustomerService customerService,ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }


        [HttpPost()]
        public async Task<ActionResult> CreateCustomerAsync(CustomerForCreationDto customerForCreationDto)
        {

            var customerDto = await _customerService.CreateAsync(customerForCreationDto);
            return CreatedAtRoute(nameof(GetCustomerAsync),new { CustomerId = customerDto.Id }, customerDto);
        }

        [HttpDelete("{CustomerId}")]
        public async Task<ActionResult> DeleteCustomerAsync(Guid CustomerId)
        {
            var Customer = await _customerService.GetByIdAsync(CustomerId);
            if (Customer == null)
            {
                return NotFound();
            }

           var result = await _customerService.DeleteAsync(CustomerId);
            if (!result)
            {
                throw new Exception("Delete Customer Failed");
            }

            return NoContent();
        }

        [HttpGet("{CustomerId}", Name = nameof(GetCustomerAsync))]
        public async Task<ActionResult<CustomerDto>> GetCustomerAsync(Guid CustomerId)
        {
            var customerDto = await _customerService.GetByIdAsync(CustomerId);
            if (customerDto == null)
            {
                return NotFound();
            }

            return customerDto;
        }

        [HttpGet(Name = nameof(GetCustomersAsync))]
        public async Task<ActionResult<CustomerListResponse>> GetCustomersAsync([FromQuery]CustomerListRequest parameters)
        {
            var CustomerListResponse = await _customerService.GetAllAsync(parameters);
            return CustomerListResponse;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomerAsync(CustomerForUpdateDto updatedCustomer)
        {
            if (!await _customerService.IsExistAsync(updatedCustomer.Id))
            {
                return NotFound();
            }
            var newNoteDto = await _customerService.Update(updatedCustomer);
            if (newNoteDto == null)
            {
                throw new Exception("Update Customer Failed");
            }
            return NoContent();
        }
    }
}