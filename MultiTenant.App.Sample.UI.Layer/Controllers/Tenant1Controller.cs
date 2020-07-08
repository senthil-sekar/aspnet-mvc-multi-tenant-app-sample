using MultiTenant.App.Sample.UI.Layer.Domain;
using MultiTenant.App.Sample.UI.Layer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiTenant.App.Sample.UI.Layer.Controllers
{
    public class Tenant1Controller : HomeController
    {
        public Tenant1Controller(IUserService service) : base(service)
        {
        }

        // GET: Tenant1
        public override ActionResult Index()
        {
            var user = _service.GetUser();
            return View(user);
        }
    }
}