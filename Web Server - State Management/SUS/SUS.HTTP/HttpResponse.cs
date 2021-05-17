using System.Collections.Generic;

namespace SUS.HTTP
{
    public class HttpResponse
    {
        public HttpResponse()
        {
            Headers = new List<Header>();
            Cookies = new List<Cookie>();


        }


        public HttpStatusCode StatusCode { get; set; }

        public ICollection<Header> Headers { get; set; }

        public ICollection<Cookie> Cookies { get; set; }

        public string Body { get; set; }
    }
}