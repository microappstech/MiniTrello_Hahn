using Microsoft.EntityFrameworkCore;
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
    public class BoardRepository : IBoardRepository
    {
        private readonly AppDbContext _context;

        public BoardRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Board board)
        {
            await _context.Boards.AddAsync(board);
        }
        public async Task<IEnumerable<Board>> GetAllAsync()
        {
            return await _context.Boards.ToListAsync();
        }
    }
}
