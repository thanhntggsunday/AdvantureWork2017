using AdvantureWork.Common.DTO;
using AdvantureWork.Common.Request;
using AdvantureWork.Common.ViewModel;
using AdvantureWork.ViewModels.Common;
using System.Threading.Tasks;

namespace AdvantureWork.Portal.Services.Interfaces
{
    public interface IUserRoleApiClient
    {
        Task<DataTableViewModel<AppUserRolesDTO>> GetAllUserRolesPaging(DataTableRequest request);

        Task<DataTableViewModel<AppUserDTO>> GetJsonAllUser();

        Task<DataTableViewModel<AppRoleDTO>> GetJsonAllRole();

        Task<DataTableViewModel<AppRoleDTO>> GetJsonAllRoleOfUserByUserId(string userId);

        Task<AppUserRoleAssignViewModel<AppUserRolesDTO>> AssignUserRole(AppUserRoleAssignViewModel<AppUserRolesDTO> viewModel);

        Task<AppUserRoleAssignViewModel<AppUserRolesDTO>> Delete(AppUserRoleAssignViewModel<AppUserRolesDTO> viewModel);

        Task<ApiResult<AppUserDTO>> GetById(string Id);
    }
}