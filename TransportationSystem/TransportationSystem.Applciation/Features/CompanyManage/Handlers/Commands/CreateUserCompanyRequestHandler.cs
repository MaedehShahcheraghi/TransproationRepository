using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence.CompanyRepository;
using TransportationSystem.Applciation.Contracts.Persistence.RoleRepository;
using TransportationSystem.Applciation.Contracts.Persistence.UserRepositories;
using TransportationSystem.Applciation.Contracts.Persistence.UserRepository;
using TransportationSystem.Applciation.DTOs.UserDtos.Validators;
using TransportationSystem.Applciation.DTOs.UserDtos;
using TransportationSystem.Applciation.Features.CompanyManage.Requests.Commands;
using TransportationSystem.Applciation.Responses.BaseResponse;
using TransportationSystem.Domain.Entities.UserEntities;
using TransportationSystem.Applciation.DTOs.CompanyDtos;
using TransportationSystem.Applciation.DTOs.CompanyDtos.Validators;
using AutoMapper;
using TransportationSystem.Domain.Entities.TransportCompanyEntities;

namespace TransportationSystem.Applciation.Features.CompanyManage.Handlers.Commands
{
    public class CreateUserCompanyRequestHandler : IRequestHandler<CreateUserCompanyRequest, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserCompanyRepository _userCompanyRepository;

        public CreateUserCompanyRequestHandler(IMapper mapper,IUserRepository userRepository,ICompanyRepository companyRepository,IUserCompanyRepository userCompanyRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _userCompanyRepository = userCompanyRepository;
        }
        public async Task<BaseCommandResponse> Handle(CreateUserCompanyRequest request, CancellationToken cancellationToken)
        {
            var response=new BaseCommandResponse();
            var userCompanies = new List<AddUserCompaniesDto>();
            foreach (var userid in request.UserCompanyDto.UsersId)
            {
                var addUserCompaniesDto = new AddUserCompaniesDto()
                {
                    CompanyId = request.UserCompanyDto.CompanyId,
                    UserId = userid
                };

                var validate = await new AddUserCompaniesValidator(_userRepository, _companyRepository).ValidateAsync(addUserCompaniesDto);
                if (!validate.IsValid)
                {
                    response.ErrorMessages.AddRange(validate.Errors.Select(x => x.ErrorMessage).ToList());
                }
                else
                {
                    userCompanies.Add(addUserCompaniesDto);
                }

            }
            if (userCompanies.Count > 0)
            {
                var data = _mapper.Map<ICollection<UserCompany>>(userCompanies);
                await _userCompanyRepository.AddRangeAsync(data);
                response.Success = true;
                response.Message = "creation UserCompany successfully";
            }
            else
            {
                response.Success = false;
                response.Message = "creation UserCompany failed";
            }
            return response;
        }
    }
}
