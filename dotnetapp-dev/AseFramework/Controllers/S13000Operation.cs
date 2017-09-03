#region

using System.Net;

#endregion

namespace dotnetapp.AseFramework.Controllers
{
    public static class S13000Operation
    {
        public static string Get_statement_1()
        {
            const string stmt = "200 rq/s ist 17 mio rq/d";
            return stmt;
        }

//        internal static void fetch_s13000(string requestUriString, string dataDResultTxt, string callParams = null)
//        {
//            Debug.WriteLine($"fetch_s13000 w/ {requestUriString} .. {dataDResultTxt} .. {callParams}");
//            var r1 = "";
//            var r2 = "n/a";
//            var r3 = "n/a";
//
//            var sstart = DateTime.Now;
//            if (null != callParams)
//            {
//                WebResponse Target1() => Get1(requestUriString, callParams);
//
//                WebResponse myResponse1;
//
//                var t1 = new Thread(() =>
//                {
//                    myResponse1 = Target1();
////            if (myResponse1?.GetResponseStream() == null) return;
//                    var rst = myResponse1.GetResponseStream();
//                    if (rst == null) return;
//                    using (var sr = new StreamReader(rst))
//                    {
//                        r1 = sr.ReadToEnd();
//                        sr.Close();
//                    }
//                });
//                t1.Start();
//                t1.Join();
//            }
//            else
//            {
//                WebResponse Target1() => Get1(requestUriString, "?1");
//                WebResponse Target2() => Get1(requestUriString, "?2");
//                WebResponse Target3() => Get1(requestUriString, "?3");
//
//                WebResponse myResponse1, myResponse2, myResponse3;
//                var t1 = new Thread(() =>
//                {
//                    myResponse1 = Target1();
////            if (myResponse1?.GetResponseStream() == null) return;
//                    var rst = myResponse1.GetResponseStream();
//                    if (rst == null) return;
//                    using (var sr = new StreamReader(rst))
//                    {
//                        r1 = sr.ReadToEnd();
//                        sr.Close();
//                    }
//                });
//                var t2 = new Thread(() =>
//                {
//                    myResponse2 = Target2();
//                    var rst = myResponse2.GetResponseStream();
//                    if (rst == null) return;
//                    using (var sr = new StreamReader(rst))
//                    {
//                        r2 = sr.ReadToEnd();
//                        sr.Close();
//                    }
//                });
//                var t3 = new Thread(() =>
//                {
//                    myResponse3 = Target3();
//                    var rst = myResponse3.GetResponseStream();
//                    if (rst == null) return;
//                    using (var sr = new StreamReader(rst))
//                    {
//                        r3 = sr.ReadToEnd();
//                        sr.Close();
//                    }
//                });
//
//
//                t1.Start();
//                t2.Start();
//                t3.Start();
//
//                t1.Join();
//                t2.Join();
//                t3.Join();
//            }
//            var sfin = DateTime.Now;
//            var sdur = sfin - sstart;
//
//            using (var sw = new StreamWriter(dataDResultTxt))
//            {
//                sw.WriteLine(get_statement_1());
//                sw.WriteLine($"{DateTimeOffset.Now} - result");
//                sw.WriteLine($"start: {sstart} / sstart.ticks: {sstart.Ticks}");
//                sw.WriteLine($"fin: {sfin} / sfin.ticks: {sfin.Ticks}");
//                sw.WriteLine($"dur: {sdur.Ticks} ticks, ({sdur.Ticks / 10000} milliseconds)");
//                sw.WriteLine($"r1: {r1}");
//                sw.WriteLine($"r2: {r2}");
//                sw.WriteLine($"r3: {r3}");
//            }
//        }


        private static WebResponse Get1(string requestUriString, string s)
        {
            var myRequest = WebRequest.Create($"{requestUriString}{s}");
            var myResponse = myRequest.GetResponse();
            return myResponse;
        }

        public class Api
        {
            public const string CallParamsKey = "call_params_key";
            public const string ResultFilePathKey = "result_file_path_key";

            public const string UriKey = "uri_key";

//            public static void Fetch(Dictionary<string, string> options)
//            {
//                fetch_s13000_p(options[UriKey], options[ResultFilePathKey], options[CallParamsKey]);
//            }
        }

//        private static void fetch_s13000_p(string s, string s1, string s2)
//        {
//            fetch_s13000(s, s1, s2);
//        }
    }
}