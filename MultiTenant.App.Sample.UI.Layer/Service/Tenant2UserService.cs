using Autofac.Multitenant;
using MultiTenant.App.Sample.UI.Layer.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace MultiTenant.App.Sample.UI.Layer.Service
{
    public class Tenant2UserService : DefaultUserService, IUserService
    {
        public Tenant2UserService(ITenantIdentificationStrategy tenantIdentificationStrategy) 
            : base(tenantIdentificationStrategy)
        {
        }

        public override User GetUser()
        {
            var response = _httpClient.GetAsync($"http://localhost:51006/api/{GetTenantId()}/user").Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
            else
            {
                var content = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<User>(content);
            }
        }
    }
}