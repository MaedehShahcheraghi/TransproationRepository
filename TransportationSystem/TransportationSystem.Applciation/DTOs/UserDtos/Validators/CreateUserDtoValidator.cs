using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence.UserRepository;

namespace TransportationSystem.Applciation.DTOs.UserDtos.Validators
{
    public class CreateUserDtoValidator
  : AbstractValidator<CreateUserDto>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserDtoValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            Include(new UserBaseValidator(_userRepository));
       
        }
    }
}
