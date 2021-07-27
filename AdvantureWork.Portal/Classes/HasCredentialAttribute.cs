using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdvantureWork.Portal.Classes
{
    public class AdminAuthorizePermission : AuthorizeAttribute, IAuthorizationFilter
    {
        public string Function;
        public string Action;
        private PermissionHandle sevicePermission = new PermissionHandle();

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //Identity.Name will have windows logged in user id, in case of Windows Authentication
            //Indentity.Name will have user name passed from token, in case of JWT Authenntication and having claim type "ClaimTypes.Name"
            var userName = context.HttpContext.User.Identity.Name;
          
            var data = sevicePermission.GetAllUserPermissionByUserId(context.HttpContext.User.Identity.Name);

            if (data == null || data.data == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (userName.ToLower() == "admin@gmail.com")
            {
                return;
            }

            foreach (var x in data.data)
            {
                if (x.FunctionId.ToUpper() == Function && x.ActionId.ToUpper() == Action)
                {
                    return; //User Authorized. Wihtout setting any result value and just returning is sufficent for authorizing user
                }
            }

            context.Result = new UnauthorizedResult();
            return;
        }
    }
}