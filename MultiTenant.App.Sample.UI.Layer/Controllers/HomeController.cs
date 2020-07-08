using MultiTenant.App.Sample.UI.Layer.Domain;
using MultiTenant.App.Sample.UI.Layer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiTenant.App.Sample.UI.Layer.Controllers
{
    public class HomeController : Controller
    {
        protected IUserService _service;

        public HomeController(IUserService service)
        {
            _service = service;
        }

        public virtual ActionResult Index()
        {
            var user = _service.GetUser();
            return View(user);
        }
    }
}