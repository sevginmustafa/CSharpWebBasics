using SUS.HTTP.Enums;

namespace SUS.MvcFramework
{
    public abstract partial class BaseHttpAttribute
    {
        public class HttpGetAttribute : BaseHttpAttribute
        {
            public HttpGetAttribute()
            {

            }

            public HttpGetAttribute(string url)
            {
                this.Url = url;
            }
            public override HttpMethod Method => HttpMethod.Get;
        }
    }
}
