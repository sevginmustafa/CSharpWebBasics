using Git.Controllers;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;

namespace Git
{
    public class StartUp : IMvcApplication
    {
        public void Configure(List<Route> routeTabble)
        {
            routeTabble.Add(new Route("/", HttpMethod.GET, new HomeController().Index));
            routeTabble.Add(new Route("/Users/Login", HttpMethod.GET, new UsersController().Login));
            routeTabble.Add(new Route("/Users/Register", HttpMethod.GET, new UsersController().Register));
            routeTabble.Add(new Route("/Repositories/All", HttpMethod.GET, new RepositoriesController().All));
            routeTabble.Add(new Route("/Repositories/Create", HttpMethod.GET, new RepositoriesController().Create));
            routeTabble.Add(new Route("/Commits/All", HttpMethod.GET, new CommitsController().All));
            routeTabble.Add(new Route("/Commits/Create", HttpMethod.GET, new CommitsController().Create));
            routeTabble.Add(new Route("/Commits/Create", HttpMethod.GET, new CommitsController().Create));
            //routeTabble.Add(new Route("/css/bootstrap.min.css", HttpMethod.GET, new StaticFilesController().BootstrapCss));
            routeTabble.Add(new Route("/css/demo.css", HttpMethod.GET, new StaticFilesController().DemoCss));
            routeTabble.Add(new Route("/css/lazy.css", HttpMethod.GET, new StaticFilesController().LazyCss));
            routeTabble.Add(new Route("/css/reset-css.css", HttpMethod.GET, new StaticFilesController().ResetCss));
            routeTabble.Add(new Route("/css/site.css", HttpMethod.GET, new StaticFilesController().SiteCss));
            routeTabble.Add(new Route("/css/text.css", HttpMethod.GET, new StaticFilesController().TextCss));
            routeTabble.Add(new Route("/js/demo.js", HttpMethod.GET, new StaticFilesController().DemoJs));
            routeTabble.Add(new Route("/js/lazy.js", HttpMethod.GET, new StaticFilesController().LazyJs));
            routeTabble.Add(new Route("/vendor/bootstrap/bootstrap.min.css", HttpMethod.GET, new StaticFilesController().BootstrapCss));
            routeTabble.Add(new Route("/vendor/bootstrap/bootstrap.min.js", HttpMethod.GET, new StaticFilesController().BootstrapJs));
            routeTabble.Add(new Route("/vendor/jquery/jquery.min.js", HttpMethod.GET, new StaticFilesController().JqueryJs));
            routeTabble.Add(new Route("/vendor/nouislider/css/nouislider.css", HttpMethod.GET, new StaticFilesController().NouisliderCss));
            routeTabble.Add(new Route("/vendor/nouislider/css/nouislider.min.css", HttpMethod.GET, new StaticFilesController().NouisliderMinCss));
            routeTabble.Add(new Route("/vendor/nouislider/js/nouislider.js", HttpMethod.GET, new StaticFilesController().NouisliderJs));
            routeTabble.Add(new Route("/vendor/nouislider/js/nouislider.min.js", HttpMethod.GET, new StaticFilesController().NouisliderMinJs));
            routeTabble.Add(new Route("/vendor/popper/popper.js", HttpMethod.GET, new StaticFilesController().PopperJs));
            routeTabble.Add(new Route("/vendor/popper/popper.min.js", HttpMethod.GET, new StaticFilesController().PopperMinJs));
            routeTabble.Add(new Route("/vendor/prism/prism.css", HttpMethod.GET, new StaticFilesController().PrismCss));
            routeTabble.Add(new Route("/vendor/prism/prism.js", HttpMethod.GET, new StaticFilesController().PrismJs));
        }

        public void ConfigureServices()
        {
        }
    }
}
