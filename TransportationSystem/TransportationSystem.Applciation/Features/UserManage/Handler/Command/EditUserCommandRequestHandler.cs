using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence.UserRepository;
using TransportationSystem.Applciation.DTOs.UserDtos.Validators;
using TransportationSystem.Applciation.Features.UserManage.Request.Command;
using TransportationSystem.Applciation.Responses.BaseResponse;

namespace TransportationSystem.Applciation.Features.UserManage.Handler.Command
{
    public class EditUserCommandRequestHandler : IRequestHandler<EditUserCommandRequest, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public EditUserCommandRequestHandler(IMapper mapper,IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<BaseCommandResponse> Handle(EditUserCommandRequest request, CancellationToken cancellationToken)
        {
          
            var response= new BaseCommandResponse();
            var validationresult = await new EditUserDtoValidator(_userRepository).ValidateAsync(request.EditUser);
            if (validationresult.IsValid)
            {
                var data = await _userRepository.GetByIdAsync(request.EditUser.Id);
                if (data != null)
                {
                    var mapdata = _mapper.Map(request.EditUser, data);
                    await _userRepository.UpdateAsync(mapdata);
                    response.Success = true;
                    response.Message = "Edit was SuccessFully";
                    response.Id = request.EditUser.Id;
                }
                else
                {
                    response.Success = false;
                    response.Message = "the User wasnt found";
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
