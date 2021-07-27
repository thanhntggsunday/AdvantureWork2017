using AdvantureWork.Portal.Classes;
using Microsoft.AspNetCore.Mvc;

namespace AdvantureWork.Portal.Areas.Admin.Controllers
{
    // [AdminAuthorizePermission(Function = "", Action = "")]
    public class HomeController : AminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}