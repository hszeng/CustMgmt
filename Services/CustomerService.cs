using AutoMapper;
using CustMgmt.Entities;
using CustMgmt.Extentions;
using CustMgmt.Models;
using CustMgmt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustMgmt.Services
{
    public class CustomerService :IService
    {

        public CustMgmtDbContext _dbContext { get; set; }
        private IMapper _mapper { get; }
        public CustomerService(CustMgmtDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CustomerDto> CreateAsync(CustomerForCreationDto entityDto)
        {

                var customer = _mapper.Map<Customer>(entityDto);
                    customer.CreatedAt = DateTime.UtcNow;
                _dbContext.Set<Customer>().Add(customer);
                var result = await _dbContext.SaveChangesAsync();

                var customerCreated = _mapper.Map<CustomerDto>(customer);
                return customerCreated;

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var customer = await _dbContext.Set<Customer>().FindAsync(id);
            customer.IsDeleted = true;
            customer.DeletedAt = DateTime.UtcNow;
            var result = await _dbContext.SaveChangesAsync();
            return result > 0 ? true: false;
        }

        // With Filters
        public async Task<CustomerListResponse> GetAllAsync(CustomerListRequest request)
        {
            var query = _dbContext.Set<Customer>()
                                      .WhereIf(!string.IsNullOrWhiteSpace(request.Name), cust => cust.Name == request.Name)
                                      .WhereIf(!string.IsNullOrWhiteSpace(request.Email), cust => cust.Email == request.Email)
                                      .WhereIf(request.Status != null, cust => cust.Status == request.Status.Value)
                                      .WhereIf(request.IsDeleted != null, cust => cust.IsDeleted == request.IsDeleted.Value);

            var totalCount = query.Count();
 
            query = !string.IsNullOrWhiteSpace(request.OrderBy) ? query.DynamicOrder(request.OrderBy, request.SortDirection) : query.OrderByDescending(cust => cust.CreatedAt);

            query = query.Skip(request.PageIndex * request.PageSize)
                           .Take(request.PageSize);
            var customers = await query.ToListAsync();
            return new CustomerListResponse() { Customers = _mapper.Map<List<CustomerDto>>(customers) , TotalCount = totalCount, PageIndex = request.PageIndex + 1};
        }

        public async Task<CustomerDto> Update(CustomerForUpdateDto entityDto)
        {
            var customer = await _dbContext.Set<Customer>().SingleOrDefaultAsync(cust => cust.Id == entityDto.Id);
            customer.Name = entityDto.Name;
            customer.Email = entityDto.Email;
            customer.Address = entityDto.Address;
            customer.Status = entityDto.Status;
            customer.ModifiedAt = DateTime.UtcNow;
            _dbContext.Set<Customer>().Update(customer);
              
            await _dbContext.SaveChangesAsync();

            var customerUpdated = _mapper.Map<CustomerDto>(customer);
            return customerUpdated;
        }

        public async Task<CustomerDto> GetByIdAsync(Guid id)
        {
            var customer = await _dbContext.Set<Customer>().FindAsync(id);
            return  _mapper.Map<CustomerDto>(customer);
        }

        public async Task<bool> IsExistAsync(Guid Id)
        {
            return await _dbContext.Set<Customer>().AnyAsync(cust => cust.Id == Id);
        }

    }
}