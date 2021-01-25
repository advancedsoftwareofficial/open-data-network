using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ODN.Package.Definitions;
using ODN.Package.Entity;

namespace ODN.Package.Services
{
    public class DataPoolStorageService :BaseHttpService, IDataPoolStorageService
    {
        public DataPoolStorageService(IOptionsMonitor<AppSettings> appSettings) : base(appSettings)
        {
        }
        public async Task<DataPoolStorage> Add(DataPoolStorage item)
        {
            return await Post<DataPoolStorage, DataPoolStorage>(item, "DataPoolStorage", "api", "api");
        }
    }
}