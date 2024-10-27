using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence.CompanyRepository;
using TransportationSystem.Applciation.DTOs.CityDTOS.Validators;
using TransportationSystem.Applciation.DTOs.CompanyDtos.Validators;
using TransportationSystem.Applciation.Features.CompanyManage.Requests.Commands;
using TransportationSystem.Applciation.Features.CompanyManage.Requests.Queries;
using TransportationSystem.Applciation.Responses.BaseResponse;
using TransportationSystem.Domain.Entities.Citites;
using TransportationSystem.Domain.Entities.TransportCompanyEntities;

namespace TransportationSystem.Applciation.Features.CompanyManage.Handlers.Commands
{
    public class CreateCompanyRequestHandler : IRequestHandler<CreateCompanyRequest, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;


        public CreateCompanyRequestHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;

        }
        public async Task<BaseCommandResponse> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var valiations = await new CreateCompanyValidator(_companyRepository).ValidateAsync(request.createCompanyDto);
            if (!valiations.IsValid)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.ErrorMessages = valiations.Errors.Select(c => c.ErrorMessage).ToList();
            }
            else
            {
                var data = _mapper.Map<TransportCompany>(request.createCompanyDto);
                await _companyRepository.AddAsync(data);
                response.Success = true;
                response.Message = "Creation SuccessFully";
                response.Id = data.Id;

            }
            return response;
        }
    }
}
