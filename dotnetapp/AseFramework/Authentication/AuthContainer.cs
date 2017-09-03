namespace DotnetApp.AseFramework.Authentication
{
    #region using directives

    using System;
    using System.Text;

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
                Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(this.Key + ":" + this.Secret));
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
            var sb = new StringBuilder(this.ToString());
            sb.Append($"\n\t| Key: {this.Key}");
            sb.Append($"\n\t| Secret: {this.Secret}");
            return sb.ToString();
        }

        // request.Headers.Add("Authorization", "Basic " + svcCredentials);
    }
}