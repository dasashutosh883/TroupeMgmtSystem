using MediatR;
using Common.Shared.Bases;

namespace Event.Application.Commands;
public class CreateEventCommand : IRequest<BaseResponse<bool>>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Location { get; set; }
}