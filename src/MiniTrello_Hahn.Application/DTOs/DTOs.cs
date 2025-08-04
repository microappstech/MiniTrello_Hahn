using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTrello_Hahn.Application.DTOs
{
    public class CreateBoardDto
    {
        public string Title { get; set; }
    }
    public class CreateBoardListDto
    {
        public string Title { get; set; }
        public Guid BoardId { get; set; }
    }
    public class BoardDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<BoardListDto> Lists { get; set; }

    }
    public class BoardListDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid BoardId { get; set; }
        public BoardDto Board { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<CardDto> Cards { get; set; }
    }
    public class CreateCardDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ListId { get; set; }
    }
    public class CardDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ListId { get; set; }
        public DateTime CreatedAt { get; set; }
        public BoardListDto BoardList { get; set; }
    }
}
