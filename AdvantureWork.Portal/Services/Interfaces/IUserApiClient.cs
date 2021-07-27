using AdvantureWork.Common.DTO;
using AdvantureWork.Common.Request;
using AdvantureWork.Common.ViewModel;
using AdvantureWork.ViewModels.Common;
using System.Threading.Tasks;

namespace AdvantureWork.Portal.Services.Interfaces
{
    public interface IUserApiClient
    {
        Task<DataTableViewModel<AppUserDTO>> GetAllPaging(DataTableRequest request);

        ApiResult<AppUserDTO> Create(AppUserRequest viewModel);

        ApiResult<AppUserDTO> Update(AppUserRequest viewModel);

        ApiResult<bool> ChangePassword(AppUserDTO usermodel);

        ApiResult<AppUserDTO> GetById(AppUserRequest request);

        ApiResult<bool> Delete(AppUserRequest request);
    }
}