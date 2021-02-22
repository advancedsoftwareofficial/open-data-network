using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ODN.Package.Definitions;
using ODN.Package.Entity;

namespace ODN.Package.Services
{
    public class DataPoolStorageService : BaseHttpService, IDataPoolStorageService
    {
        private readonly AppSettings _appSettings;
        private Dictionary<string, string> _headers = new Dictionary<string, string>();

        public DataPoolStorageService(IOptionsMonitor<AppSettings> appSettings) : base(appSettings)
        {
            _appSettings = appSettings.CurrentValue;
            _headers.Add("ApiKey", _appSettings.ApiKey);
        }

        public DataPoolStorageService(AppSettings appSettings) : base(appSettings)
        {
            _appSettings = appSettings;
            _headers.Add("ApiKey", _appSettings.ApiKey);
        }

        public async Task<DataPoolStorage> Add(DataPoolStorage item)
        {
            return await Post<DataPoolStorage, DataPoolStorage>(item, "DataPoolStorage", "api", _headers);
        }

        public async Task<T> OdataQuery<T>(string query)
        {
            return await Get<T>($"DataPoolStorage{query}", "api", _headers);
        }

        public async Task<bool> Delete(int rowId)
        {
            return await Delete($"DataPoolStorage/{rowId}", "api", _headers);
        }

        public async Task<DataPoolStorage> Update(DataPoolStorage item)
        {
            return await Put<DataPoolStorage,DataPoolStorage>(item, "DataPoolStorage", "api", _headers);
        }
    }
}