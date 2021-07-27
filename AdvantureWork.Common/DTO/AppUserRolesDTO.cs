using System;

namespace AdvantureWork.Common.DTO
{
    public class AppUserRolesDTO
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
    }
}