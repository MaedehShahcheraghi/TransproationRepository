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
    public class EditCityCommandRequestHandler : IRequestHandler<EditCityCommandRequest, BaseCommandResponse>
    {
        private readonly ICityRepository _repository;
        private readonly IMapper _mapper;

        public EditCityCommandRequestHandler(ICityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(EditCityCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validation = await new EditCityValidator().ValidateAsync(request.EditCity);
            if (validation.IsValid)
            {
                var data=await _repository.GetByIdAsync(request.EditCity.Id);
                if (data != null)
                {
                    var mapdata = _mapper.Map(request.EditCity, data);
                    await _repository.UpdateAsync(mapdata);
                    response.Success = true;
                    response.Message = "Edit was SuccessFully";
                    response.Id = request.EditCity.Id;
                }
                else
                {
                    response.Success = false;
                    response.Message = "the city wasnt found";
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Edit wasn`t SuccessFully";
            }
            return response;

        }
    }
}
