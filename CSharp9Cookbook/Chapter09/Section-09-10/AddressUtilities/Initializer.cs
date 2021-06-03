using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace AddressUtilities
{
    class Initializer
    {
        internal static ServiceProvider Container { get; set; }

        [ModuleInitializer]
        internal static void InitAddressUtilities()
        {
            var services = new ServiceCollection();
            services.AddTransient<AddressService>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            Container = services.BuildServiceProvider();
        }
    }
}
