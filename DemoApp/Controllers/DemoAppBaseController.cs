using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApp.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoAppBaseController : ControllerBase
    {
        internal readonly DemoAppDbContext dbContext;

        public DemoAppBaseController(DemoAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
