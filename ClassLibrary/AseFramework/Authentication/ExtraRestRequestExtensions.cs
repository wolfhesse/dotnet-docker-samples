using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth;

namespace ClassLibrary.AseFramework.Authentication
{
    public static class ExtraRestRequestExtensions
    {
        public static RestRequest BuildOAuth1QueryString(this RestRequest request, RestClient client,
            string consumerKey, string consumerSecret)
        {
            var auth = OAuth1Authenticator.ForRequestToken(consumerKey, consumerSecret);
            auth.ParameterHandling = OAuthParameterHandling.UrlOrPostParameters;
            auth.Authenticate(client, request);
            //convert all these oauth params from cookie to querystring
            request.Parameters.ForEach(x =>
            {
                if (x.Name.StartsWith("oauth_"))
                    x.Type = ParameterType.QueryString;
            });
            return request;
        }
    }
}