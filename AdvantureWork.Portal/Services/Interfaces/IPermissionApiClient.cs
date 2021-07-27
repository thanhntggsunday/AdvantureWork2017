using AdvantureWork.Common.DTO;
using AdvantureWork.Common.Request;
using AdvantureWork.Common.ViewModel;
using AdvantureWork.Common.ViewModel.System.Permissions;
using AdvantureWork.Model.DTO;

namespace AdvantureWork.Portal.Services.Interfaces
{
    public interface IPermissionApiClient
    {
        DataTableViewModel<AppAllUserPermissionDTO> GetAllUserPermissionsByUserId(string userId);

        DataTableViewModel<AppPermissionDTO> GetAllPaging(DataTableRequest request);

        DataTableViewModel<AppRoleDTO> GetAllRoles();

        DataTableViewModel<AppFunctionDTO> GetAllFunctions();

        DataTableViewModel<AppLevelPermissionDTO> GetAllLevelPermissios();

        PermissionViewModel AssignPermissionToRole(PermissionViewModel viewModel);

        DataTableViewModel<AppLevelPermissionDTO> GetActionsByFunctionId(string functionId);
    }
}