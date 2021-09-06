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
    [Route("api/product")]
    public class ProductController : BaseController<Product>
    {
       public ProductController(IProductService service, ILogger<BaseController<Product>> logger) :base(service,logger)
        { 
        }
    }
}