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
    public class DefaultUserService : IUserService
    {
        protected static HttpClient _httpClient = new HttpClient();

        private ITenantIdentificationStrategy _tenantIdentificationStrategy;
        public DefaultUserService(ITenantIdentificationStrategy tenantIdentificationStrategy)
        {
            _tenantIdentificationStrategy = tenantIdentificationStrategy;
        }

        public virtual User GetUser()
        {
            var response = _httpClient.GetAsync("http://localhost:51006/api/user").Result;
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

        protected object GetTenantId()
        {
            var tenantId = (object)null;
            var success = _tenantIdentificationStrategy.TryIdentifyTenant(out tenantId);
            if (!success || tenantId == null)
            {
                return "";
            }
            return tenantId;
        }
    }
}