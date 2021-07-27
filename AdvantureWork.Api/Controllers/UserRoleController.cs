using AdvantureWork.BusinessService.Interface;
using AdvantureWork.Common.DTO;
using AdvantureWork.Common.Request;
using AdvantureWork.Common.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvantureWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userService;

        public UserRoleController(IUserRoleService userService)
        {
            _userService = userService;
        }

        [HttpPost("GetAllUserRolesPaging")]
        public ActionResult GetAllUserRolesPaging(DataTableRequest request)
        {
            var result = _userService.GetAllPaging(request).GetAwaiter().GetResult();
            _userService.Dispose();

            return Ok(result);
        }

        [HttpPost("GetJsonAllUser")]
        public ActionResult GetJsonAllUser()
        {
            var result = _userService.GetJsonAllUser();
            _userService.Dispose();

            return Ok(result);
        }

        [HttpPost("GetJsonAllRole")]
        public ActionResult GetJsonAllRole()
        {
            var result = _userService.GetJsonAllRole();
            _userService.Dispose();

            return Ok(result);
        }

        [HttpPost("GetJsonAllRoleOfUserByUserId")]
        public ActionResult GetJsonAllRoleOfUserByUserId([FromBody] string uid)
        {
            var result = _userService.GetJsonAllRoleOfUserByUserId(uid);
            _userService.Dispose();

            return Ok(result);
        }

        [HttpPost("AssignUserRole")]
        public ActionResult AssignUserRole(AppUserRoleAssignViewModel<AppUserRolesDTO> vm)
        {
            var result = _userService.AssignUserRole(vm);
            _userService.Dispose();

            return Ok(result);
        }

        [HttpPost("Delete")]
        public ActionResult Delete(AppUserRoleAssignViewModel<AppUserRolesDTO> vm)
        {
            var result = _userService.Delete(vm);
            _userService.Dispose();

            return Ok(result);
        }

        [HttpPost("GetById")]
        public ActionResult GetById([FromBody] string id)
        {
            var result = _userService.GetById(id);
            _userService.Dispose();

            return Ok(result);
        }
    }
}