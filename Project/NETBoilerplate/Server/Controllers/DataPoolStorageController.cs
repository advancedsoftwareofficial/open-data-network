using NETBoilerplate.Server.Attributes;
using NETBoilerplate.Shared.Entity;
using NETBoilerplate.Shared.Service;

namespace NETBoilerplate.Server.Controllers
{
    public class DataPoolStorageController: CommonApiController<DataPoolStorage>
    {
        private readonly IDataPoolStorageService _dataPoolService;
        public DataPoolStorageController(IDataPoolStorageService dataPoolService) : base(dataPoolService)
        {
            _dataPoolService = dataPoolService;
        }
    }
}