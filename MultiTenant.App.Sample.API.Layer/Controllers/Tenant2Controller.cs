using MultiTenant.App.Sample.API.Layer.Domain;

namespace MultiTenant.App.Sample.API.Layer.Controllers
{
    public class Tenant2Controller : UserController
    {
        public override User Get()
        {
            return new User { CustomerName = "Tenant2 - China" };
        }
    }
}
