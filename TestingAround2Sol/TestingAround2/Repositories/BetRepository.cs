using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingAround2.Data;
using TestingAround2.Models;

namespace TestingAround2.Repositories
{
    public class BetRepository : IBetRepository
    {

        private readonly ApplicationDbContext context;
        public BetRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<Bet> Create(Bet bet)
        {
            bet.LastUpdated = null;
            context.Bets.Add(bet);
            await context.SaveChangesAsync();
            return bet;
        }

        public async Task<Bet> Delete(Guid id)
        {
            Bet bet = await context.Bets.FindAsync(id);
            context.Bets.Remove(bet);
            await context.SaveChangesAsync();
            return bet;
        }

        public async Task<IEnumerable<Bet>> Get()
        {
            return await context.Bets.ToListAsync();
        }

        public async Task<Bet> Get(Guid id)
        {
            return await context.Bets.FindAsync(id);
        }

        public async Task<Bet> Update(Bet bet)
        {
            bet.LastUpdated = DateTime.Now;
            Bet bet1 = await context.Bets.FindAsync(bet.Id);

            context.Entry(bet1).State = EntityState.Detached;
            context.Entry(bet).State = EntityState.Modified;

            await context.SaveChangesAsync();
            return bet;
        }
    }
}
