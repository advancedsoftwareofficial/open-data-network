using Microsoft.Extensions.Options;
using ODN.Package.Definitions;
using ODN.Package.Entity;

namespace ODN.Package.Services
{
    public class DataPoolStorageService : BaseODNService<DataPoolStorage>, IDataPoolStorageService
    {
        public DataPoolStorageService(IOptionsMonitor<ODNSettings> appSettings) : base(appSettings,"DataPoolStorage")
        {
        }

        public DataPoolStorageService(ODNSettings odnSettings) : base(odnSettings,"DataPoolStorage")
        {
        }
    }
}