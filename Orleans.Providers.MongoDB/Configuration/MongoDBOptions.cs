using Microsoft.Extensions.Options;
using Orleans.Runtime;

// ReSharper disable InvertIf

namespace Orleans.Providers.MongoDB.Configuration
{
    /// <summary>
    /// Options to configure MongoDB for Orleans
    /// </summary>
    public class MongoDBOptions: IOptions<MongoDBOptions>
    {
        /// <summary>
        /// Connection string for MongoClient
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Database name.
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// The mongo client name.
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// The collection prefix.
        /// </summary>
        public string CollectionPrefix { get; set; }

        /// <summary>
        /// True, to create a shard key when using with cosmos db.
        /// </summary>
        public bool CreateShardKeyForCosmos { get; set; }

        MongoDBOptions IOptions<MongoDBOptions>.Value => this;

        internal void Validate(string name = null)
        {
            var typeName = GetType().Name;

            if (!string.IsNullOrWhiteSpace(typeName))
            {
                typeName = $"{typeName} for {name}";
            }

            if (string.IsNullOrWhiteSpace(DatabaseName))
            {
                throw new OrleansConfigurationException($"Invalid {typeName} values for {nameof(DatabaseName)}. {nameof(DatabaseName)} is required.");
            }
        }
    }
}
