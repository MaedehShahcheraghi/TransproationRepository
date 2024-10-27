using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Constants;
using TransportationSystem.Applciation.Contracts.Infrrastructure.Services;
using TransportationSystem.Applciation.Contracts.Persistence.UserRepository;
using TransportationSystem.Applciation.Models.User_Model;
using TransportationSystem.Applciation.Responses.UserResponse;
using TransportationSystem.Applciation.Utilites.Generator;
using TransportationSystem.Domain.Entities.UserEntity;

namespace TransportationSystem.Infrastructure.Services
{
    public class AuthService : IAuthenticationService
    {

        private readonly JWTSetting _options;
        private readonly IUserRepository _userRepository;

        public AuthService(IOptions<JWTSetting> options, IUserRepository userRepository)
        {

            _options = options.Value;
            _userRepository = userRepository;
        }
        public async Task<AuthResponse> Login(AuthRequest request)
        {
            try
            {
                var authresponse=new AuthResponse();
                var user=await _userRepository.GetUserforLogin(request.UserName,request.Password,null);
                if (user == null)
                {
                    authresponse.Success = false;
                    authresponse.Message = "UserNotFound";
                }else if (!user.IsActive)
                {
                    authresponse.Success = false;
                    authresponse.Message = "UserIsNotActive";
                }
                else {

                   
                   var jwtToken=await GenerateToken(user);
                    authresponse.Success = true;
                    authresponse.Token=new JwtSecurityTokenHandler().WriteToken(jwtToken);
                    authresponse.Message = "CrationSuccessfully";

                }
                return authresponse;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<RegisterationResponse> Register(RegisterationRequest request,int role=0)
        {
            try
            {
                var registerresponse = new RegisterationResponse();
                if (request.National_Code != null && await _userRepository.UserExistByNationalcodeAsync(request.National_Code))
                {
                    registerresponse.Success=false;
                    registerresponse.ErrorMessage.Add("you cant add user with nationalcode");
                }
                if (await _userRepository.UserExistByUserNameAsync(request.UserName) && await _userRepository.UserExistByPhoneNumberAsync(request.Phone))
                {
                    registerresponse.Success = false;
                    registerresponse.ErrorMessage.Add("you cant add user ewith username and password");
                }
                var user = new User()
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    Password = request.Password,
                    Phone = request.Phone,
                    National_Code = request.National_Code,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    AcivationEmail = NameGenerator.GenerateUnicCode(),
                    IsActive = false,
                    AcivationPhone = new Random().Next(10000, 99999).ToString()
                };
                user = await  _userRepository.AddAsync(user);
                if (role != 0) {
                    await _userRepository.AddRoleForUserAsync(user.Id, new List<int>() { role });
                }
                else
                {
                    await _userRepository.AddRoleForUserAsync(user.Id, new List<int>() { 3 });
                }
              

                //ToDo Send Activiation Code
                registerresponse.UserId = user.Id;
                registerresponse.Success = true;
                registerresponse.Message = "Creation Successfull";
                return registerresponse;

            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
        }

        #region Utilites
        private async Task<JwtSecurityToken> GenerateToken(User user)
        {


            var claims = new[]
            {
               new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(CustomClaimTypes.UName,user.UserName),
                new Claim(CustomClaimTypes.UEmail,user.UserName),
                new Claim(CustomClaimTypes.UId,user.Id.ToString()),
                new Claim(CustomClaimTypes.UFullName,(user.FirstName+" "+user.LastName).ToString())

            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
            var signinCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var JwtSecurityToken = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_options.DurationInMinutes),
                signingCredentials: signinCredentials
                );
            return JwtSecurityToken;

        }
        #endregion
    }

}
