using AdvantureWork.Common.DTO;
using AdvantureWork.Common.Request;
using AdvantureWork.Common.ViewModel;
using AdvantureWork.ViewModels.Common;
using System;
using System.Threading.Tasks;

namespace AdvantureWork.BusinessService.Interface
{
    public interface IAccountService
    {
        Task<ApiResult<string>> Authencate(LoginRequest request);

        Task<ApiResult<bool>> Register(RegisterRequest request);
      

        void Dispose();
    }
}