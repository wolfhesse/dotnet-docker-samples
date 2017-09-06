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
    public class MessageQueueConfigEntry : IConfigEntry, IAseFrameworkDefinitionsHead
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
        private string Hostname { get; }

        /// <summary>
        ///     Gets or sets the purpose.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        private ProgramConfigKeys Purpose { get; }
    }
}