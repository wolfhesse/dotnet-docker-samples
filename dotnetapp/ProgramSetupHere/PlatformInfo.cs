// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlatformInfo.cs" company="">
//   
// </copyright>
// <summary>
//   The platform info.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DnsLib.ProgramSetupHere
{
    #region using directives

    using System;
    using System.IO;

    using DnsLib.AseFramework.AbstractArchitecture.EnvironmentSetup;
    using DnsLib.AseFramework.Authentication;

    using WooCommerceNET;

    #endregion

    /// <summary>The platform info.</summary>
    public static class PlatformInfo
    {
        /// <summary>The api endpoint products.</summary>
        internal static string ApiEndpointProducts => "wp-json/wc/v1/products";

        /// <summary>The json path data d content.</summary>
        internal static string JsonPathDataDContent =>
            Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/data.d/DNS/content.json";

        /// <summary>The json path data d products.</summary>
        internal static string JsonPathDataDProducts =>
            Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/data.d/DNS/products.json";

        /// <summary>The rcs 2 json api endpoint.</summary>
        internal static string Rcs2JsonApiEndpoint => "http://rcs2.base.wolfspool.at/wp-json";

        /// <summary>The rcs 2 rest api endpoint.</summary>
        internal static string Rcs2RestApiEndpoint => "http://rcs2.base.wolfspool.at/wp-json/wc/v2/";

        /// <summary>The test apo r 1 rest api endpoint.</summary>
        internal static string TestApoR1RestApiEndpoint => "http://test.aposites.at/r1/wp-json/wc/v2/";

        /// <summary>The url rcs 1.</summary>
        internal static string UrlRcs1 => "http://rcs1.base.wolfspool.at";

        /// <summary>The url rcs 2.</summary>
        internal static string UrlRcs2 => "http://rcs2.base.wolfspool.at";

        /// <summary>The url test apo r 1.</summary>
        internal static string UrlTestApoR1 => "http://test.aposites.at/r1";

        /// <summary>The get result stream writer.</summary>
        /// <returns>The <see cref="StreamWriter"/>.</returns>
        internal static StreamWriter GetResultStreamWriter()
        {
            var datap = GetResultDataPath();
            var dataf = datap + "/ConsoleApplication.reftext.res.txt";

            var sw = new StreamWriter(dataf, true);
            return sw;
        }

        /// <summary>The get result data path.</summary>
        /// <returns>The <see cref="string"/>.</returns>
        private static string GetResultDataPath()
        {
            var datap = AseEnvironmentNames.GetDataD() + "/DNS";
            Directory.CreateDirectory(datap);
            return datap;
        }

        /// <summary>The ase auth engine.</summary>
        public class AseAuthEngine
        {
            /// <summary>The rcs 1_consumer_auth.</summary>
            /// <param name="auth">The auth.</param>
            internal static void rcs1_consumer_auth(AuthContainer auth = null)
            {
                const string consumerKey = "ck_862c118d151446ea3690e8e9baeb8bf1c6c8c604";
                const string consumerSecret = "cs_a3f27722e3267a2eff9d9e11f1f7349022a49eef";
                fill_auth_container(auth, consumerKey, consumerSecret);
            }

            /// <summary>The rcs 2_consumer_auth.</summary>
            /// <param name="auth">The auth.</param>
            internal static void rcs2_consumer_auth(AuthContainer auth = null)
            {
                const string consumerKey = "ck_56cf1ec961a9e96398ccc0e60062d42a54c6ed6a";
                const string consumerSecret = "cs_33162532c283749869b2bed38c997487fe4be7bd";
                fill_auth_container(auth, consumerKey, consumerSecret);
            }

            /// <summary>The test_aposites_r 1_consumer_auth.</summary>
            /// <param name="auth">The auth.</param>
            internal static void test_aposites_r1_consumer_auth(AuthContainer auth = null)
            {
                const string consumerKey = "ck_e94c1e01464fea83210ec711eab582d892011d20";
                const string consumerSecret = "cs_ea4526d2e0e3711057fe9d25eeec20e917284f52";
                fill_auth_container(auth, consumerKey, consumerSecret);
            }

            /// <summary>The fill_auth_container.</summary>
            /// <param name="auth">The auth.</param>
            /// <param name="consumerKey">The consumer key.</param>
            /// <param name="consumerSecret">The consumer secret.</param>
            private static void fill_auth_container(AuthContainer auth, string consumerKey, string consumerSecret)
            {
                if (null == auth) return;
                auth.Key = consumerKey;
                auth.Secret = consumerSecret;
            }
        }

        /// <summary>The woo stuff auth adapter.</summary>
        public class WooStuffAuthAdapter
        {
            /// <summary>The fn auth for rcs 2.</summary>
            /// <returns>The <see cref="AuthContainer"/>.</returns>
            public static AuthContainer FnAuthForRcs2()
            {
                var auth = new AuthContainer();
                AseAuthEngine.rcs2_consumer_auth(auth);
                return auth;
            }

            /// <summary>The fn auth for test apo r 1.</summary>
            /// <returns>The <see cref="AuthContainer"/>.</returns>
            public static AuthContainer FnAuthForTestApoR1()
            {
                var auth = new AuthContainer();
                AseAuthEngine.test_aposites_r1_consumer_auth(auth);
                return auth;
            }

            /// <summary>The fn rest api rcs 2.</summary>
            /// <returns>The <see cref="RestAPI"/>.</returns>
            public static RestAPI FnRestApiRcs2()
            {
                var auth = FnAuthForRcs2();
                var restApi = new RestAPI(Rcs2RestApiEndpoint, $"{auth.Key}", $"{auth.Secret}");
                return restApi;
            }

            /// <summary>The fn rest api test apo r 1.</summary>
            /// <returns>The <see cref="RestAPI"/>.</returns>
            public static RestAPI FnRestApiTestApoR1()
            {
                var auth = FnAuthForTestApoR1();
                var restApi = new RestAPI(TestApoR1RestApiEndpoint, $"{auth.Key}", $"{auth.Secret}");
                return restApi;
            }

            /// <summary>The rest api default.</summary>
            /// <param name="restApiEndpoint">The rest api endpoint.</param>
            /// <param name="auth">The auth.</param>
            /// <returns>The <see cref="RestAPI"/>.</returns>
            public static RestAPI RestApiDefault(string restApiEndpoint = null, AuthContainer auth = null)
            {
                restApiEndpoint = restApiEndpoint ?? Rcs2RestApiEndpoint;
                auth = auth ?? FnAuthForRcs2();

                return new RestAPI(restApiEndpoint, $"{auth.Key}", $"{auth.Secret}");
            }
        }
    }
}