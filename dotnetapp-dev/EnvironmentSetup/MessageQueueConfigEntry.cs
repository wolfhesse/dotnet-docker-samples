using dotnetapp.AseFramework.Definitions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace dotnetapp.EnvironmentSetup
{
    public class MessageQueueConfigEntry : IConfigEntry, AseFrameworkDefinitionsHead
    {
        public MessageQueueConfigEntry(string hostname)
        {
            Hostname = hostname;
            Purpose = ProgramConfigKeys.MessageQueue;
        }

        public MessageQueueConfigEntry()
        {
            // todo: deprecated, use c;tor version
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public ProgramConfigKeys Purpose { get; set; }
        public string Hostname { get; set; }
    }
}