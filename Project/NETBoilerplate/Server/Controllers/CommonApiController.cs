using AdvancedSoftware.DataAccess.Entity;
using AdvancedSoftware.DataAccess.Execution;
using NETBoilerplate.Server.Attributes;

namespace NETBoilerplate.Server.Controllers
{
    [ApiKey]
    public class CommonApiController<T> : CommonController<T> where T : class, IEntityBase
    {
        public CommonApiController(IService<T> service) : base(service)
        {
            
        }
    }
}