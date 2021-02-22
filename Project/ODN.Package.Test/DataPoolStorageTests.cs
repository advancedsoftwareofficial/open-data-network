using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ODN.Package.Definitions;
using ODN.Package.Entity;
using ODN.Package.Services;
using ODN.Package.Test.Entities;
using Xunit;

namespace ODN.Package.Test
{
    public class DataPoolStorageTests
    {
        [Fact]
        public async Task Add()
        {
            IDataPoolStorageService service = new DataPoolStorageService(new AppSettings()
                {RESTAddress = "https://odn.azurewebsites.net", ApiKey = "34DA933321CD615E3748FE5A811E2F03"}
            );
            var result = await  service.Add(new Entity.DataPoolStorage()
                {Data = JsonConvert.SerializeObject(new Product {Name = "Mouse", Price = 10.2M}),DataPoolId = 1});
            Debug.WriteLine($"{result.Id}");
            var obj = JsonConvert.DeserializeObject<Product>(result.Data);
            Assert.True(result.Id > 0);
            Assert.True(obj.Name == "Mouse");
        }

        [Fact]
        public async Task Delete()
        {
            IDataPoolStorageService service = new DataPoolStorageService(new AppSettings()
                {RESTAddress = "https://odn.azurewebsites.net", ApiKey = "34DA933321CD615E3748FE5A811E2F03"}
            );
            var result = await service.Delete(6);
            Assert.True(result);
        }

        [Fact]
        public async Task Update()
        {
            IDataPoolStorageService service = new DataPoolStorageService(new AppSettings()
                {RESTAddress = "https://odn.azurewebsites.net", ApiKey = "34DA933321CD615E3748FE5A811E2F03"}
            );
            var data = new DataPoolStorage();
            data.Id = 5;
            data.DataPoolId = 1;
            data.Data = JsonConvert.SerializeObject(new Product {Name = "Keyboard", Price = 13.2M});
            var result = await service.Update(data);

        }

        [Fact]
        public async Task Get()
        {
            IDataPoolStorageService service = new DataPoolStorageService(new AppSettings()
                {RESTAddress = "https://odn.azurewebsites.net", ApiKey = "34DA933321CD615E3748FE5A811E2F03"}
            );
            var items = await service.OdataQuery<List<DataPoolStorage>>("?$filter=DataPoolId eq 1&$orderby=id desc");
            Assert.True(items.Count > 0);
        }
    }
    
}