using AdvancedSoftware.DataAccess.Execution;
using NETBoilerplate.DataAccess.Database;
using NETBoilerplate.Shared.Entity;
using NETBoilerplate.Shared.Service;

namespace NETBoilerplate.DataAccess.Service
{
    public class DataPoolService: ServiceBase<DataPool, ServerDbContext>, IDataPoolService
    {
        public DataPoolService(ServerDbContext dbContext) : base(dbContext)
        {
        }
    }
}