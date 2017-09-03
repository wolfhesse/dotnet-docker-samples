// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageQueueConfigEntry.cs" company="ase">
//   mit
// </copyright>
// <summary>
//   The message queue config entry.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.EnvironmentSetup
{
    #region

    using DotnetApp.AseFramework.Definitions;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    #endregion

    /// <summary>
    ///     The message queue config entry.
    /// </summary>
    public class MessageQueueConfigEntry : IConfigEntry, AseFrameworkDefinitionsHead
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageQueueConfigEntry"/> class.
        /// </summary>
        /// <param name="hostname">
        /// The hostname.
        /// </param>
        public MessageQueueConfigEntry(string hostname)
        {
            this.Hostname = hostname;
            this.Purpose = ProgramConfigKeys.MessageQueue;
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