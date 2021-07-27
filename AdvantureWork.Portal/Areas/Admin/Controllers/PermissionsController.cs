using AdvantureWork.Common.Request;
using AdvantureWork.Common.ViewModel.System.Permissions;
using AdvantureWork.Portal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvantureWork.Portal.Areas.Admin.Controllers
{
    public class PermissionsController : AminBaseController
    {
        private readonly IPermissionApiClient _permissionApiClient;

        public PermissionsController(IPermissionApiClient permissionApiClient)
        {
            _permissionApiClient = permissionApiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetJsonPermissionAllPaging(DataTableRequest request)
        {
            var data = _permissionApiClient.GetAllPaging(request);

            return Ok(data);
        }

        public ActionResult GetAllRoles()
        {
            var data = _permissionApiClient.GetAllRoles();

            return Ok(data);
        }

        public ActionResult GetAllFunctions()
        {
            var data = _permissionApiClient.GetAllFunctions();

            return Ok(data);
        }


        public ActionResult GetAllLevelPermissions()
        {
            var data = _permissionApiClient.GetAllLevelPermissios();

            return Ok(data);
        }

        public ActionResult AssignPermissionToRole([FromBody] PermissionViewModel viewModel)
        {
            var data = _permissionApiClient.AssignPermissionToRole(viewModel);

            return Ok(data);
        }


        public ActionResult GetActionsByFunctionId(string functionId)
        {
            var data = _permissionApiClient.GetActionsByFunctionId(functionId);

            return Ok(data);
        }


    }
}