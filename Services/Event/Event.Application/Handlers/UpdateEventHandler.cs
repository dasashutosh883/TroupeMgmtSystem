using AutoMapper;
using Common.Shared.Bases;
using Event.Application.Commands;
using Event.Core.Entities;
using Event.Core.Repositories;
using MediatR;


namespace Event.Application.Handlers;
public class UpdateEventHandler : IRequestHandler<UpdateEventCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateEventHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<BaseResponse<bool>> Handle(UpdateEventCommand command, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();
            try
            {
                var eventDetails = _mapper.Map<EventDetails>(command);
                response.Data = await _unitOfWork.Event.UpdateAsync(eventDetails);
                if (response.Data) 
                {
                    response.succcess = true;
                    response.Message  = "Update succeed!";
                }
            }
            catch (Exception ex)
            {
                response.Message  = ex.Message;
            }
            return response;
    }
}