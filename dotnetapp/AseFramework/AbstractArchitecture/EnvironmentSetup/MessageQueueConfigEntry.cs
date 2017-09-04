#region using directives

using DotnetApp.AseFramework.AbstractArchitecture.Definitions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace DotnetApp.AseFramework.AbstractArchitecture.EnvironmentSetup
{
    #region using directives

    #endregion

    /// <summary>
    ///     The message queue config entry.
    /// </summary>
    public class MessageQueueConfigEntry : IConfigEntry, AseFrameworkDefinitionsHead
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MessageQueueConfigEntry" /> class.
        /// </summary>
        /// <param name="hostname">
        ///     The hostname.
        /// </param>
        public MessageQueueConfigEntry(string hostname)
        {
            Hostname = hostname;
            Purpose = ProgramConfigKeys.MessageQueue;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MessageQueueConfigEntry" /> class.
        /// </summary>
        public MessageQueueConfigEntry()
        {
            // todo: deprecated, use c;tor version
        }

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