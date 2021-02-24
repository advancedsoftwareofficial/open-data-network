using System.Threading.Tasks;
using Newtonsoft.Json;
using ODN.Package.Entity;

namespace ODN.Package.Services
{
    public class ODNDataManager
    {
        private readonly DataPoolStorageService _dataPoolStorageService;

        private readonly DataPoolService _dataPoolService;
        public ODNDataManager(ODNSettings settings)
        {
            _dataPoolStorageService = new DataPoolStorageService(settings);
            _dataPoolService = new DataPoolService(settings);
        }
        public async Task AddEntity<T>(T data)
        {
            var dataPool = await GetDataPool(data);
            if (dataPool == null)
            {
                dataPool = await AddDataPool(data);
            }
            await _dataPoolStorageService.Add(new DataPoolStorage() {Data = JsonConvert.SerializeObject(data),DataPoolId = dataPool.Id});
        }

        public async Task<DataPool> GetDataPool<T>(T dataPool)
        {
            return await _dataPoolService.OdataQuery<DataPool>($"$filter=PoolName eq '{dataPool.GetType().Name}'");
        }
        public async Task<DataPool> AddDataPool<T>(T dataPool)
        {
            return await _dataPoolService.Add(new DataPool() {UserId = 1, PoolName = dataPool.GetType().Name});
        }
    }
}