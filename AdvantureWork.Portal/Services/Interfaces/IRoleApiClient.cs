using AdvantureWork.Common.DTO;
using AdvantureWork.Common.Request;
using AdvantureWork.Common.ViewModel;
using AdvantureWork.ViewModels.Common;
using System.Threading.Tasks;

namespace AdvantureWork.Portal.Services.Interfaces
{
    public interface IRoleApiClient
    {
        Task<DataTableViewModel<AppRoleDTO>> GetAllPaging(DataTableRequest request);

        ApiResult<bool> Create(RoleRequest request);

        ApiResult<bool> Edit(RoleRequest request);

        ApiResult<AppRoleDTO> GetById(RoleRequest request);

        ApiResult<bool> Delete(RoleRequest request);
    }
}