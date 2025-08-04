using AutoMapper;
using MiniTrello_Hahn.Application.DTOs;
using MiniTrello_Hahn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTrello_Hahn.Application.Mapping
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Board, BoardDto>();
            CreateMap<Board, BoardDto>();
            CreateMap<MiniTrello_Hahn.Domain.Entities.BoardList, BoardListDto>();
            CreateMap<Card, CardDto>();

            
                //.ForMember(dest => dest.Lists, opt => opt.MapFrom(src =>
                //src.Lists.Select(l => new BoardListDto
                //{
                //    Id = l.Id,
                //    Name = l.Title,
                //    Cards = l.Cards.Select(c => new CardDto
                //    {
                //        Id = c.Id,
                //        Title = c.Title,
                //        Description = c.Description
                //    }).ToList()
                //}).ToList()))
        }
    }
}
