using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SUS.HTTP
{
    public class HttpServer : IHttpServer
    {
        List<Route> routeTable = new List<Route>();

        public HttpServer(List<Route> routeTable)
        {
            this.routeTable = routeTable;
        }

        public async Task StartAsync(int port)
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, port);

            listener.Start();

            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();

                ProcessClientAsync(client);
            }
        }

        private async Task ProcessClientAsync(TcpClient client)
        {
            try
            {
                using (NetworkStream stream = client.GetStream())
                {
                    List<byte> data = new List<byte>();
                    byte[] buffer = new byte[HttpConstants.BufferSize];
                    int position = 0;

                    while (true)
                    {
                        int count = await stream.ReadAsync(buffer, position, buffer.Length);

                        position += count;

                        if (count < buffer.Length)
                        {
                            var partialBuffer = new byte[count];
                            Array.Copy(buffer, partialBuffer, count);
                            data.AddRange(partialBuffer);
                            break;
                        }
                        else
                        {
                            data.AddRange(buffer);
                        }
                    }

                    string requestAsString = Encoding.UTF8.GetString(data.ToArray());

                    HttpRequest request = new HttpRequest(requestAsString);
                    Console.WriteLine($"{request.Method} {request.Path} => {request.Headers.Count}");

                    HttpResponse response;

                    Route route = routeTable.FirstOrDefault(x => string.Compare(x.Path, request.Path, true) == 0 && x.Method == request.Method);

                    if (route != null)
                    {
                        response = route.Action(request);
                    }
                    else
                    {
                        response = new HttpResponse("text/html", new byte[0], HttpStatusCode.NotFound);
                    }

                    response.Cookies.Add(new ResponseCookie("sid", Guid.NewGuid().ToString()) { HttpOnly = true, MaxAge = 60 * 60 });
                    response.Headers.Add(new Header("Server", "SUS Server 1.0"));

                    var responseHeaderBytes = Encoding.UTF8.GetBytes(response.ToString());

                    await stream.WriteAsync(responseHeaderBytes, 0, responseHeaderBytes.Length);

                    if (response.Body != null)
                    {
                        await stream.WriteAsync(response.Body, 0, response.Body.Length);
                    }

                    client.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
