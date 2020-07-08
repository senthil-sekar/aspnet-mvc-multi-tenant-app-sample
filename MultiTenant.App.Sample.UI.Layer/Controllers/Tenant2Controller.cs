using MultiTenant.App.Sample.UI.Layer.Domain;
using MultiTenant.App.Sample.UI.Layer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiTenant.App.Sample.UI.Layer.Controllers
{
    public class Tenant2Controller : HomeController
    {
        public Tenant2Controller(IUserService service) : base(service)
        {
        }

        // GET: Tenant2
        public override ActionResult Index()
        {
            var user = _service.GetUser();
            return View(user);
        }
    }
}