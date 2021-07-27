using AdvantureWork.Common.DTO;
using AdvantureWork.Common.Request;
using AdvantureWork.Common.ViewModel;
using AdvantureWork.ViewModels.Common;
using System.Threading.Tasks;

namespace AdvantureWork.BusinessService.Interface
{
    public interface IRoleService
    {
        Task<DataTableViewModel<AppRoleDTO>> GetAllPaging(DataTableRequest request);

        ApiResult<bool> Create(RoleRequest request);

        ApiResult<bool> Update(RoleRequest request);

        ApiResult<AppRoleDTO> GetById(RoleRequest request);

        ApiResult<bool> Delete(RoleRequest request);

        DataTableViewModel<AppRoleDTO> GetAll();

        void Dispose();
    }
}