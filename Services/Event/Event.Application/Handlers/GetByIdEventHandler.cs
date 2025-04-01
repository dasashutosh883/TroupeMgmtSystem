using AutoMapper;
using Common.Shared.Bases;
using Event.Application.Dtos;
using Event.Application.Queries;
using Event.Core.Repositories;
using MediatR;

namespace Event.Application.Handlers;
public class GetByIdEventHandler : IRequestHandler<GetByIdEventQuery, BaseResponse<EventDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByIdEventHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<EventDto>> Handle(GetByIdEventQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<EventDto>();
            try
            {
                var Event = await _unitOfWork.Event.GetByIdAsync(request.Id);
                if(Event is not null)
                {
                    response.Data = _mapper.Map<EventDto>(Event);
                    response.succcess = true;
                    response.Message = "Query succeed!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }