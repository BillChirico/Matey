using Matey.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Matey.Tests.ServiceTests
{
    public abstract class ServiceTests
    {
        protected readonly DbContextOptions<MateyDbContext> ContextOptions;

        protected ServiceTests()
        {
            // Create a service provider to be shared by all test methods
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create options telling the context to use an
            // InMemory database and the service provider.
            var builder = new DbContextOptionsBuilder<MateyDbContext>();
            builder.UseInMemoryDatabase()
                .UseInternalServiceProvider(serviceProvider);

            ContextOptions = builder.Options;
        }
    }
}