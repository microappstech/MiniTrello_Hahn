using MiniTrello_Hahn.Domain.Entities;
using MiniTrello_Hahn.Domain.Interfaces;
using MiniTrello_Hahn.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTrello_Hahn.Infrastructure.Persistence.Repositories
{
    public class CardRepository:ICardRepository
    {
        private readonly AppDbContext _context;

        public CardRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Card card)
        {
            await _context.Cards.AddAsync(card);
        }

        public Task<IEnumerable<Card>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
