using AdvantureWork.Common.DTO;
using AdvantureWork.Common.ViewModel;
using AdvantureWork.Portal.Services;

namespace AdvantureWork.Portal.Classes
{
    public class PermissionHandle
    {
        private AuthorizeApiClient permissionBusinessService = new AuthorizeApiClient();

        public DataTableViewModel<AppAllUserPermissionDTO> GetAllUserPermissionByUserId(string uid)
        {            
            var lstUserPers = permissionBusinessService.GetItemsById<string>(uid);
            return lstUserPers;
        }
    }
}