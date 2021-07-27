using AdvantureWork.BusinessService.ADO.ServiceImp;
using AdvantureWork.BusinessService.Interface;
using AdvantureWork.Common.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdvantureWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("GetAllPaging")]
        [HttpPost]
        public async Task<ActionResult> GetAllPaging([FromBody] DataTableRequest request)
        {
            var result = await _userService.GetAllPaging(request);
            _userService.Dispose();

            return Ok(result);
        }

        [Route("Create")]
        [HttpPost]
        public ActionResult Create(AppUserRequest request)
        {
            var result = _userService.Create(request);
            _userService.Dispose();

            return Ok(result);
        }

        [Route("Edit")]
        [HttpPost]
        public ActionResult Edit(AppUserRequest request)
        {
            var result = _userService.Update(request);
            _userService.Dispose();

            return Ok(result);
        }

        [Route("Delete")]
        [HttpPost]
        public ActionResult Delete(AppUserRequest request)
        {
            var result = _userService.Delete(request);
            _userService.Dispose();

            return Ok(result);
        }

        [Route("GetById")]
        [HttpPost]
        public ActionResult GetById(AppUserRequest request)
        {
            var result = _userService.GetById(request);
            _userService.Dispose();

            return Ok(result);
        }

        [Route("GetUserPermissions")]
        [HttpPost]
        public ActionResult GetUserPermissions(AppUserRequest request)
        {
            var service = new PermissionBusinessService();
            var result = service.GetAllUserPermissionsByUserId(request.Id.ToString());
            service.Dispose();

            return Ok(result);
        }
    }
}