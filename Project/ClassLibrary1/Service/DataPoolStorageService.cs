using AdvancedSoftware.DataAccess.Execution;
using NETBoilerplate.DataAccess.Database;
using NETBoilerplate.Shared.Entity;
using NETBoilerplate.Shared.Service;

namespace NETBoilerplate.DataAccess.Service
{
    public class DataPoolStorageService : ServiceBase<DataPoolStorage, ServerDbContext>, IDataPoolStorageService
    {
        public DataPoolStorageService(ServerDbContext dbContext) : base(dbContext)
        {
        }
    }
}