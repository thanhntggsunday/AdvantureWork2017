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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvantureWork.BusinessService.ServiceImp
{
    public class RoleService : BaseClass, IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;       
        private readonly ILoggerManager _logger;

        public RoleService(RoleManager<AppRole> roleManager, ILoggerManager logger)
        {
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task<DataTableViewModel<AppRoleDTO>> GetAllPaging(DataTableRequest request)
        {
            var result = new DataTableViewModel<AppRoleDTO>();
            try
            {
                int pageSize = Convert.ToInt32(request.Length);
                int startIndex = Convert.ToInt32(request.Start);
                int intDraw = Convert.ToInt32(request.Draw);
                int endIndex = startIndex + pageSize - 1;

                var query = _roleManager.Roles.Where(o => o.Name.Contains(request.Search));

                var roles = await query.OrderBy(o => o.Id)
                                 .Skip(startIndex)
                                 .Take(pageSize).ToListAsync();

                var roleDtos = new List<AppRoleDTO>();

                foreach (var item in roles)
                {
                    var roleDto = new AppRoleDTO();
                    roleDto.CopyFromAppRoleDataModel(item);

                    roleDtos.Add(roleDto);
                }

                result.data = roleDtos.ToArray();
                result.draw = intDraw;
                result.recordsFiltered = await query.AsQueryable().CountAsync();
                result.recordsTotal = await query.AsQueryable().CountAsync();

                _logger.LogInformation("Logging in RoleService - GetAllPaging");

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

        public ApiResult<bool> Create(RoleRequest request)
        {
            var result = new ApiResult<bool>();
            try
            {
                AdventureWorksDW2017Context _context = new AdventureWorksDW2017Context();
                var role = new AppRole();
                role.Name = request.Name;
                role.Description = request.Description;

                _context.Roles.Add(role);
                _context.SaveChanges();

                result.ReturnStatus = true;
                result.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);
                result.ResultObj = true;

                _context.Dispose();

                return result;
            }
            catch (System.Exception ex)
            {
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;
                result.ResultObj = false;
                Console.WriteLine(ex.Message);

                return result;
            }
        }

        public ApiResult<bool> Update(RoleRequest request)
        {
            var result = new ApiResult<bool>();
            try
            {
                AdventureWorksDW2017Context _context = new AdventureWorksDW2017Context();
                var role = _context.Roles.Find(request.Id);

                role.Name = request.Name;
                role.Description = request.Description;
                _context.Entry(role).State = EntityState.Modified;
                _context.SaveChanges();

                result.ReturnStatus = true;
                result.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);
                result.ResultObj = true;

                _context.Dispose();

                return result;
            }
            catch (System.Exception ex)
            {
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;
                result.ResultObj = false;
                Console.WriteLine(ex.Message);

                return result;
            }
        }

        public ApiResult<AppRoleDTO> GetById(RoleRequest request)
        {
            var result = new ApiResult<AppRoleDTO>();
            try
            {
                AdventureWorksDW2017Context _context = new AdventureWorksDW2017Context();
                var role = _context.Roles.Find(request.Id);
                var roleDto = new AppRoleDTO();

                roleDto.Id = role.Id;
                roleDto.Name = role.Name;
                roleDto.Description = role.Description;

                result.ResultObj = roleDto;
                result.ReturnStatus = true;
                result.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);

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

        public ApiResult<bool> Delete(RoleRequest request)
        {
            var result = new ApiResult<bool>();
            try
            {
                AdventureWorksDW2017Context _context = new AdventureWorksDW2017Context();
                var role = _context.Roles.Find(request.Id);

                _context.Roles.Remove(role);
                _context.SaveChanges();

                _context.Dispose();

                result.ReturnStatus = true;
                result.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);
                result.ResultObj = true;

                return result;
            }
            catch (System.Exception ex)
            {
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;
                result.ResultObj = false;
                Console.WriteLine(ex.Message);

                return result;
            }
        }

        public DataTableViewModel<AppRoleDTO> GetAll()
        {
            var viewModel = new DataTableViewModel<AppRoleDTO>();
            var items = new List<AppRoleDTO>();

            try
            {
                AdventureWorksDW2017Context _context = new AdventureWorksDW2017Context();
                var roles = _context.Roles.AsQueryable();

                foreach (var item in roles)
                {
                    var roleDto = new AppRoleDTO();
                    roleDto.CopyFromAppRoleDataModel(item);

                    items.Add(roleDto);
                }

                _context.Dispose();

                viewModel.ReturnStatus = true;
                viewModel.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);
                viewModel.data = items.ToArray();
                viewModel.recordsTotal = items.Count();
            }
            catch (Exception ex)
            {
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
                Console.WriteLine(ex.Message);
            }

            return viewModel;
        }

        public new void Dispose()
        {
            if (_roleManager != null)
            {
                _roleManager.Dispose();
            }

           
            base.Dispose();
        }
    }
}