// ReSharper disable InheritdocConsiderUsage

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Orleans.Providers.MongoDB.Configuration
{
    /// <summary>
    /// Option to configure MongoDB Storage.
    /// </summary>
    public class MongoDBGrainStorageOptions : MongoDBOptions
    {
        public MongoDBGrainStorageOptions()
        {
            CollectionPrefix = "Grains";
        }

        /// <summary>
        /// Expiration spans for specific grain types.
        /// </summary>
        public Dictionary<string, TimeSpan> GrainTypesExpirations { get; set; }

        public Action<JsonSerializerSettings> ConfigureJsonSerializerSettings { get; set; }
    }
}
