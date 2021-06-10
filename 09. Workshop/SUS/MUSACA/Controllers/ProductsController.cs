using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.Controllers
{
   public class ProductsController:Controller
    {
        public HttpResponse Add()
        {
            return this.View();
        }

        public HttpResponse Create()
        {
            return this.View();
        }
    }
}
