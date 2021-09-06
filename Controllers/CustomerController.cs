using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;

namespace CoreApi.Controllers
{
    [Route("api/customer")]
    public class CustomerController : BaseController<Customer> 
    {
        public CustomerController(ICustomerService service, ILogger<BaseController<Customer>> logger) :base(service,logger)
        {

        }

    }
}