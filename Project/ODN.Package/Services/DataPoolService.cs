using Microsoft.Extensions.Options;
using ODN.Package.Definitions;
using ODN.Package.Entity;

namespace ODN.Package.Services
{
    public class DataPoolService : BaseODNService<DataPool>, IDataPool
    {
        public DataPoolService(IOptionsMonitor<ODNSettings> appSettings) : base(appSettings,"DataPool")
        {
        }

        public DataPoolService(ODNSettings odnSettings) : base(odnSettings,"DataPool")
        {
        }
    }
}