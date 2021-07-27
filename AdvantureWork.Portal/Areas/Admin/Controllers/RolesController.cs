namespace AdvantureWork.Portal.Areas.Admin.Controllers
{
    using AdvantureWork.Common.Constant;
    using AdvantureWork.Common.DTO;
    using AdvantureWork.Common.Request;
    using AdvantureWork.Common.ViewModel;
    using AdvantureWork.Portal.Classes;
    using AdvantureWork.Portal.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class RolesController : AminBaseController
    {
        private IRoleApiClient _roleApiClient;

        public RolesController(IRoleApiClient roleApiClient)
        {
            _roleApiClient = roleApiClient;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllPaging()
        {
            var result = new DataTableViewModel<AppRoleDTO>();
            // Request.Query["oauth_verifier"]
            var draw = Request.Query["draw"].FirstOrDefault();
            var start = Request.Query["start"].FirstOrDefault();
            var length = Request.Query["length"].FirstOrDefault();
            var search = Request.Query["search[value]"].FirstOrDefault();

            var request = new DataTableRequest();

            request.Draw = draw;
            request.Length = length;
            request.Search = search;
            request.Start = start;

            result = _roleApiClient.GetAllPaging(request).GetAwaiter().GetResult();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(RoleRequest request)
        {
            var result = _roleApiClient.Create(request);

            return Ok(result);
        }


        [AdminAuthorizePermission(Function = FunctionConstants.ROLE, Action = LevelPermissionConstants.EDIT)]
        [HttpPost]
        public IActionResult Edit(RoleRequest request)
        {
            var result = _roleApiClient.Edit(request);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetById(RoleRequest request)
        {
            var result = _roleApiClient.GetById(request);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult Delete(RoleRequest request)
        {
            var result = _roleApiClient.Delete(request);

            return Ok(result);
        }
    }
}