using System;
using System.Text;

namespace ClassLibrary.AseFramework.Authentication
{
    public class AuthContainer
    {
        public string Key { get; set; }
        public string Secret { get; set; }

        public string FnBasicAuthHeader()
        {
            // Basic Auth Header
            var svcCredentials = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                .GetBytes(Key + ":" + Secret));
            return svcCredentials;
        }

        public string ToDumpString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.Append($"\n\t| Key: {Key}");
            sb.Append($"\n\t| Secret: {Secret}");
            return sb.ToString();
        }

//        request.Headers.Add("Authorization", "Basic " + svcCredentials);
    }
}