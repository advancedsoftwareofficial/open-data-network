using Microsoft.Extensions.Logging;
using NETBoilerplate.Shared.Entity;
using NETBoilerplate.Shared.Service;

namespace NETBoilerplate.Server.Controllers
{
    public class DataPoolController: CommonApiController<DataPool>
    {
        private readonly IDataPoolService _dataPoolService;
        public DataPoolController(IDataPoolService dataPoolService,ILogger<CommonController<DataPool>> controller) : base(dataPoolService,controller)
        {
            _dataPoolService = dataPoolService;
        }
    }
}