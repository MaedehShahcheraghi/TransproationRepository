using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence.CompanyRepository;
using TransportationSystem.Applciation.DTOs.CompanyDtos.Validators;
using TransportationSystem.Applciation.Features.CompanyManage.Requests.Commands;
using TransportationSystem.Applciation.Responses.BaseResponse;

namespace TransportationSystem.Applciation.Features.CompanyManage.Handlers.Commands
{
    public class EditCompanyRequestHandler : IRequestHandler<EditCompanyRequest, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;


        public EditCompanyRequestHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;

        }
        public async Task<BaseCommandResponse> Handle(EditCompanyRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var valiations = await new EditCompanyValidator(_companyRepository).ValidateAsync(request.EditCompanyDto);
            if (valiations.IsValid)
            {
                var data = await _companyRepository.GetByIdAsync(request.EditCompanyDto.Id);
                if (data != null)
                {
                    var mapdata = _mapper.Map(request.EditCompanyDto, data);
                    await _companyRepository.UpdateAsync(mapdata);
                    response.Success = true;
                    response.Message = "Edit was SuccessFully";
                    response.Id = request.EditCompanyDto.Id;
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
