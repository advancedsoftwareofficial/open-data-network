﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.Extensions.Options;
using ODN.Package.Entity;

namespace ODN.Package
{
    public class BaseHttpService
    {
        private readonly ODNSettings _odnSettings;
        public BaseHttpService(IOptionsMonitor<ODNSettings> appSettings)
        {
            _odnSettings = appSettings.CurrentValue;
        }

        public BaseHttpService(ODNSettings odnSettings)
        {
            _odnSettings = odnSettings;
        }
        public async Task<TResponse> Get<TResponse>(string controller, string apiPrefix, Dictionary<string,string> headers = null,string oauth = null)
        {
            string baseUrl = _odnSettings.RESTAddress;
            Stopwatch stopwatch = Stopwatch.StartNew();
            Debug.WriteLine($"GET Request initiated - Address: {baseUrl}/{apiPrefix}/{controller}");

            try
            {
                var data = await $"{baseUrl}/{apiPrefix}/{controller}".WithHeaders(headers).WithOAuthBearerToken(oauth).GetAsync().ReceiveJson<TResponse>();
                stopwatch.Stop();
                Debug.WriteLine($"GET Request finished - Time:{stopwatch.ElapsedMilliseconds}");
                return data;
            }
            catch (System.Exception ex)
            {

            }

            return default;
        }
        public async Task<TResponse> Post<TRequest, TResponse>(TRequest entity, string controller, string apiPrefix, string token)
        {
            string baseUrl = _odnSettings.RESTAddress;
            Debug.WriteLine($"Request initiated - Address: {baseUrl} Target {controller}");
            Stopwatch stopwatch = Stopwatch.StartNew();
            var result = await $"{baseUrl}/{apiPrefix}/{controller}".WithOAuthBearerToken(token).PostJsonAsync(entity).ReceiveJson<TResponse>();
            stopwatch.Stop();
            Debug.WriteLine($"Elapsed Time - {stopwatch.Elapsed}");
            return result;
        }
        public async Task<TResponse> Put<TRequest, TResponse>(TRequest entity, string controller, string apiPrefix,Dictionary<string,string> headers = null,string oauth = null)
        {
            string baseUrl = _odnSettings.RESTAddress;
            var result = await $"{baseUrl}/{apiPrefix}/{controller}".WithHeaders(headers).WithOAuthBearerToken(oauth).PutJsonAsync(entity).ReceiveJson<TResponse>();
            return result;
        }
        public async Task<bool> Delete(string controller, string apiPrefix, Dictionary<string,string> headers = null,string oauth = null)
        {
            string baseUrl = _odnSettings.RESTAddress;
            var result = await $"{baseUrl}/{apiPrefix}/{controller}".WithHeaders(headers).WithOAuthBearerToken(oauth).DeleteAsync();
            return await Task.FromResult(true);
        }
        public async Task<TResponse> Post<TRequest, TResponse>(TRequest entity, string controller, string apiPrefix,Dictionary<string,string> headers = null,string oauth = null)
        {
            string baseUrl = _odnSettings.RESTAddress;
            Debug.WriteLine($"Request initiated - Address: {baseUrl} Target {controller}");
            Stopwatch stopwatch = Stopwatch.StartNew();
            var result = await $"{baseUrl}/{apiPrefix}/{controller}".WithHeaders(headers).WithOAuthBearerToken(oauth).PostJsonAsync(entity).ReceiveJson<TResponse>();
            stopwatch.Stop();
            Debug.WriteLine($"Elapsed Time - {stopwatch.Elapsed}");
            return result;
        }
    }
}