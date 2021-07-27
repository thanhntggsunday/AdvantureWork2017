namespace AdvantureWork.Common.DTO
{
    public class AppPermissionDTO
    {
        public int ID { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string FunctionId { get; set; }
        public string ActionId { get; set; }
        public int FunctionActionId { get; set; }
        public string StrArryRolesId { get; set; }
        public string StrArrayLevePermissionsId { get; set; }
        public string StrArrayFunctionActionId { get; set; }
        public string StrArrayFunctionActionIdSelected { get; set; }
    }
}