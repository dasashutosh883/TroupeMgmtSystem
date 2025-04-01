using Common.Shared.Bases;
using Event.Application.Dtos;
using MediatR;

namespace Event.Application.Queries;
public class GetByIdEventQuery : IRequest<BaseResponse<EventDto>>
{
    public int Id{ get; set; }
}