using Application.Common;
using Application.Enums;
using Application.Interfaces.Repositories.General;
using Application.Interfaces.Repositories.General.Auth;
using Application.Interfaces.Services.General;
using Application.Resources;
using AutoMapper;
using Domain.Common;
using Domain.Dto.General.Auth;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockerZone.Application.Services.Auth
{

    public class UserService : ServiceBase, IUserService
    {
        private readonly IMapper _Mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IEmailSender _emailSender;
        //private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IAppUserRepository _appUserRepository;

        public UserService(

            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            IUnitOfWork unitOfWork
            , RoleManager<ApplicationRole> roleManager,
            IAppUserRepository appUserRepository
            )
        {
            _Mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _appUserRepository = appUserRepository;
        }

        public async Task<ServiceResponse<TokenDto>> Token(LoginDto loginDto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(loginDto.Email) || string.IsNullOrWhiteSpace(loginDto.Password))
                    return new ServiceResponse<TokenDto> { Success = false, Data = null, Message = "user name or password is null" };

                var token = await _appUserRepository.
                    GetToken(loginDto.Email, loginDto.Password, "FostaSuperSecretPassword", "Fosta.com", "Fosta.com");
                if (token == null)
                    return new ServiceResponse<TokenDto> { Success = false, Data = null, Message = "Invaild Login" };
                if (!token.IsActive)
                    return new ServiceResponse<TokenDto> { Success = false, Data = null, Message = "you are not accepted by admin Yet" };

                var tokenModel = _Mapper.Map<TokenDto>(token);

                return new ServiceResponse<TokenDto> { Success = true, Data = tokenModel, Message = "sign in succsessfully" };
            }
            catch (Exception ex)
            {
                return await LogError<TokenDto>(ex, default!);
            }
        }

        public async Task<ServiceResponse<int>> RegisterAccounUser(RegisterDto registerAccountUserDto)
        {
            try
            {
                #region Guard
                var userExists = await _appUserRepository.GetUserByEmail(registerAccountUserDto.Email);
                if (userExists is not null) return new ServiceResponse<int>
                {
                    Success = false,
                    Message = CultureHelper.GetResourceMessage(Resource.ResourceManager, nameof(Resource.UserExsistBefore))
                };
                #endregion
                var user = _Mapper.Map<ApplicationUser>(registerAccountUserDto);
                user.UserName = registerAccountUserDto.Email;

                var result = await _userManager.CreateAsync(user, registerAccountUserDto.Password);
                if (!result.Succeeded) return new ServiceResponse<int>
                {
                    Success = false,
                    Message = CultureHelper.GetResourceMessage(Resource.ResourceManager, nameof(Resource.PleaseTryAgain))
                };
                var isexist = await _roleManager.RoleExistsAsync(UserTypes.PUBLC.ToString());
                if (!isexist)
                {
                    await _roleManager.CreateAsync(
                        new ApplicationRole
                        { Name = UserTypes.PUBLC.ToString() });
                    await _roleManager.CreateAsync(
                       new ApplicationRole
                       { Name = UserTypes.ADMIN.ToString() });

                }
                await _appUserRepository.AddRoleToUser(user, UserTypes.PUBLC.ToString());
                return new ServiceResponse<int>
                {
                    Success = true,
                    Data = 1,
                    Message = CultureHelper.GetResourceMessage(Resource.ResourceManager, nameof(Resource.UserAddedSuccessfully))
                };
            }
            catch (Exception ex)
            {
                return await LogError<int>(ex, 0);
            }
        }
    }

}

