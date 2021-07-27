using AdvantureWork.Common.DTO;
using AdvantureWork.ViewModels.Common;
using System.Collections.Generic;

namespace AdvantureWork.Common.ViewModel
{
    public class AppUserRolesViewModels<Object> : ApiResult<Object>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppUserRolesViewModels"/> class.
        /// </summary>
        public AppUserRolesViewModels()
        {
            UserRolesList = new HashSet<AppUserRolesDTO>();
        }

        /// <summary>
        /// Gets or sets the UserId
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the RoleName
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the userRolesList
        /// </summary>
        public ICollection<AppUserRolesDTO> UserRolesList { get; set; }

        public ICollection<AppUserDTO> Users { get; set; }

        public ICollection<AppRoleDTO> Roles { get; set; }
    }
}