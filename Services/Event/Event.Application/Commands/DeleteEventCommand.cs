using MediatR;
using Common.Shared.Bases;

namespace Event.Application.Commands;

public class DeleteEventCommand : IRequest<BaseResponse<bool>>
{
    public int Id { get; set; }
}