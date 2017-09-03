#region

#endregion

namespace DotnetApp.RabbitMqAdapter
{
    using DotnetApp.AseFramework.Definitions;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class MessageQueueConfigEntry : IConfigEntry
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ProgramConfigKeys Purpose { get; set; }

        public string Hostname { get; set; }

        public string Extra => "eins";
    }
}