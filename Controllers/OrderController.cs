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
    [Route("api/order")]
    public class OrderController : BaseController<Order>
    {
        public OrderController(IOrderService service, ILogger<BaseController<Order>> logger) :base(service, logger)
        {

        }

    }
}