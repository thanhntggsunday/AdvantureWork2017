using AdvantureWork.BusinessService.ADO.ServiceImp;
using AdvantureWork.BusinessService.Interface;
using AdvantureWork.Common.Helper;
using AdvantureWork.Common.Request;
using AdvantureWork.Common.ViewModel.System.Permissions;
using AdvantureWork.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AdvantureWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public PermissionController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        [Route("GetAllUserPermissionByUserId")]
        public IActionResult GetAllUserPermissionByUserId([FromBody] string id)
        {
            var service = new PermissionBusinessService();
            var lstUserPers = service.GetAllUserPermissionsByUserId(id);
            service.Dispose();

            return Ok(lstUserPers);
        }

        [HttpPost]
        [Route("GetJsonPermissionAllPaging")]
        public IActionResult GetJsonPermissionAllPaging([FromBody] DataTableRequest request)
        {
            var service = new PermissionBusinessService();
            var lstUserPers = service.GetAllPaging(request);

            service.Dispose();

            return Ok(lstUserPers);
        }

        [Route("GetAllRoles")]
        public ActionResult GetAllRoles()
        {
            var data = _roleService.GetAll();

            return Ok(data);
        }

        [Route("GetAllFunctions")]
        [HttpPost]
        public ActionResult GetAllFunctions()
        {
            var service = new FunctionBusinessService();
            var data = service.GetAll();
            service.Dispose();

            return Ok(data);
        }

        [Route("GetAllLevePermissions")]
        [HttpPost]
        public ActionResult GetAllLevePermissions()
        {
            var service = new LevelPermissionBusinessService();
            var data = service.GetAll();
            service.Dispose();

            return Ok(data);
        }

        [Route("AssignPermissionToRole")]
        [HttpPost]
        public ActionResult AssignPermissionToRole(PermissionViewModel viewModel)
        {
            try
            {
                if (viewModel != null
                 && !string.IsNullOrEmpty(viewModel.StrArrayFunctionActionId)
                 && !string.IsNullOrEmpty(viewModel.StrArryRolesId))
                {
                    var functionActionId = viewModel.FunctionActionId;
                    var arrRoleId = viewModel.StrArryRolesId.Split(';');
                    var arrEmpty = new string[0];
                    var arrFunctionActionId = viewModel.StrArrayFunctionActionId != null ? viewModel.StrArrayFunctionActionId.Split(';') : arrEmpty;
                    var arrFunctionActionIdSelected = viewModel.StrArrayFunctionActionIdSelected != null ? viewModel.StrArrayFunctionActionIdSelected.Split(';') : arrEmpty;
                    List<AppRole_Permission> permissions = new List<AppRole_Permission>();

                    var service = new PermissionBusinessService();

                    if (arrFunctionActionIdSelected.Length > 0)
                    {
                        for (int i = 0; i < arrRoleId.Length; i++)
                        {
                            for (int j = 0; j < arrFunctionActionIdSelected.Length; j++)
                            {
                                AppRole_Permission permission = new AppRole_Permission();

                                permission.Function_ActionID = Int32.Parse(arrFunctionActionIdSelected[j]);
                                permission.RoleID = arrRoleId[i];

                                permissions.Add(permission);
                            }
                        }
                    }

                    service.BulkInsert(permissions, arrRoleId, arrFunctionActionId, out TransactionalInformation transactional);
                    service.Dispose();

                    viewModel.ReturnStatus = transactional.ReturnStatus;
                    viewModel.ReturnMessage = transactional.ReturnMessage;
                }
                else
                {
                    viewModel.ReturnStatus = false;
                    viewModel.ReturnMessage.Add("Error ViewModel Is Nothing");
                }

                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
                return Ok(viewModel);
            }
        }

        [Route("GetActionsByFunctionId")]
        [HttpPost]
        public ActionResult GetActionsByFunctionId([FromBody] string functionId)
        {
            var _levelPermissionBusinessService = new LevelPermissionBusinessService();
            var permissions = _levelPermissionBusinessService.GetActionsByFunctionId(functionId);
            _levelPermissionBusinessService.Dispose();

            return Ok(permissions);
        }
    }
}