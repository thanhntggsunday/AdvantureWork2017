using AdvantureWork.BusinessService.Interface;
using AdvantureWork.Common.Constant;
using AdvantureWork.Common.DTO;
using AdvantureWork.Common.Helper;
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
    public class UserRoleService : BaseClass, IUserRoleService
    {
        private readonly UserManager<AppUser> _userManager;      
        private readonly RoleManager<AppRole> _roleManager;
      
       
        public UserRoleService(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager,
            IConfiguration config)
        {
            _userManager = userManager;         
            _roleManager = roleManager;
           
        }

        public async Task<DataTableViewModel<AppUserRolesDTO>> GetAllPaging(DataTableRequest request)
        {
            var result = new DataTableViewModel<AppUserRolesDTO>();
            try
            {
                AdventureWorksDW2017Context _context = new AdventureWorksDW2017Context();
                int pageSize = Convert.ToInt32(request.Length);
                int startIndex = Convert.ToInt32(request.Start);
                int intDraw = Convert.ToInt32(request.Draw);
                int endIndex = startIndex + pageSize - 1;

                var query = from user in _context.Users
                            join user_role in _context.UserRoles on user.Id equals user_role.UserId
                            join role in _context.Roles on user_role.RoleId equals role.Id
                            select new AppUserRolesDTO
                            {
                                UserId = user.Id,
                                Email = user.Email,
                                UserName = user.UserName,
                                RoleName = role.Name
                            };

                result.data = await query.Where(o => o.RoleName.Contains(request.Search) || o.Email.Contains(request.Search))
                                .OrderBy(o => o.UserId).Skip(startIndex).Take(pageSize).ToArrayAsync();
                result.draw = intDraw;
                result.recordsFiltered = query.Where(o => o.RoleName.Contains(request.Search) || o.Email.Contains(request.Search)).Count();
                result.recordsTotal = query.Where(o => o.RoleName.Contains(request.Search) || o.Email.Contains(request.Search)).Count();

                _context.Dispose();

                return result;
            }
            catch (System.Exception ex)
            {
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;
                Console.WriteLine(ex.Message);

                return result;
            }
        }

        public DataTableViewModel<AppUserDTO> GetJsonAllUser()
        {
            var result = new DataTableViewModel<AppUserDTO>();

            try
            {
                AdventureWorksDW2017Context _context = new AdventureWorksDW2017Context();
                var query = from user in _context.Users
                            select new AppUserDTO
                            {
                                Id = user.Id,
                                Address = user.Address,
                                Avatar = user.Avatar,
                                BirthDay = user.BirthDay,
                                Email = user.Email,
                                FullName = user.FullName,
                                Gender = user.Gender,
                                PhoneNumber = user.PhoneNumber,
                                Status = user.Status,
                                UserName = user.UserName
                            };

                result.data = query.ToArray();
                result.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);
                result.ReturnStatus = true;

                _context.Dispose();

                return result;
            }
            catch (Exception ex)
            {
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;
                Console.WriteLine(ex.Message);

                return result;
            }
        }

        public DataTableViewModel<AppRoleDTO> GetJsonAllRole()
        {
            var result = new DataTableViewModel<AppRoleDTO>();

            try
            {
                AdventureWorksDW2017Context _context = new AdventureWorksDW2017Context();
                var query = from role in _context.Roles
                            select new AppRoleDTO
                            {
                                Id = role.Id,
                                Name = role.Name,
                                Description = role.Description
                            };

                result.data = query.ToArray();
                result.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);
                result.ReturnStatus = true;

                _context.Dispose();
                return result;
            }
            catch (Exception ex)
            {
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;
                Console.WriteLine(ex.Message);

                return result;
            }
        }

        public DataTableViewModel<AppRoleDTO> GetJsonAllRoleOfUserByUserId(string userId)
        {
            var result = new DataTableViewModel<AppRoleDTO>();
            Guid guidUid = Guid.Parse(userId);

            try
            {
                AdventureWorksDW2017Context _context = new AdventureWorksDW2017Context();
                var query = from role in _context.Roles
                            join user_role in _context.UserRoles on role.Id equals user_role.RoleId
                            where user_role.UserId == guidUid
                            select new AppRoleDTO
                            {
                                Id = role.Id,
                                Name = role.Name,
                                Description = role.Description
                            };

                result.data = query.ToArray();
                result.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);
                result.ReturnStatus = true;

                _context.Dispose();
                return result;
            }
            catch (Exception ex)
            {
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;
                Console.WriteLine(ex.Message);

                return result;
            }
        }

        public AppUserRoleAssignViewModel<AppUserRolesDTO> AssignUserRole(AppUserRoleAssignViewModel<AppUserRolesDTO> viewModel)
        {
            try
            {
                if (viewModel == null)
                {
                    viewModel = new AppUserRoleAssignViewModel<AppUserRolesDTO>();
                    viewModel.ReturnStatus = false;
                    viewModel.ReturnMessage.Add("Error view model is null");

                    return viewModel;
                }
                else
                {
                    AdventureWorksDW2017Context _context = new AdventureWorksDW2017Context();
                    var arrUserIds = viewModel.UserIds.Split(';');
                    var arrRoleNames = viewModel.RoleNames.Split(';');

                    for (int uix = 0; uix < arrUserIds.Length; uix++)
                    {
                        var userid = arrUserIds[uix];
                        var appUser = _userManager.FindByIdAsync(userid).GetAwaiter().GetResult();

                        var query = from user in _context.Users
                                    join user_role in _context.UserRoles on user.Id equals user_role.UserId
                                    join role in _context.Roles on user_role.RoleId equals role.Id
                                    where user.Id == Guid.Parse(userid)
                                    select new AppUserRolesDTO
                                    {
                                        UserId = user.Id,
                                        Email = user.Email,
                                        UserName = user.UserName,
                                        RoleName = role.Name,
                                        RoleId = role.Id
                                    };
                        var userRoles = query.ToArray();

                        // Clear user-roles for assign:
                        for (int i = 0; i < userRoles.Length; i++)
                        {
                            _userManager.RemoveFromRoleAsync(appUser, userRoles[i].RoleName).GetAwaiter().GetResult();
                        }

                        // Test:
                        var roles = _roleManager.Roles.ToArray();

                        // Assig user to role
                        for (int rix = 0; rix < arrRoleNames.Length; rix++)
                        {
                            var roleId = arrRoleNames[rix].Trim();
                            _userManager.AddToRoleAsync(appUser, roleId).GetAwaiter().GetResult();
                        }
                    }

                    viewModel.ReturnStatus = true;
                    viewModel.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);

                    _context.Dispose();
                    return viewModel;
                }
            }
            catch (Exception ex)
            {
                viewModel.ReturnMessage.Add(ex.Message);
                viewModel.ReturnStatus = false;
                Console.WriteLine(ex.Message);

                return viewModel;
            }
        }

        public AppUserRoleAssignViewModel<AppUserRolesDTO> Delete(AppUserRoleAssignViewModel<AppUserRolesDTO> viewModel)
        {
            try
            {
                var arrUserIds = viewModel.UserIds.Split(';');
                var arrRoleNames = viewModel.RoleNames.Split(';');

                for (int uix = 0; uix < arrUserIds.Length; uix++)
                {
                    var userid = arrUserIds[uix];
                    var appUser = _userManager.FindByIdAsync(userid).GetAwaiter().GetResult();

                    // Clear user-roles for assign:
                    for (int i = 0; i < arrRoleNames.Length; i++)
                    {
                        _userManager.RemoveFromRoleAsync(appUser, arrRoleNames[i]).GetAwaiter().GetResult();
                    }
                }

                viewModel.ReturnStatus = true;
                viewModel.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);

                return viewModel;
            }
            catch (Exception ex)
            {
                viewModel.ReturnMessage.Add(ex.Message);
                viewModel.ReturnStatus = false;
                Console.WriteLine(ex.Message);

                return viewModel;
            }
        }

        public ApiResult<AppUserDTO> GetById(string Id)
        {
            var result = new ApiResult<AppUserDTO>();
            try
            {
                AdventureWorksDW2017Context _context = new AdventureWorksDW2017Context();
                var guidUserId = Guid.Parse(Id);
                var query = from u in _context.Users
                            select new AppUserDTO
                            {
                                Id = u.Id,
                                Email = u.Email,
                                UserName = u.UserName
                            };
                var user = query.Where(o => o.Id == guidUserId).FirstOrDefault();

                result.ResultObj = user;
                result.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);
                result.ReturnStatus = false;

                _context.Dispose();
                return result;
            }
            catch (Exception ex)
            {
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;
                Console.WriteLine(ex.Message);

                return result;
            }
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
    }
}