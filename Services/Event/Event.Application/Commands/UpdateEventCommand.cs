using MediatR;
using Common.Shared.Bases;

namespace Event.Application.Commands;
public class UpdateEventCommand : IRequest<BaseResponse<bool>>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Location { get; set; }
}