using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingAround2.Data;
using TestingAround2.Models;
using TestingAround2.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestingAround2.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        private readonly IBetRepository context;

        public BetController(IBetRepository context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Bet>> Get()
        {
            return await context.Get();
        }

        // GET api/<BetController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bet>> Get(Guid id)
        {
            Bet bet = await context.Get(id);
            if(bet == null)
            {
                return NotFound();
            }
            return bet;
        }

        // POST api/<BetController>
        [HttpPost]
        public async Task<ActionResult<Bet>> Post([FromBody] Bet bet)
        {
            return await context.Create(bet);
        }

        // PUT api/<BetController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Bet>> Put(Guid id,[FromBody] Bet bet)
        {
            if(id != bet.Id)
            {
                return BadRequest();
            }

            Bet bet1 = await context.Get(id);
            if(bet1 == null)
            {
                return NotFound();
            }
            await context.Update(bet);
            return bet;
        }

        // DELETE api/<BetController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bet>> DeleteAsync(Guid id)
        {
            Bet bet = await context.Get(id);
            if(bet == null)
            {
                return NotFound();
            }
            await context.Delete(id);
            return bet;
        }
    }
}
