using SUS.MvcFramework;
using System.Threading.Tasks;

namespace Andreys
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new StartUp());
        }
    }
}
