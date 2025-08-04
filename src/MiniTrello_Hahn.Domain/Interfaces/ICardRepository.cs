using MiniTrello_Hahn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTrello_Hahn.Domain.Interfaces
{
    public interface ICardRepository
    {
        public Task AddAsync(Card card);
        public Task<IEnumerable<Card>> GetAllAsync();
    }
}
