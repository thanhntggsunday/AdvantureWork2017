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
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public ApiResult<bool> ChangePassword(AppUserDTO request)
        {
            try
            {
                var url = "/api/Users/ChangePassword";
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

                return result;
            }
        }

        public ApiResult<AppUserDTO> Create(AppUserRequest request)
        {
            try
            {
                var url = "/api/Users/Create";
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

                return JsonConvert.DeserializeObject<ApiResult<AppUserDTO>>(body);
            }
            catch (Exception ex)
            {
                var result = new ApiResult<AppUserDTO>();
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;

                return result;
            }
        }

        public ApiResult<bool> Delete(AppUserRequest request)
        {
            try
            {
                var url = "/api/Users/Delete";
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

                return result;
            }
        }

        public async Task<DataTableViewModel<AppUserDTO>> GetAllPaging(DataTableRequest request)
        {
            try
            {
                var url = "/api/Users/GetAllPaging";
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

                return JsonConvert.DeserializeObject<DataTableViewModel<AppUserDTO>>(body);
            }
            catch (Exception ex)
            {
                var result = new DataTableViewModel<AppUserDTO>();
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;

                return result;
            }
        }

        public ApiResult<AppUserDTO> GetById(AppUserRequest request)
        {
            try
            {
                var url = "/api/Users/GetById";
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

                return JsonConvert.DeserializeObject<ApiResult<AppUserDTO>>(body);
            }
            catch (Exception ex)
            {
                var result = new ApiResult<AppUserDTO>();
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;

                return result;
            }
        }

        public ApiResult<AppUserDTO> Update(AppUserRequest request)
        {
            try
            {
                var url = "/api/Users/Edit";
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

                return JsonConvert.DeserializeObject<ApiResult<AppUserDTO>>(body);
            }
            catch (Exception ex)
            {
                var result = new ApiResult<AppUserDTO>();
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;

                return result;
            }
        }
    }
}