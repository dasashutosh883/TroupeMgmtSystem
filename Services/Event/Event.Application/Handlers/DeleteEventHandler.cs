using AutoMapper;
using Common.Shared.Bases;
using Event.Application.Commands;
using Event.Core.Entities;
using Event.Core.Repositories;
using MediatR;


namespace Event.Application.Handlers;
public class DeleteEventHandler : IRequestHandler<DeleteEventCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteEventHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<BaseResponse<bool>> Handle(DeleteEventCommand command, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();
            try
            {
            
                response.Data = await _unitOfWork.Event.DeleteAsync(command.Id);
                if (response.Data) 
                {
                    response.succcess = true;
                    response.Message  = "Delete succeed!";
                }
            }
            catch (Exception ex)
            {
                response.Message  = ex.Message;
            }
            return response;
    }
}