using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniTrello_Hahn.Domain.Interfaces;
using MiniTrello_Hahn.Infrastructure.Data;

namespace MiniTrello_Hahn.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IBoardRepository Boards { get; private set; }
        public ICardRepository Cards { get; private set; }
        public IBoardListRepository BoardLists { get; private set; }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Boards = new BoardRepository(_context);
            BoardLists = new BoardListRepository(_context);
            Cards = new CardRepository(_context);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
