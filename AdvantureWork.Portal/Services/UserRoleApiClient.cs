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
    public class UserRoleApiClient : IUserRoleApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRoleApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<DataTableViewModel<AppUserRolesDTO>> GetAllUserRolesPaging(DataTableRequest request)
        {
            try
            {
                var sessions = _httpContextAccessor
               .HttpContext
               .Session
               .GetString(SystemConstants.AppSettings.Token);

                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

                var json = JsonConvert.SerializeObject(request);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"/api/UserRole/GetAllUserRolesPaging", httpContent);
                var result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<DataTableViewModel<AppUserRolesDTO>>(result);

                return JsonConvert.DeserializeObject<DataTableViewModel<AppUserRolesDTO>>(result);
            }
            catch (Exception ex)
            {
                var result = new DataTableViewModel<AppUserRolesDTO>();
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;

                return result;
            }
        }

        public async Task<DataTableViewModel<AppUserDTO>> GetJsonAllUser()
        {
            try
            {
                var sessions = _httpContextAccessor
               .HttpContext
               .Session
               .GetString(SystemConstants.AppSettings.Token);

                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

                var json = JsonConvert.SerializeObject(string.Empty);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"/api/UserRole/GetJsonAllUser", httpContent);
                var result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<DataTableViewModel<AppUserDTO>>(result);

                return JsonConvert.DeserializeObject<DataTableViewModel<AppUserDTO>>(result);
            }
            catch (Exception ex)
            {
                var result = new DataTableViewModel<AppUserDTO>();
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;

                return result;
            }
        }

        public async Task<DataTableViewModel<AppRoleDTO>> GetJsonAllRole()
        {
            try
            {
                var sessions = _httpContextAccessor
                                 .HttpContext
                                 .Session
                                 .GetString(SystemConstants.AppSettings.Token);

                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

                var json = JsonConvert.SerializeObject(string.Empty);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"/api/UserRole/GetJsonAllRole", httpContent);
                var result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<DataTableViewModel<AppRoleDTO>>(result);

                return JsonConvert.DeserializeObject<DataTableViewModel<AppRoleDTO>>(result);
            }
            catch (Exception ex)
            {
                var result = new DataTableViewModel<AppRoleDTO>();
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;

                return result;
            }
        }

        public async Task<DataTableViewModel<AppRoleDTO>> GetJsonAllRoleOfUserByUserId(string uid)
        {
            try
            {

                var sessions = _httpContextAccessor
                                .HttpContext
                                .Session
                                .GetString(SystemConstants.AppSettings.Token);

                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
              
                var json = JsonConvert.SerializeObject(uid);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"/api/UserRole/GetJsonAllRoleOfUserByUserId", httpContent);
                var result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<DataTableViewModel<AppRoleDTO>>(result);

                return JsonConvert.DeserializeObject<DataTableViewModel<AppRoleDTO>>(result);
            }
            catch (Exception ex)
            {
                var result = new DataTableViewModel<AppRoleDTO>();
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;

                return result;
            }
        }

        public async Task<AppUserRoleAssignViewModel<AppUserRolesDTO>> AssignUserRole(AppUserRoleAssignViewModel<AppUserRolesDTO> vm)
        {
            try
            {
                var sessions = _httpContextAccessor
                                 .HttpContext
                                 .Session
                                 .GetString(SystemConstants.AppSettings.Token);

                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

                var json = JsonConvert.SerializeObject(vm);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"/api/UserRole/AssignUserRole", httpContent);
                var result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<AppUserRoleAssignViewModel<AppUserRolesDTO>>(result);

                return JsonConvert.DeserializeObject<AppUserRoleAssignViewModel<AppUserRolesDTO>>(result);
            }
            catch (Exception ex)
            {
                var result = new AppUserRoleAssignViewModel<AppUserRolesDTO>();
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;

                return result;
            }
        }

        public async Task<AppUserRoleAssignViewModel<AppUserRolesDTO>> Delete(AppUserRoleAssignViewModel<AppUserRolesDTO> vm)
        {
            try
            {
                var sessions = _httpContextAccessor
                                 .HttpContext
                                 .Session
                                 .GetString(SystemConstants.AppSettings.Token);

                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

                var json = JsonConvert.SerializeObject(vm);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"/api/UserRole/Delete", httpContent);
                var result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<AppUserRoleAssignViewModel<AppUserRolesDTO>>(result);

                return JsonConvert.DeserializeObject<AppUserRoleAssignViewModel<AppUserRolesDTO>>(result);
            }
            catch (Exception ex)
            {
                var result = new AppUserRoleAssignViewModel<AppUserRolesDTO>();
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;

                return result;
            }
        }

        public async Task<ApiResult<AppUserDTO>> GetById(string uid)
        {
            try
            {
                var sessions = _httpContextAccessor
                                .HttpContext
                                .Session
                                .GetString(SystemConstants.AppSettings.Token);

                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

                var json = JsonConvert.SerializeObject(uid);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"/api/UserRole/GetById", httpContent);
                var result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<ApiResult<AppUserDTO>>(result);

                return JsonConvert.DeserializeObject<ApiResult<AppUserDTO>>(result);
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