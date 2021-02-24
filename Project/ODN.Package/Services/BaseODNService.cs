using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ODN.Package.Entity;

namespace ODN.Package.Services
{
    public class BaseODNService<T> : BaseHttpService
    {
        private readonly ODNSettings _odnSettings;
        private Dictionary<string, string> _headers = new Dictionary<string, string>();
        private readonly string _controller;
        public BaseODNService(IOptionsMonitor<ODNSettings> appSettings,string controller) : base(appSettings)
        {
            _odnSettings = appSettings.CurrentValue;
            _headers.Add("ApiKey", _odnSettings.ApiKey);
            _controller = controller;
        }

        public BaseODNService(ODNSettings odnSettings,string controller) : base(odnSettings)
        {
            _odnSettings = odnSettings;
            _headers.Add("ApiKey", _odnSettings.ApiKey);
            _controller = controller;
        }

        public async Task<T> Add(T item)
        {
            return await Post<T, T>(item, _controller, "api", _headers);
        }

        public async Task<TResult> OdataQuery<TResult>(string query)
        {
            return await Get<TResult>($"{_controller}?{query}", "api", _headers);
        }

        public async Task<bool> Delete(int rowId)
        {
            return await Delete($"{_controller}/{rowId}", "api", _headers);
        }

        public async Task<T> Update(T item)
        {
            return await Put<T, T>(item, _controller, "api", _headers);
        }
    }
}