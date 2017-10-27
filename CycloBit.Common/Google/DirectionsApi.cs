using System;
using System.Diagnostics;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

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
            
            var resultsFromGoogleAPI = JsonConvert.DeserializeObject<T>(googleAPIResult.jsonResult);
            return resultsFromGoogleAPI;
        }
        
        private static GoogleApiResult GetGoogleAPIJsonResponse(HttpWebRequest webRequest) {
            string jsonText;
            GoogleApiStatus status = null;

            if (webRequest.Method != "GET") {
                byte[] buffer = Encoding.UTF8.GetBytes(string.Empty);
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

            status = JsonConvert.DeserializeObject<GoogleApiStatus>(jsonText);

            //URL shortener API doesn't return status, so we we'll check for a non-null id being returned
            if (status.status == null && webRequest.RequestUri.ToString().ToLower().Contains("urlshortener")) 
                status.status = JsonConvert.DeserializeObject<UrlShortenerResult>(jsonText).id != null ? "OK" : "ERROR";

            return new GoogleApiResult { status = status, jsonResult = jsonText };
        }

        #endregion
    }
}