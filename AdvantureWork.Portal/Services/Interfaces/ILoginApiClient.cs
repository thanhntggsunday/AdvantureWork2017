using AdvantureWork.Common.Request;
using AdvantureWork.ViewModels.Common;
using System.Threading.Tasks;

namespace AdvantureWork.Portal.Services.Interfaces
{
    public interface ILoginApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);

        Task<ApiResult<bool>> Register(RegisterRequest request);
    }
}