namespace DotnetApp.EnvironmentSetup
{
    using DotnetApp.AseFramework.Definitions;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class MessageQueueConfigEntry : IConfigEntry, AseFrameworkDefinitionsHead
    {
        public MessageQueueConfigEntry(string hostname)
        {
            this.Hostname = hostname;
            this.Purpose = ProgramConfigKeys.MessageQueue;
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