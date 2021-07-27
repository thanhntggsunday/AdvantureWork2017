using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvantureWork.Portal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AminBaseController : Controller
    {
    }
}