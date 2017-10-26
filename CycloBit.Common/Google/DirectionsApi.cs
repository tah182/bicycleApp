using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System;
using System.Text;

namespace CycloBit.Common.Google {
    public static class DirectionsApi {
        public static int TIMEOUT => 30_000;
        public static string BASE_MAP_URI => @"https://maps.googleapis.com/maps/api/directions/json?";
        public static Stopwatch stopwatch = new Stopwatch();

        #region helpers
        private static T GetGoogleAPIResult<T>(string requestUri) {
            HttpWebRequest webRequest = WebRequest.Create(requestUri) as HttpWebRequest;

            webRequest.Timeout = TIMEOUT;
            webRequest.Method = "GET";

            stopwatch.Start();
            var googleAPIResult = GetGoogleAPIJsonResponse(webRequest);
            stopwatch.Stop();
            
            var resultsFromGoogleAPI = new JsonSerializer().Deserialize<T>(googleAPIResult.jsonResult);
            return resultsFromGoogleAPI;
        }
        
        private static GoogleApiResult GetGoogleAPIJsonResponse(HttpWebRequest webRequest, string requestBody) {
            string requestCacheKey = webRequest.RequestUri.ToString();
            string jsonText;
            GoogleApiStatus status = null;

            HttpContext currentHttpContext = HttpContext.Current;
            if (currentHttpContext != null && currentHttpContext.Cache[requestCacheKey] != null) {
                jsonText = HttpContext.Current.Cache[requestCacheKey].ToString();
                // we only cache if status was previously OK
                status = new GoogleApiStatus();
                status.status = "OK";
            } else {
                if (webRequest.Method != "GET") {
                    //handle post data - throw exception if not provided, otherwise add to request
                    if (string.IsNullOrEmpty(requestBody))
                        throw new ApplicationException("Attempting to cache POST requset with empty request Body");

                    requestCacheKey += requestBody;

                    byte[] buffer = Encoding.UTF8.GetBytes(requestBody);
                    webRequest.ContentLength = buffer.Length;
                    using (var stream = webRequest.GetRequestStream()) {
                        stream.Write(buffer, 0, buffer.Length);
                        stream.Close();
                    }
                }

                webRequest.ServicePoint.Expect100Continue = false;

                WebResponse response = webRequest.GetResponse();

                using (var stream = response.GetResponseStream()) {
                    using (var r = new System.IO.StreamReader(stream)) {
                        jsonText = r.ReadToEnd();
                    }
                }

                var jss = new JsonSerializer();
                status = jss.Deserialize<GoogleApiStatus>(jsonText);

                //URL shortener API doesn't return status, so we we'll check for a non-null id being returned
                if (status.status == null && webRequest.RequestUri.ToString().ToLower().Contains("urlshortener")) 
                    status.status = jss.Deserialize<UrlShortenerResult>(jsonText).id != null ? "OK" : "ERROR";

                //siteverify API doesn't return status, so we we'll check for a response
                if (status.status == null && webRequest.RequestUri.ToString().ToLower().Contains("siteverify"))
                    status.status = jss.Deserialize<GoogleCaptchaVerificationStatus>(jsonText).Success ? "OK" : "ERROR";

                if (status.status == "OK")
                    RedCap.Common.Caching.CachingController.InsertCache(jsonText, requestCacheKey, TimeSpan.FromHours(24));
                else {
                    System.Diagnostics.StackTrace stack = new System.Diagnostics.StackTrace(true);
                    System.Diagnostics.StackFrame[] frames = stack.GetFrames();
                    string stackName = string.Empty;
                    foreach (System.Diagnostics.StackFrame sf in frames) {
                        System.Reflection.MethodBase method = sf.GetMethod();
                        stackName += (method.Name + "|");
                    }
                }
            }

            return new GoogleApiResult { status=status, jsonResult=jsonText };
        }

        private static GoogleApiResult GetGoogleAPIJsonResponse(HttpWebRequest webRequest) {
            return GetGoogleAPIJsonResponse(webRequest, string.Empty);
        }

        #endregion
    }
}