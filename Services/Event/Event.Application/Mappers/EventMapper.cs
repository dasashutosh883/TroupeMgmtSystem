using AutoMapper;
using Event.Application.Commands;
using Event.Application.Dtos;
using Event.Core.Entities;

namespace Event.Application.Mappers;
public class EventMapper : Profile
{
    public EventMapper()
    {
        CreateMap<CreateEventCommand, EventDetails>().ReverseMap();
        CreateMap<UpdateEventCommand, EventDetails>().ReverseMap();
        CreateMap<EventDetails, EventDto>();
    }
}