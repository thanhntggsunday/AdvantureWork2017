using AdvantureWork.Common.Request;
using AdvantureWork.Portal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvantureWork.Portal.Areas.Admin.Controllers
{
    public class LookupController : AminBaseController
    {
        private ILookupApiClient _lookupApiClient;

        public LookupController(ILookupApiClient lookupApiClient)
        {
            _lookupApiClient = lookupApiClient;
        }

        [HttpGet]
        public IActionResult GetCountryRegion(CountryListRequest request)
        {
            var data = _lookupApiClient.GetAllPaging(request);

            return Ok(data);
        }
    }
}