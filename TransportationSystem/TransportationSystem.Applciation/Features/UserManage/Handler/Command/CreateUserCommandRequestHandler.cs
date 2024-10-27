using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence.UserRepository;
using TransportationSystem.Applciation.DTOs.UserDtos;
using TransportationSystem.Applciation.DTOs.UserDtos.Validators;
using TransportationSystem.Applciation.Features.CityMange.Requests.Commsnds;
using TransportationSystem.Applciation.Features.UserManage.Request.Command;
using TransportationSystem.Applciation.Responses.BaseResponse;
using TransportationSystem.Applciation.Utilites.Generator;
using TransportationSystem.Domain.Entities.UserEntity;

namespace TransportationSystem.Applciation.Features.UserManage.Handler.Command
{
    public class CreateUserCommandRequestHandler : IRequestHandler<CreateUserCommandRequest, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository userRepository;

        public CreateUserCommandRequestHandler(IMapper mapper,IUserRepository userRepository)
        {
            _mapper = mapper;
            this.userRepository = userRepository;
        }
        public async Task<BaseCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validationResult =await  new CreateUserDtoValidator(userRepository).ValidateAsync(request.CreateUser);
            if (!validationResult.IsValid) {
                response.Message = "Creation failed";
                response.ErrorMessages = validationResult.Errors.Select(c => c.ErrorMessage).ToList();
                response.Success = false;
            }
            else { 
                var data=_mapper.Map<User>(request.CreateUser);
                data.IsActive=true;
                data.AcivationEmail = NameGenerator.GenerateUnicCode();
                data.AcivationPhone = new Random().Next(10000, 99999).ToString();
                await userRepository.AddAsync(data);
                response.Success = true;
                response.Id=data.Id;
                response.Message = "Create user successfully";

            
            }
            return response;

        }
    }
}
