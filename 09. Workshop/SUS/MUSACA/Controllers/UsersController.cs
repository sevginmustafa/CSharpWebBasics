using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Login()
        {
            return this.View();
        }
    }
}
