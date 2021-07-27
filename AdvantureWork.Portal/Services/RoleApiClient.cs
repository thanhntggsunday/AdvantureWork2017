using AdvantureWork.Common.Constant;
using AdvantureWork.Common.DTO;
using AdvantureWork.Common.Request;
using AdvantureWork.Common.ViewModel;
using AdvantureWork.Portal.Services.Interfaces;
using AdvantureWork.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AdvantureWork.Portal.Services
{
    public class RoleApiClient : IRoleApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RoleApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<DataTableViewModel<AppRoleDTO>> GetAllPaging(DataTableRequest request)
        {
            try
            {
                var url = "/api/Roles/GetAllPaging";
                var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

                var json = JsonConvert.SerializeObject(request);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, httpContent);
                var body = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<DataTableViewModel<AppRoleDTO>>(body);
            }
            catch (Exception ex)
            {
                var result = new DataTableViewModel<AppRoleDTO>();
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;

                return result;
            }
        }

        public ApiResult<bool> Create(RoleRequest request)
        {
            try
            {
                var url = "/api/Roles/Create";
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

                return JsonConvert.DeserializeObject<ApiResult<bool>>(body);
            }
            catch (Exception ex)
            {
                var result = new ApiResult<bool>();
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;
                result.ResultObj = false;

                return result;
            }
        }

        public ApiResult<bool> Edit(RoleRequest request)
        {
            try
            {
                var url = "/api/Roles/Edit";
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

                return JsonConvert.DeserializeObject<ApiResult<bool>>(body);
            }
            catch (Exception ex)
            {
                var result = new ApiResult<bool>();
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;
                result.ResultObj = false;

                return result;
            }
        }

        public ApiResult<AppRoleDTO> GetById(RoleRequest request)
        {
            try
            {
                var url = "/api/Roles/GetById";
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

                return JsonConvert.DeserializeObject<ApiResult<AppRoleDTO>>(body);
            }
            catch (Exception ex)
            {
                var result = new ApiResult<AppRoleDTO>();
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;

                return result;
            }
        }

        public ApiResult<bool> Delete(RoleRequest request)
        {
            try
            {
                var url = "/api/Roles/Delete";
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

                return JsonConvert.DeserializeObject<ApiResult<bool>>(body);
            }
            catch (Exception ex)
            {
                var result = new ApiResult<bool>();
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;
                result.ResultObj = false;

                return result;
            }
        }
    }
}