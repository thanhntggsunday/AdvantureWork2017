using AdvantureWork.BusinessService.Class;
using AdvantureWork.BusinessService.Interface;
using AdvantureWork.Common.Constant;
using AdvantureWork.Common.DTO;
using AdvantureWork.Common.Helper;
using AdvantureWork.Common.Provider;
using AdvantureWork.Common.Request;
using AdvantureWork.Common.ViewModel;
using AdvantureWork.Model.Entities;
using AdvantureWork.ViewModels.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvantureWork.BusinessService.ServiceImp
{
    public class UserService : BaseClass, IUserService
    {
        private readonly UserManager<AppUser> _userManager;     
        private readonly RoleManager<AppRole> _roleManager;          
        private readonly ILoggerManager _logger;

        public UserService(UserManager<AppUser> userManager,           
            RoleManager<AppRole> roleManager,          
            ILoggerManager logger)
        {
            _userManager = userManager;          
            _roleManager = roleManager;          
            _logger = logger;
        }

        public new void Dispose()
        {
            if (_roleManager != null)
            {
                _roleManager.Dispose();
            }

            if (_userManager != null)
            {
                _userManager.Dispose();
            }

            base.Dispose();
        }

        public async Task<DataTableViewModel<AppUserDTO>> GetAllPaging(DataTableRequest request)
        {
            var result = new DataTableViewModel<AppUserDTO>();
            try
            {
                AdventureWorksDW2017Context _context = new AdventureWorksDW2017Context();
                int pageSize = Convert.ToInt32(request.Length);
                int startIndex = Convert.ToInt32(request.Start);
                int intDraw = Convert.ToInt32(request.Draw);
                int endIndex = startIndex + pageSize - 1;

                var allUser = _context.Users.AsQueryable()
                    .Where(o => o.Email.Contains(request.Search) || o.FullName.Contains(request.Search) || o.UserName.Contains(request.Search));

                var users = await _context.Users.AsQueryable()
                    .Where(o => o.Email.Contains(request.Search) || o.FullName.Contains(request.Search) || o.UserName.Contains(request.Search))
                    .OrderBy(o => o.Id)
                    .Skip(startIndex).Take(pageSize).ToListAsync();

                var userDTOs = new List<AppUserDTO>();

                foreach (var item in users)
                {
                    var userDto = new AppUserDTO();
                    userDto.CopyFromUserDataModel(item);

                    userDTOs.Add(userDto);
                }

                result.data = userDTOs.ToArray();
                result.draw = intDraw;
                result.recordsFiltered = allUser.AsQueryable().Count();
                result.recordsTotal = allUser.AsQueryable().Count();

                _logger.LogInformation("Logging in UserService - GetAllPaging...");

                _context.Dispose();
                return result;
            }
            catch (System.Exception ex)
            {
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;
                Console.WriteLine(ex.Message);

                _logger.LogError(ex.Message);

                return result;
            }
        }

        public ApiResult<AppUserDTO> Create(AppUserRequest viewModel)
        {
            var response = new ApiResult<AppUserDTO>();
            try
            {
                var user = new AppUser();

                user.CopyFromUserDTO(viewModel);
                user.Id = Guid.NewGuid();

                var result = _userManager.CreateAsync(user, viewModel.Password).GetAwaiter().GetResult();
                if (result.Succeeded)
                {
                    response.ResultObj = viewModel;
                    response.ReturnStatus = true;
                    response.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);

                    if (viewModel.Roles != null)
                    {
                        _userManager.AddToRolesAsync(user, viewModel.Roles.ToArray()).GetAwaiter();
                    }
                }
                else
                {
                    response.ReturnStatus = false;
                    response.ReturnMessage.Add(MessagesConstant.FAIL_MESAGE);
                }
            }
            catch (Exception ex)
            {
                response.ReturnStatus = false;
                response.ReturnMessage.Add(ex.Message);
                Console.WriteLine(ex.Message);
            }

            return response;
        }

        public ApiResult<AppUserDTO> Update(AppUserRequest viewModel)
        {
            var response = new ApiResult<AppUserDTO>();
            try
            {
                var user = _userManager.FindByIdAsync(viewModel.Id.ToString()).GetAwaiter().GetResult();
                user.CopyFromUserDTO(viewModel);

                if (user.PasswordHash != viewModel.Password)
                {
                    ChangePassword(viewModel);
                }

                var result = _userManager.UpdateAsync(user).GetAwaiter().GetResult();
                if (result.Succeeded)
                {
                    response.ResultObj = viewModel;
                    response.ReturnStatus = true;
                    response.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);

                    if (viewModel.Roles != null)
                    {
                        _userManager.AddToRolesAsync(user, viewModel.Roles.ToArray()).GetAwaiter().GetResult();
                    }
                }
                else
                {
                    response.ReturnStatus = false;
                    response.ReturnMessage.Add(MessagesConstant.FAIL_MESAGE);
                }
            }
            catch (Exception ex)
            {
                response.ReturnStatus = false;
                response.ReturnMessage.Add(ex.Message);
                Console.WriteLine(ex.Message);
            }

            return response;
        }

        public bool ChangePassword(AppUserDTO usermodel)
        {
            AppUser user = _userManager.FindByIdAsync(usermodel.Id.ToString()).GetAwaiter().GetResult();
            if (user == null)
            {
                return false;
            }
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, usermodel.Password);
            var result = _userManager.UpdateAsync(user).GetAwaiter().GetResult();
            if (!result.Succeeded)
            {
                return false;
            }
            return true;
        }

        public ApiResult<AppUserDTO> GetById(AppUserRequest request)
        {
            var response = new ApiResult<AppUserDTO>();

            try
            {
                var user = _userManager.FindByIdAsync(request.Id.ToString()).GetAwaiter().GetResult();
                request.CopyFromUserDataModel(user);
                request.Password = request.PasswordHash;

                if (request.BirthDay != null)
                {
                    request.StrBirthDay = request.BirthDay.Value.ToString("yyyy-MM-dd");
                }
                else
                {
                    request.StrBirthDay = DateTime.Now.ToString("yyyy-MM-dd");
                }

                response.ResultObj = request;
                response.ReturnStatus = true;
                response.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);
            }
            catch (Exception ex)
            {
                response.ReturnStatus = false;
                response.ReturnMessage.Add(ex.Message);
                Console.WriteLine(ex.Message);
            }

            return response;
        }

        public ApiResult<bool> Delete(AppUserRequest request)
        {
            var response = new ApiResult<bool>();

            try
            {
                var appUser = _userManager.FindByIdAsync(request.Id.ToString()).GetAwaiter().GetResult();
                var result = _userManager.DeleteAsync(appUser).GetAwaiter().GetResult();

                response.ReturnStatus = true;
                response.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);
            }
            catch (Exception ex)
            {
                response.ReturnStatus = false;
                response.ReturnMessage.Add(ex.Message);
                Console.WriteLine(ex.Message);
            }

            return response;
        }
    }
}