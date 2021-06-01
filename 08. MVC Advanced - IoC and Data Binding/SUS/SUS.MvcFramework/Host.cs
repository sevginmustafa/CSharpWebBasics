using SUS.HTTP;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using SUS.HTTP.Enums;
using System.Linq;
using System;
using System.Reflection;

namespace SUS.MvcFramework
{
    public class Host
    {
        public static async Task CreateHostAsync(IMvcApplication application, int port = 80)
        {
            var routeTable = new List<Route>();
            IServiceCollection serviceCollection = new ServiceCollection();

            application.ConfigureServices(serviceCollection);
            application.Configure(routeTable);

            AutoRegisterStaticFile(routeTable);
            AutoRegisterRoutes(routeTable, application, serviceCollection);


            IHttpServer server = new HttpServer(routeTable);

            await server.StartAsync(port);
        }

        private static void AutoRegisterRoutes(List<Route> routeTable, IMvcApplication application, IServiceCollection serviceCollection)
        {
            var controllerTypes = application.GetType().Assembly.GetTypes()
                 .Where(x => x.IsClass && !x.IsAbstract && x.IsSubclassOf(typeof(Controller)));

            foreach (var controllerType in controllerTypes)
            {
                var methods = controllerType.GetMethods()
                    .Where(x => x.IsPublic && !x.IsStatic && x.DeclaringType == controllerType
                    && !x.IsAbstract && !x.IsConstructor && !x.IsSpecialName);

                foreach (var method in methods)
                {
                    var url = "/" + controllerType.Name.Replace("Controller", string.Empty)
                         + "/" + method.Name;

                    var attribute = method.GetCustomAttributes(false)
                        .Where(x => x.GetType().IsSubclassOf(typeof(BaseHttpAttribute)))
                        .FirstOrDefault() as BaseHttpAttribute;

                    var httpMethod = HttpMethod.Get;

                    if (attribute != null)
                    {
                        httpMethod = attribute.Method;
                    }

                    if (!string.IsNullOrEmpty(attribute?.Url))
                    {
                        url = attribute.Url;
                    }

                    routeTable.Add(new Route(url, httpMethod, (request) => ExecuteAction(request, controllerType, method, serviceCollection)));
                }
            }
        }

        private static HttpResponse ExecuteAction(HttpRequest request, Type controllerType, MethodInfo action, IServiceCollection serviceCollection)
        {
            var instance = serviceCollection.CreateInstance(controllerType) as Controller;

            instance.Request = request;

            var arguments = new List<object>();

            var parameters = action.GetParameters();
            foreach (var parameter in parameters)
            {
                var parameterValue = GetParametersFromRequest(request, parameter.Name);
                arguments.Add(parameterValue);
            }

            var response = action.Invoke(instance, arguments.ToArray()) as HttpResponse;

            return response;
        }

        private static string GetParametersFromRequest(HttpRequest request, string parameterName)
        {
            if (request.FormData.ContainsKey(parameterName))
            {
                return request.FormData[parameterName];
            }

            if (request.QueryData.ContainsKey(parameterName))
            {
                return request.QueryData[parameterName];
            }

            return null;
        }

        private static void AutoRegisterStaticFile(List<Route> routeTable)
        {
            var staticFiles = Directory.GetFiles("wwwroot", "*", SearchOption.AllDirectories);

            foreach (var staticFile in staticFiles)
            {
                var path = staticFile.Replace("wwwroot", string.Empty)
                    .Replace("\\", "/");

                routeTable.Add(new Route(path, HttpMethod.Get, (request) =>
                {
                    var readFile = File.ReadAllBytes(staticFile);

                    var fileExtension = new FileInfo(staticFile).Extension;

                    var contentType = fileExtension switch
                    {
                        ".txt" => "text/plain",
                        ".html" => "text/html",
                        ".js" => "text/javascript",
                        ".css" => "text/css",
                        ".gif" => "image/gif",
                        ".png" => "image/png",
                        ".jpg" => "image/jpg",
                        ".jpeg" => "image/jpeg",
                        ".ico" => "image/vnd.microsoft.ico",
                        _ => "text/plain"
                    };

                    return new HttpResponse(contentType, readFile, HttpStatusCode.Ok);
                }));
            }
        }
    }
}