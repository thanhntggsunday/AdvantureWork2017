using AdvantureWork.Common.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantureWork.Common.ViewModel.System.Permissions
{
    public class PermissionViewModel : TransactionalInformation
    {
        public int ID { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string FunctionId { get; set; }
        public int FunctionActionId { get; set; }
        public string ActionId { get; set; }
        public string StrArryRolesId { get; set; }
        public string StrArrayLevePermissionsId { get; set; }
        public string StrArrayFunctionActionId { get; set; }
        public string StrArrayFunctionActionIdSelected { get; set; }
    }
}