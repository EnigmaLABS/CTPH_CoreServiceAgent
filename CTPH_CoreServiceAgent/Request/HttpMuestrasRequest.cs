using System;
using System.Collections.Generic;
using System.Text;

namespace CTPH_CoreServiceAgent.Request
{
    public class HttpMuestrasRequest
    {
        private string _urlbase; // = @"https://localhost:44355/api/Muestras";

        public HttpMuestrasRequest(string urlbase)
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
