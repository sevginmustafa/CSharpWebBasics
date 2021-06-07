using SUS.MvcFramework;
using System.Threading.Tasks;

namespace SharedTrip
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new StartUp());
        }
    }
}
