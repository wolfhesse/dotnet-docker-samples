using ClassLibrary.AseFramework.Definitions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DNS.Programs
{
    public class MessageQueueConfigEntry : IConfigEntry
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ProgramConfigKeys Purpose { get; set; }
        public string Hostname { get; set; }
    }
}