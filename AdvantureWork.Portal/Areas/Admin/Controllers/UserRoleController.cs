using AdvantureWork.Common.DTO;
using AdvantureWork.Common.Request;
using AdvantureWork.Common.ViewModel;
using AdvantureWork.Portal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdvantureWork.Portal.Areas.Admin.Controllers
{
    public class UserRoleController : AminBaseController
    {
        private readonly IUserRoleApiClient _userRoleApiClient;

        public UserRoleController(IUserRoleApiClient userRoleApiClient)
        {
            _userRoleApiClient = userRoleApiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetAllUserRolesPaging(DataTableRequest request)
        {
            var result = await _userRoleApiClient.GetAllUserRolesPaging(request);

            return Ok(result);
        }

        public async Task<ActionResult> GetJsonAllUser()
        {
            var result = await _userRoleApiClient.GetJsonAllUser();

            return Ok(result);
        }

        public async Task<ActionResult> GetJsonAllRole()
        {
            var result = await _userRoleApiClient.GetJsonAllRole();

            return Ok(result);
        }

        public async Task<ActionResult> GetJsonAllRoleOfUserByUserId(string userId)
        {
            var result = await _userRoleApiClient.GetJsonAllRoleOfUserByUserId(userId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AssignUserRole([FromBody] AppUserRoleAssignViewModel<AppUserRolesDTO> viewModel)
        {
            var result = await _userRoleApiClient.AssignUserRole(viewModel);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Delete([FromBody] AppUserRoleAssignViewModel<AppUserRolesDTO> viewModel)
        {
            var result = await _userRoleApiClient.Delete(viewModel);

            return Ok(result);
        }

        public async Task<ActionResult> GetById(string Id)
        {
            var result = await _userRoleApiClient.GetById(Id);

            return Ok(result);
        }
    }
}