using SUS.MvcFramework;
using System.Threading.Tasks;

namespace MUSACA
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new StartUp());
        }
    }
}
