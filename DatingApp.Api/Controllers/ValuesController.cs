using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatingApp.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace DatingApp.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context=context;

        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Getvalues()
        {
            //accessing datacontext using _context, Values table in Datacontext to return the results as a list
            var values= await _context.Values.ToListAsync();

            return Ok(values);
        }

        [AllowAnonymous]
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getvalue(int id)
        {
            //First or default is used to return the first value or a default value, we could have used first but if the
            //id is not found it would throw an  expception, so first or default is used.
            //if that particular id is not found it sends "Status 204 No Content" response
            var value=await _context.Values.FirstOrDefaultAsync(x=>x.Id == id);

            return Ok(value);
        }



        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
