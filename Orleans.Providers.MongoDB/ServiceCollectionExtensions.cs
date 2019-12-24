using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Orleans.Providers.MongoDB.Configuration;
using Orleans.Providers.MongoDB.Utils;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        static void dummy(MongoDBOptions _) { }
        /// <summary>
        /// Configure silo to use MongoDb with a passed in connection string.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public static IServiceCollection AddMongoDBClient(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<IMongoClient>(c => new MongoClient(connectionString));
            services.AddSingleton<IMongoClientFactory, DefaultMongoClientFactory>();

            return services;
        }

        public static IServiceCollection AddMongoDBClient(this IServiceCollection services, Action<MongoDBOptions> configureOptions) =>
            services.AddMongoDBClient(ob => ob.Configure(configureOptions ?? dummy));

        public static IServiceCollection AddMongoDBClient(this IServiceCollection services, Action<OptionsBuilder<MongoDBOptions>> configureOptions = null)
        {
            configureOptions?.Invoke(services.AddOptions<MongoDBOptions>());
            var options = services.BuildServiceProvider().GetRequiredService<IOptions<MongoDBOptions>>();
            return services.AddMongoDBClient(options.Value.ConnectionString);
        }
    }
}
