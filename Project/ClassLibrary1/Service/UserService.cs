using AdvancedSoftware.DataAccess.Execution;
using NETBoilerplate.DataAccess.Database;
using NETBoilerplate.Shared.Entity;
using NETBoilerplate.Shared.Service;

namespace NETBoilerplate.DataAccess.Service
{
    public class UserService: ServiceBase<User, ServerDbContext>, IUserService
    {
        public UserService(ServerDbContext dbContext) : base(dbContext)
        {

        }
    }
}