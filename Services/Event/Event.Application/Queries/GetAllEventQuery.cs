using Common.Shared.Bases;
using Event.Application.Dtos;
using MediatR;

namespace Event.Application.Queries;
public class GetAllEventQuery : IRequest<BaseResponse<IEnumerable<EventDto>>>
{
}