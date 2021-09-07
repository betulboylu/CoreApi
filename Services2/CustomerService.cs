using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class CustomerService: BaseService<Customer>,ICustomerService
    {
        public CustomerService(WebApiDbContext dbContext) : base(dbContext)
        { 
        }
    }
}
