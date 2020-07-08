using Autofac.Multitenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiTenant.App.Sample.UI.Layer.Infrastructure
{
    public class TenantIdentificationStrategy : ITenantIdentificationStrategy
    {
        public bool TryIdentifyTenant(out object tenantId)
        {
            tenantId = null;
            try
            {
                var context = HttpContext.Current;
                if (context != null && context.Request != null)
                {
                    var uriSeg = context.Request.Path.Split('/');
                    tenantId = uriSeg[1];
                }
            }
            catch (HttpException)
            {
               // Do Nothing
            }
            return tenantId != null;
        }
    }
}