using AdvantureWork.Common.Constant;
using AdvantureWork.Common.DTO;
using AdvantureWork.Common.Request;
using AdvantureWork.Common.ViewModel;
using AdvantureWork.Portal.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace AdvantureWork.Portal.Services
{
    public class LookupApiClient : ILookupApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LookupApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public DataTableViewModel<CountryRegionDTO> GetAllPaging(CountryListRequest request)
        {
            try
            {
                var url = "/api/Lookup/GetCountryRegion";
                var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

                var json = JsonConvert.SerializeObject(request);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync(url, httpContent).GetAwaiter().GetResult();
                var body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                return JsonConvert.DeserializeObject<DataTableViewModel<CountryRegionDTO>>(body);
            }
            catch (Exception ex)
            {
                var result = new DataTableViewModel<CountryRegionDTO>();
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;

                return result;
            }
        }
    }
}