using MultiTenant.App.Sample.UI.Layer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiTenant.App.Sample.UI.Layer.Service
{
    public interface IUserService
    {
        User GetUser();
    }
}