using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Controllers
{
    public class TripsController:Controller
    {
        public HttpResponse All()
        {
            return this.View();
        }

        public HttpResponse Add()
        {
            return this.View();
        }
    }
}
