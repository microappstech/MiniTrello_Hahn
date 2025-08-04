using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTrello_Hahn.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IBoardRepository Boards { get; }
        ICardRepository Cards { get; }
        IBoardListRepository BoardLists { get; }
        Task SaveAsync();
    }
}
