using AdvantureWork.BusinessService.ADO.Interface;
using AdvantureWork.Common.Request;
using Microsoft.AspNetCore.Mvc;

namespace AdvantureWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly ICountryRegionBusinessService _countryRegionBusinessService;

        public LookupController(ICountryRegionBusinessService service)
        {
            _countryRegionBusinessService = service;
        }

        [HttpPost]
        [Route("GetCountryRegion")]
        public IActionResult GetCountryRegion([FromBody] CountryListRequest request)
        {
            // var service = new CountryRegionBusinessService();
            var data = _countryRegionBusinessService.GetAllPaging(request.PageNo, request.CountryName);
            _countryRegionBusinessService.Dispose();

            return Ok(data);
        }
    }
}