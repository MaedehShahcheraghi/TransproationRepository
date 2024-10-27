using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence.CityRepository;
using TransportationSystem.Applciation.Features.CityMange.Requests.Commsnds;
using TransportationSystem.Applciation.Responses.BaseResponse;

namespace TransportationSystem.Applciation.Features.CityMange.Handlers.Handlers
{
    public class DeleteCityCommandRequestHandler : IRequestHandler<DeleteCityCommandRequest, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _repository;

        public DeleteCityCommandRequestHandler(IMapper mapper,ICityRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<BaseCommandResponse> Handle(DeleteCityCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            await _repository.DeleteAsync(request.Id);
            response.Success = true;
            response.Message = "Delete was successfully";
            return response;
        }
    }
}
