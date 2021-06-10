using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.Controllers
{
   public class ProductsController:Controller
    {
        public HttpResponse Add()
        {
            return this.View();
        }

        public HttpResponse Details()
        {
            return this.View();
        }
    }
}
