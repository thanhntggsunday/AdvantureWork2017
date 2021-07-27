using AdvantureWork.BusinessService.ADO.ServiceImp;
using Microsoft.AspNetCore.Mvc;

namespace AdvantureWork.Api.Controllers
{
    public class DatabaseLogController : Controller
    {
        public IActionResult Index()
        {
            var service = new DatabaseLogService();
            var data = service.GetAllDataLogs();
            service.Dispose();

            return Ok(data);
        }
    }
}