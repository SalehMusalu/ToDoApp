using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ToDoApp.Application.DTOs;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Mappers
{
    public class ToDoItemMappingProfile : Profile
    {
        public ToDoItemMappingProfile()
        {
            CreateMap<ToDoItem, ToDoItemDTO>().ReverseMap();
        }
    }
}
