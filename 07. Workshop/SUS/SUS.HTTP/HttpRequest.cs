using System;
using System.Text;
using System.Linq;
using SUS.HTTP.Enums;
using System.Collections.Generic;
using System.Net;

namespace SUS.HTTP
{
    public class HttpRequest
    {
        public static IDictionary<string, Dictionary<string, string>> Sessions
            = new Dictionary<string, Dictionary<string, string>>();

        public HttpRequest(string requestString)
        {
            var lines = requestString.Split(new string[] { HttpConstants.NEW_LINE }, StringSplitOptions.None);

            var headerLine = lines[0];

            var headerLineParts = headerLine.Split();

            this.Method = (HttpMethod)Enum.Parse(typeof(HttpMethod), headerLineParts[0], true);
            this.Path = headerLineParts[1];

            int lineIndex = 1;
            bool isInHeaders = true;

            var bodyBuilder = new StringBuilder();

            while (lineIndex < lines.Length)
            {
                var line = lines[lineIndex];

                lineIndex++;

                if (string.IsNullOrWhiteSpace(line))
                {
                    isInHeaders = false;

                    continue;
                }

                if (isInHeaders)
                {
                    this.Headers.Add(new Header(line));
                }
                else
                {
                    bodyBuilder.AppendLine(line);
                }
            }

            if (this.Headers.Any(h => h.Name == HttpConstants.REQUEST_COOKIE_HEADER))
            {
                var cookiesAsString = this.Headers.FirstOrDefault(h => h.Name == HttpConstants.REQUEST_COOKIE_HEADER).Value;

                var cookies = cookiesAsString.Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var cookie in cookies)
                {
                    this.Cookies.Add(new Cookie(cookie));
                }
            }

            var sessionCookie = this.Cookies.FirstOrDefault(x => x.Name == HttpConstants.SESSION_COOKIE_NAME);

            if (sessionCookie == null || !Sessions.ContainsKey(sessionCookie.Value))
            {
                var sessionId = Guid.NewGuid().ToString();
                this.Session = new Dictionary<string, string>();
                Sessions.Add(sessionId, this.Session);
                this.Cookies.Add(new Cookie(HttpConstants.SESSION_COOKIE_NAME, sessionId));
            }
            else
            {
                this.Session = Sessions[sessionCookie.Value];
            }

            this.Body = bodyBuilder.ToString();

            var parameters = this.Body.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries); ;

            foreach (var parameter in parameters)
            {
                var parameterParts = parameter.Split(new[] { '=' }, 2);

                var name = parameterParts[0];
                var value = WebUtility.UrlDecode(parameterParts[1]);

                if (!FormData.ContainsKey(name))
                {
                    FormData.Add(name, value);
                }
            }
        }

        public string Path { get; set; }

        public HttpMethod Method { get; set; }

        public ICollection<Header> Headers { get; set; }
            = new List<Header>();

        public ICollection<Cookie> Cookies { get; set; }
            = new List<Cookie>();

        public Dictionary<string, string> Session { get; set; }

        public IDictionary<string, string> FormData { get; set; }
        = new Dictionary<string, string>();

        public string Body { get; set; }
    }
}