using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingAround2.Models;

namespace TestingAround2.Repositories
{
    public interface IBetRepository
    {
        Task<IEnumerable<Bet>> Get();
        Task<Bet> Get(Guid id);
        Task<Bet> Create(Bet bet);
        Task<Bet> Update(Bet bet);
        Task<Bet> Delete(Guid id);
    }
}
