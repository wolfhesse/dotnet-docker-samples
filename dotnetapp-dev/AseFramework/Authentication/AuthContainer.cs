#region

#endregion

namespace DotnetApp.AseFramework.Authentication
{
    using System;
    using System.Text;

    public class AuthContainer
    {
        public string Key { get; set; }
        public string Secret { get; set; }

        public string FnBasicAuthHeader()
        {
            // Basic Auth Header
            var svcCredentials = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                .GetBytes(this.Key + ":" + this.Secret));
            return svcCredentials;
        }

        public string ToDumpString()
        {
            var sb = new StringBuilder(this.ToString());
            sb.Append($"\n\t| Key: {this.Key}");
            sb.Append($"\n\t| Secret: {this.Secret}");
            return sb.ToString();
        }

//        request.Headers.Add("Authorization", "Basic " + svcCredentials);
    }
}