using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApp.Dtos;
using DemoApp.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Controllers
{
    public class TypesController : DemoAppBaseController
    {
        public TypesController(DemoAppDbContext dbContext) : base(dbContext)
        {
        }

        [HttpGet, Route("{lang}/{type}")]
        public async Task<IActionResult> GetAll(string lang, string type)
        {
            try
            {
                var query = dbContext.Types.Where(x => x.Discriminator.ToLower() == type.ToLower());
                var projection = query.Select(s => new IdNameDto()
                {
                    Id = s.Id,
                    Name = s.Name
                });

                var result = await projection.ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
