using MultiTenant.App.Sample.API.Layer.Domain;

namespace MultiTenant.App.Sample.API.Layer.Controllers
{
    public class Tenant1Controller : UserController
    {
        public override User Get()
        {
            return new User { CustomerName = "Tenant1 - Canada" };
        }
    }
}
