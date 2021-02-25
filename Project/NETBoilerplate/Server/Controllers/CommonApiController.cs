using AdvancedSoftware.DataAccess.Entity;
using AdvancedSoftware.DataAccess.Execution;
using Microsoft.Extensions.Logging;
using NETBoilerplate.Server.Attributes;

namespace NETBoilerplate.Server.Controllers
{
    [ApiKey]
    public class CommonApiController<T> : CommonController<T> where T : class, IEntityBase
    {
        public CommonApiController(IService<T> service,ILogger<CommonController<T>> controller) : base(service,controller)
        {
            
        }
    }
}