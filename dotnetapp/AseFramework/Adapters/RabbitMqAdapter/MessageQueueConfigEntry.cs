namespace DotnetApp.AseFramework.Adapters.RabbitMqAdapter
{
    #region using directives

    using DotnetApp.AseFramework.AbstractArchitecture.Definitions;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    #endregion

    /// <summary>
    ///     The message queue config entry.
    /// </summary>
    public class MessageQueueConfigEntry : IConfigEntry
    {
        /// <summary>
        ///     The extra.
        /// </summary>
        public string Extra => "eins";

        /// <summary>
        ///     Gets or sets the hostname.
        /// </summary>
        public string Hostname { get; set; }

        /// <summary>
        ///     Gets or sets the purpose.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ProgramConfigKeys Purpose { get; set; }
    }
}