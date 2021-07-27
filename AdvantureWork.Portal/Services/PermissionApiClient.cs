using AdvantureWork.Common.Constant;
using AdvantureWork.Common.DTO;
using AdvantureWork.Common.Request;
using AdvantureWork.Common.ViewModel;
using AdvantureWork.Common.ViewModel.System.Permissions;
using AdvantureWork.Model.DTO;
using AdvantureWork.Portal.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AdvantureWork.Portal.Services
{
    public class PermissionApiClient : IPermissionApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PermissionApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public PermissionViewModel AssignPermissionToRole(PermissionViewModel viewModel)
        {
            try
            {
                var url = "/api/Permission/AssignPermissionToRole";
                var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

                var json = JsonConvert.SerializeObject(viewModel);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync(url, httpContent).GetAwaiter().GetResult();
                var body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                return JsonConvert.DeserializeObject<PermissionViewModel>(body);
            }
            catch (Exception ex)
            {
                var result = new PermissionViewModel();
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;

                return result;
            }
        }

        public DataTableViewModel<AppFunctionDTO> GetAllFunctions()
        {
            try
            {
                var url = "/api/Permission/GetAllFunctions";
                var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

                var json = JsonConvert.SerializeObject(string.Empty);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync(url, httpContent).GetAwaiter().GetResult();
                var body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                return JsonConvert.DeserializeObject<DataTableViewModel<AppFunctionDTO>>(body);
            }
            catch (Exception ex)
            {
                var result = new DataTableViewModel<AppFunctionDTO>();
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;

                return result;
            }
        }

        public DataTableViewModel<AppLevelPermissionDTO> GetActionsByFunctionId(string functionId)
        {
            try
            {
                var url = "/api/Permission/GetActionsByFunctionId";
                var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

                var json = JsonConvert.SerializeObject(functionId);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync(url, httpContent).GetAwaiter().GetResult();
                var body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                return JsonConvert.DeserializeObject<DataTableViewModel<AppLevelPermissionDTO>>(body);
            }
            catch (Exception ex)
            {
                var result = new DataTableViewModel<AppLevelPermissionDTO>();
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;

                return result;
            }
        }

        public DataTableViewModel<AppLevelPermissionDTO> GetAllLevelPermissios()
        {
            try
            {
                var url = "/api/Permission/GetAllLevePermissions";
                var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

                var json = JsonConvert.SerializeObject(string.Empty);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync(url, httpContent).GetAwaiter().GetResult();
                var body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                return JsonConvert.DeserializeObject<DataTableViewModel<AppLevelPermissionDTO>>(body);
            }
            catch (Exception ex)
            {
                var result = new DataTableViewModel<AppLevelPermissionDTO>();
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;

                return result;
            }
        }

        public DataTableViewModel<AppPermissionDTO> GetAllPaging(DataTableRequest request)
        {
            try
            {
                var url = "/api/Permission/GetJsonPermissionAllPaging";
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

                return JsonConvert.DeserializeObject<DataTableViewModel<AppPermissionDTO>>(body);
            }
            catch (Exception ex)
            {
                var result = new DataTableViewModel<AppPermissionDTO>();
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;

                return result;
            }
        }

        public DataTableViewModel<AppRoleDTO> GetAllRoles()
        {
            try
            {
                var url = "/api/Permission/GetAllRoles";
                var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

                var json = JsonConvert.SerializeObject(string.Empty);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync(url, httpContent).GetAwaiter().GetResult();
                var body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

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

        public DataTableViewModel<AppAllUserPermissionDTO> GetAllUserPermissionsByUserId(string userId)
        {
            try
            {
                var url = "/api/Permission/GetAllUserPermissionByUserId";
                var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

                var json = JsonConvert.SerializeObject(userId);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync(url, httpContent).GetAwaiter().GetResult();
                var body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                return JsonConvert.DeserializeObject<DataTableViewModel<AppAllUserPermissionDTO>>(body);
            }
            catch (Exception ex)
            {
                var result = new DataTableViewModel<AppAllUserPermissionDTO>();
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;

                return result;
            }
        }
    }
}
