using AutoMapper;
using Common.Shared.Bases;
using Event.Application.Dtos;
using Event.Application.Queries;
using Event.Core.Repositories;
using MediatR;

namespace Event.Application.Handlers;
public class GetAllEventHandler : IRequestHandler<GetAllEventQuery, BaseResponse<IEnumerable<EventDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllEventHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<IEnumerable<EventDto>>> Handle(GetAllEventQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<EventDto>>();

            try
            {
                var Events = await _unitOfWork.Event.GetAllAsync();

                if(Events is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<EventDto>>(Events);
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
