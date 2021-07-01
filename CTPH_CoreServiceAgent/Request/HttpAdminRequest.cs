namespace CTPH_CoreServiceAgent.Request
{
    public class HttpAdminRequest
    {
        private string _urlbase; 

        public HttpAdminRequest(string urlbase)
        {
            _urlbase = urlbase;
        }

        public string body { get; set; }

        public string getUrl(string url)
        {
            return _urlbase + @"/" + url;
        }

        public string putUrl(string url)
        {
            return _urlbase + @"/" + url;
        }
    }
}
