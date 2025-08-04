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
    public class BoardListRepository : IBoardListRepository
    {
        private readonly AppDbContext _context;

        public BoardListRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(BoardList boardList)
        {
            await _context.BoardLists.AddAsync(boardList);
        }
        public async Task<IEnumerable<BoardList>> GetAllAsync()
        {
            return await _context.BoardLists.ToListAsync();
        }
    }
}
