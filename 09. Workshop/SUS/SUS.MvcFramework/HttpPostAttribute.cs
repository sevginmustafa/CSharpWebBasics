using SUS.HTTP.Enums;

namespace SUS.MvcFramework
{
    public abstract partial class BaseHttpAttribute
    {
        public class HttpPostAttribute : BaseHttpAttribute
        {
            public HttpPostAttribute()
            {

            }

            public HttpPostAttribute(string url)
            {
                this.Url = url;
            }

            public override HttpMethod Method => HttpMethod.Post;
        }
    }
}
