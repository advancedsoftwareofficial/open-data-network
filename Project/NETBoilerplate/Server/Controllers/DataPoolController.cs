using NETBoilerplate.Server.Attributes;
using NETBoilerplate.Shared.Entity;
using NETBoilerplate.Shared.Service;

namespace NETBoilerplate.Server.Controllers
{
    [ApiKey]
    public class DataPoolController: CommonController<DataPool>
    {
        private readonly IDataPoolService _dataPoolService;
        public DataPoolController(IDataPoolService dataPoolService) : base(dataPoolService)
        {
            _dataPoolService = dataPoolService;
        }
    }
}