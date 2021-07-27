using AdvantureWork.BusinessService.Interface;
using AdvantureWork.Common.DTO;
using AdvantureWork.Common.Request;
using AdvantureWork.Common.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdvantureWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [Route("GetAllPaging")]
        [HttpPost]
        public async Task<IActionResult> GetAllPaging([FromBody] DataTableRequest request)
        {
            var result = new DataTableViewModel<AppRoleDTO>();

            var products = await _roleService.GetAllPaging(request);
            _roleService.Dispose();

            return Ok(products);
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult Create([FromBody] RoleRequest request)
        {
            var result = _roleService.Create(request);
            _roleService.Dispose();

            return Ok(result);
        }

        [Route("Edit")]
        [HttpPost]
        public IActionResult Edit([FromBody] RoleRequest request)
        {
            var result = _roleService.Update(request);
            _roleService.Dispose();

            return Ok(result);
        }

        [Route("GetById")]
        [HttpPost]
        public IActionResult GetById(RoleRequest request)
        {
            var result = _roleService.GetById(request);
            _roleService.Dispose();

            return Ok(result);
        }

        [Route("Delete")]
        [HttpPost]
        public IActionResult Delete(RoleRequest request)
        {
            var result = _roleService.Delete(request);
            _roleService.Dispose();

            return Ok(result);
        }
    }
}