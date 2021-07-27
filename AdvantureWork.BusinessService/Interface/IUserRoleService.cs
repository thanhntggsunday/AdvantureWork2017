using AdvantureWork.Common.DTO;
using AdvantureWork.Common.Request;
using AdvantureWork.Common.ViewModel;
using AdvantureWork.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvantureWork.BusinessService.Interface
{
    public interface IUserRoleService
    {
        Task<DataTableViewModel<AppUserRolesDTO>> GetAllPaging(DataTableRequest request);
        DataTableViewModel<AppUserDTO> GetJsonAllUser();
        DataTableViewModel<AppRoleDTO> GetJsonAllRole();
        DataTableViewModel<AppRoleDTO> GetJsonAllRoleOfUserByUserId(string userId);
        AppUserRoleAssignViewModel<AppUserRolesDTO> AssignUserRole(AppUserRoleAssignViewModel<AppUserRolesDTO> viewModel);

        AppUserRoleAssignViewModel<AppUserRolesDTO> Delete(AppUserRoleAssignViewModel<AppUserRolesDTO> viewModel);

        ApiResult<AppUserDTO> GetById(string Id);

        void Dispose();
    }
}
