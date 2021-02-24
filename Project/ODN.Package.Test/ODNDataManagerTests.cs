using System.Threading.Tasks;
using ODN.Package.Entity;
using ODN.Package.Services;
using ODN.Package.Test.Entities;
using Xunit;

namespace ODN.Package.Test
{
    public class ODNDataManagerTests
    {
        [Fact]
        public async Task Add()
        {
            ODNDataManager manager = new ODNDataManager(new ODNSettings()
                {RESTAddress = "http://localhost/ODN", ApiKey = "34DA933321CD615E3748FE5A811E2F03"});
            await manager.AddEntity(new Product() {Name = "Added via manager", Price = 123});
        }
    }
}