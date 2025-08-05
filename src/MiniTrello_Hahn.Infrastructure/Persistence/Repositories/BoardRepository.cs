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
            return await _context.Boards
                .Include(b => b.Lists)
                .ThenInclude(l => l.Cards)
                     .AsNoTracking()
                     .Select(board => new Board
                     {
                         Id = board.Id,
                         Name = board.Name,
                         CreatedAt = board.CreatedAt,
                         Lists = board.Lists.Select(list => new BoardList
                         {
                             Id = list.Id,
                             Title = list.Title,
                             BoardId = list.BoardId,
                             Cards = list.Cards.Select(card => new Card
                             {
                                 Id = card.Id,
                                 Title = card.Title,
                                 Description = card.Description,
                                 CreatedAt = card.CreatedAt
                             }).ToList()
                         }).ToList()
                     })
                     .ToListAsync();

        }
    }
}
