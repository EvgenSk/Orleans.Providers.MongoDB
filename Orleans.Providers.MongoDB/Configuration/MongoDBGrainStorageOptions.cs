// ReSharper disable InheritdocConsiderUsage

using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;

namespace Orleans.Providers.MongoDB.Configuration
{
    /// <summary>
    /// Option to configure MongoDB Storage.
    /// </summary>
    public class MongoDBGrainStorageOptions : MongoDBOptions, IOptions<MongoDBGrainStorageOptions>
    {
        public MongoDBGrainStorageOptions()
        {
            CollectionPrefix = "Grains";
        }

        public Action<JsonSerializerSettings> ConfigureJsonSerializerSettings { get; set; }

        MongoDBGrainStorageOptions IOptions<MongoDBGrainStorageOptions>.Value => this;
    }
}
