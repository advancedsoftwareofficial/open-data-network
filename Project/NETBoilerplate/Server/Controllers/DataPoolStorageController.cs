using Microsoft.Extensions.Logging;
using NETBoilerplate.Shared.Entity;
using NETBoilerplate.Shared.Service;

namespace NETBoilerplate.Server.Controllers
{
    public class DataPoolStorageController: CommonApiController<DataPoolStorage>
    {
        private readonly IDataPoolStorageService _dataPoolService;
        public DataPoolStorageController(IDataPoolStorageService dataPoolService,ILogger<CommonController<DataPoolStorage>> controller) : base(dataPoolService,controller)
        {
            _dataPoolService = dataPoolService;
        }
    }
}