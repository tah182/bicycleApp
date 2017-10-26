namespace CycloBit.Common.Google {
    public class GoogleApiResult {
        public GoogleApiStatus status { get; set; }
        public string jsonResult { get; set; }
    }

    public class GoogleApiStatus {
        public string status { get; set; }
    }
}