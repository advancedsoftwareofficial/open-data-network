using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ODN.Package.Definitions;
using ODN.Package.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NETBoilerplate.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            var http = new HttpClient()
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            };

            builder.Services.AddScoped(sp => http);

            using var response = await http.GetAsync("appsettings.json");
            using var stream = await response.Content.ReadAsStreamAsync();

            builder.Configuration.AddJsonStream(stream);
            builder.Services.AddScoped<IDataPoolStorageService, DataPoolStorageService>();
            await builder.Build().RunAsync();
        }
    }
}
