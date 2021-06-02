using SUS.HTTP.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.MvcFramework
{
    public abstract partial class BaseHttpAttribute : Attribute
    {
        public string Url { get; set; }

        public abstract HttpMethod Method { get; }
    }
}
