using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApp.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{

    public class StatusController : DemoAppBaseController
    {
        public StatusController(DemoAppDbContext dbContext) : base(dbContext)
        {
        }

        [HttpGet, Route("")]
        public IActionResult GetStatus()
        {
            return Content("Ok");
        }
    }
}
