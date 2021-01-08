using AdvancedSoftware.DataAccess.Execution;
using NETBoilerplate.DataAccess.Database;
using NETBoilerplate.Shared.Entity;
using NETBoilerplate.Shared.Service;

namespace NETBoilerplate.DataAccess.Service
{
    public class ContentService : ServiceBase<Content, ServerDbContext>, IContentService
    {
        public ContentService(ServerDbContext dbContext) : base(dbContext)
        {

        }
    }
}
