namespace DnsLib.ProgramSetupHere
{
    #region using directives

    using System;
    using System.IO;

    using DnsLib.AseFramework.AbstractArchitecture.EnvironmentSetup;
    using DnsLib.AseFramework.Authentication;

    using WooCommerceNET;

    #endregion

    public static class PlatformInfo
    {
        internal static string ApiEndpointProducts => "wp-json/wc/v1/products";

        internal static string JsonPathDataDContent =>
            Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/data.d/DNS/content.json";

        internal static string JsonPathDataDProducts =>
            Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/data.d/DNS/products.json";

        internal static string Rcs2JsonApiEndpoint => "http://rcs2.base.wolfspool.at/wp-json";

        internal static string Rcs2RestApiEndpoint => "http://rcs2.base.wolfspool.at/wp-json/wc/v2/";

        internal static string TestApoR1RestApiEndpoint => "http://test.aposites.at/r1/wp-json/wc/v2/";

        internal static string UrlRcs1 => "http://rcs1.base.wolfspool.at";

        internal static string UrlRcs2 => "http://rcs2.base.wolfspool.at";

        internal static string UrlTestApoR1 => "http://test.aposites.at/r1";

        internal static StreamWriter GetResultStreamWriter()
        {
            var datap = GetResultDataPath();
            var dataf = datap + "/ConsoleApplication.reftext.res.txt";

            var sw = new StreamWriter(dataf, true);
            return sw;
        }

        private static string GetResultDataPath()
        {
            var datap = AseEnvironmentNames.GetDataD() + "/DNS";
            Directory.CreateDirectory(datap);
            return datap;
        }

        public class AseAuthEngine
        {
            internal static void rcs1_consumer_auth(AuthContainer auth = null)
            {
                const string consumerKey = "ck_862c118d151446ea3690e8e9baeb8bf1c6c8c604";
                const string consumerSecret = "cs_a3f27722e3267a2eff9d9e11f1f7349022a49eef";
                fill_auth_container(auth, consumerKey, consumerSecret);
            }

            internal static void rcs2_consumer_auth(AuthContainer auth = null)
            {
                const string consumerKey = "ck_56cf1ec961a9e96398ccc0e60062d42a54c6ed6a";
                const string consumerSecret = "cs_33162532c283749869b2bed38c997487fe4be7bd";
                fill_auth_container(auth, consumerKey, consumerSecret);
            }

            internal static void test_aposites_r1_consumer_auth(AuthContainer auth = null)
            {
                const string consumerKey = "ck_e94c1e01464fea83210ec711eab582d892011d20";
                const string consumerSecret = "cs_ea4526d2e0e3711057fe9d25eeec20e917284f52";
                fill_auth_container(auth, consumerKey, consumerSecret);
            }

            private static void fill_auth_container(AuthContainer auth, string consumerKey, string consumerSecret)
            {
                if (null == auth) return;
                auth.Key = consumerKey;
                auth.Secret = consumerSecret;
            }
        }

        public class WooStuffAuthAdapter
        {
            public static AuthContainer FnAuthForRcs2()
            {
                var auth = new AuthContainer();
                AseAuthEngine.rcs2_consumer_auth(auth);
                return auth;
            }

            public static AuthContainer FnAuthForTestApoR1()
            {
                var auth = new AuthContainer();
                AseAuthEngine.test_aposites_r1_consumer_auth(auth);
                return auth;
            }

            public static RestAPI FnRestApiRcs2()
            {
                var auth = FnAuthForRcs2();
                var restApi = new RestAPI(Rcs2RestApiEndpoint, $"{auth.Key}", $"{auth.Secret}");
                return restApi;
            }

            public static RestAPI FnRestApiTestApoR1()
            {
                var auth = FnAuthForTestApoR1();
                var restApi = new RestAPI(TestApoR1RestApiEndpoint, $"{auth.Key}", $"{auth.Secret}");
                return restApi;
            }

            public static RestAPI RestApiDefault(string restApiEndpoint = null, AuthContainer auth = null)
            {
                restApiEndpoint = restApiEndpoint ?? Rcs2RestApiEndpoint;
                auth = auth ?? FnAuthForRcs2();

                return new RestAPI(restApiEndpoint, $"{auth.Key}", $"{auth.Secret}");
            }
        }
    }
}