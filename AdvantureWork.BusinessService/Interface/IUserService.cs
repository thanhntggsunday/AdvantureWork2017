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
    public interface IUserService
    {
        Task<DataTableViewModel<AppUserDTO>> GetAllPaging(DataTableRequest request);
        ApiResult<AppUserDTO> Create(AppUserRequest viewModel);
        ApiResult<AppUserDTO> Update(AppUserRequest viewModel);

        bool ChangePassword(AppUserDTO usermodel);

        ApiResult<AppUserDTO> GetById(AppUserRequest request);
        ApiResult<bool> Delete(AppUserRequest request);
        void Dispose();

    }
}
