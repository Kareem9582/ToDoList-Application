using AutoMapper;
using ToDoList.Api.Models;
using ToDoList.Persistence.Entities;

namespace ToDoList.Api.AutoMapper.Profiles
{
    public class ToDoListItemProfile : Profile
    {
        public ToDoListItemProfile()
        {
            CreateMap<ToDoListItem, GetItemModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.ItemId))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.ItemTitle))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.ItemDescription));
            }
    }
}
