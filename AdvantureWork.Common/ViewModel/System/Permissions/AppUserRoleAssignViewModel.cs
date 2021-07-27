namespace AdvantureWork.Common.ViewModel
{
    public class AppUserRoleAssignViewModel<AppUserRolesDTO> : ListViewModel<AppUserRolesDTO>
    {
        public string UserIds { get; set; }
        public string RoleNames { get; set; }
    }
}