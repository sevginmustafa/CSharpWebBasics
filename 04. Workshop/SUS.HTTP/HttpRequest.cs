using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SUS.HTTP
{
    public class HttpRequest
    {
        public HttpRequest(string requestString)
        {
            Headers = new List<Header>();
            Cookies = new List<Cookie>();

            var lines = requestString.Split(new string[] { HttpConstants.NewLine }, StringSplitOptions.None);

            var headerLines = lines[0].Split();

            Method = (HttpMethod)Enum.Parse(typeof(HttpMethod), headerLines[0], true);
            Path = headerLines[1];

            StringBuilder bodyBuilder = new StringBuilder();
            bool isInHeaders = true;

            for (int i = 1; i < lines.Length; i++)
            {
                if (String.IsNullOrWhiteSpace(lines[i]))
                {
                    isInHeaders = false;
                    continue;
                }

                if (isInHeaders)
                {
                    Headers.Add(new Header(lines[i]));
                }
                else
                {
                    bodyBuilder.AppendLine(lines[i]);
                }
            }

            if (Headers.Any(x => x.Name == HttpConstants.RequestCookieHeader))
            {
                var cookiesAsString = Headers.FirstOrDefault(x => x.Name == HttpConstants.RequestCookieHeader).Value;

                var cookies = cookiesAsString.Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var cookie in cookies)
                {
                    Cookies.Add(new Cookie(cookie));
                }
            }

            Body = bodyBuilder.ToString();
        }

        public string Path { get; set; }

        public HttpMethod Method { get; set; }

        public ICollection<Header> Headers { get; set; }

        public ICollection<Cookie> Cookies { get; set; }

        public string Body { get; set; }
    }
}