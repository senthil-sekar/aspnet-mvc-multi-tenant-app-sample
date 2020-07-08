using MultiTenant.App.Sample.API.Layer.Domain;
using System.Web.Http;

namespace MultiTenant.App.Sample.API.Layer.Controllers
{
    public class UserController : ApiController
    {
        public virtual User Get()
        {
            return new User { CustomerName = "US"};
        }
    }
}
