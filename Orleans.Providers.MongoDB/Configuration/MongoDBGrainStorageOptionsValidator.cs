using Microsoft.Extensions.Options;

namespace Orleans.Providers.MongoDB.Configuration
{
    public sealed class MongoDBGrainStorageOptionsValidator : IConfigurationValidator
    {
        private readonly MongoDBGrainStorageOptions options;
        private readonly string name;

        public MongoDBGrainStorageOptionsValidator(IOptions<MongoDBGrainStorageOptions> options, string name)
        {
            this.options = options.Value;
            this.name = name;
        }

        public void ValidateConfiguration()
        {
            options.Validate(name);
        }
    }
}
