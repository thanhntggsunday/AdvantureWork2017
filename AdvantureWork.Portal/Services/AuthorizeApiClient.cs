using AdvantureWork.Common.Constant;
using AdvantureWork.Common.DTO;
using AdvantureWork.Common.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace AdvantureWork.Portal.Services
{
    public class AuthorizeApiClient
    {
        public static IHttpClientFactory _httpClientFactory;
        public static IConfiguration _configuration;
        public static IHttpContextAccessor _httpContextAccessor;

        public DataTableViewModel<AppAllUserPermissionDTO> GetItemsById<T>(T request)
        {
            var result = new DataTableViewModel<AppAllUserPermissionDTO>();
            try
            {
                if (_httpContextAccessor.HttpContext.Session == null)
                {
                    result.ReturnMessage.Add("No Session");
                    result.ReturnStatus = false;

                    return result;
                }

                var url = "/api/Permission/GetAllUserPermissionByUserId";
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

                return JsonConvert.DeserializeObject<DataTableViewModel<AppAllUserPermissionDTO>>(body);
            }
            catch (Exception ex)
            {
               
                result.ReturnMessage.Add(ex.Message);
                result.ReturnStatus = false;

                return result;
            }
        }
    }
}