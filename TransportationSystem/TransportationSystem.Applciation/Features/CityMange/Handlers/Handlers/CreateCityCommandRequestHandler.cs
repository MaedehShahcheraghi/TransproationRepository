using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence.CityRepository;
using TransportationSystem.Applciation.DTOs.CityDTOS;
using TransportationSystem.Applciation.DTOs.CityDTOS.Validators;
using TransportationSystem.Applciation.Features.CityMange.Requests.Commsnds;
using TransportationSystem.Applciation.Responses.BaseResponse;
using TransportationSystem.Domain.Entities.Citites;

namespace TransportationSystem.Applciation.Features.CityMange.Handlers.Handlers
{
    public class CreateCityCommandRequestHandler : IRequestHandler<CreateCityCommandRequest, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _repository;

        public CreateCityCommandRequestHandler(IMapper mapper, ICityRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<BaseCommandResponse> Handle(CreateCityCommandRequest request, CancellationToken cancellationToken)
        {
            var response=new BaseCommandResponse();
            var valiations = await new CreateCityValidator().ValidateAsync(request.CityDto);
            if (!valiations.IsValid)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.ErrorMessages = valiations.Errors.Select(c => c.ErrorMessage).ToList();
            }
            else {
                var data = _mapper.Map<City>(request.CityDto);
                await _repository.AddAsync(data);
                response.Success = true;
                response.Message = "Creation SuccessFully";
                response.Id=data.Id;
            
            }
            return response;
        }
    }
}
