// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExtraRestRequestExtensions.cs" company="">
//   
// </copyright>
// <summary>
//   The extra rest request extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.AseFramework.Authentication
{
    #region

    using RestSharp;
    using RestSharp.Authenticators;
    using RestSharp.Authenticators.OAuth;

    #endregion

    /// <summary>
    /// The extra rest request extensions.
    /// </summary>
    public static class ExtraRestRequestExtensions
    {
        /// <summary>
        /// The build o auth 1 query string.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <param name="client">
        /// The client.
        /// </param>
        /// <param name="consumerKey">
        /// The consumer key.
        /// </param>
        /// <param name="consumerSecret">
        /// The consumer secret.
        /// </param>
        /// <returns>
        /// The <see cref="RestRequest"/>.
        /// </returns>
        public static RestRequest BuildOAuth1QueryString(
            this RestRequest request,
            RestClient client,
            string consumerKey,
            string consumerSecret)
        {
            var auth = OAuth1Authenticator.ForRequestToken(consumerKey, consumerSecret);
            auth.ParameterHandling = OAuthParameterHandling.UrlOrPostParameters;
            auth.Authenticate(client, request);

            // convert all these oauth params from cookie to querystring
            request.Parameters.ForEach(
                x =>
                    {
                        if (x.Name.StartsWith("oauth_")) x.Type = ParameterType.QueryString;
                    });
            return request;
        }
    }
}