using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Bamboo.Attendance.Blazor.Host
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            var application = builder.AddApplication<AttendanceBlazorHostModule>(options =>
            {
                options.UseAutofac();
            });

            var host = builder.Build();

            await application.InitializeAsync(host.Services);

            await host.RunAsync();
        }
    }
}
