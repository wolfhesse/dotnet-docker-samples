#region using directives

using System;
using System.Text;

#endregion

namespace DotnetApp.AseFramework.Authentication
{
    #region using directives

    #endregion

    /// <summary>
    ///     The auth container.
    /// </summary>
    public class AuthContainer
    {
        /// <summary>
        ///     Gets or sets the key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///     Gets or sets the secret.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        ///     The fn basic auth header.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        public string FnBasicAuthHeader()
        {
            // Basic Auth Header
            var svcCredentials =
                Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(Key + ":" + Secret));
            return svcCredentials;
        }

        /// <summary>
        ///     The to dump string.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        public string ToDumpString()
        {
            var sb = new StringBuilder(ToString());
            sb.Append($"\n\t| Key: {Key}");
            sb.Append($"\n\t| Secret: {Secret}");
            return sb.ToString();
        }

        // request.Headers.Add("Authorization", "Basic " + svcCredentials);
    }
}