using System;
using System.Threading.Tasks;
using Shared.DomainExtensions;

namespace ProcessorHost
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            // running business logic by calling third-party methods of a NuGet package 

            var (sld, tld) = "google.com".SplitDomainName();
            Console.WriteLine($"output 1: sld '{sld}', tld '{tld}'");

            var isAlive = await $"https://{(sld, tld).Combine()}".CheckIsAliveEndpointAsync();
            Console.WriteLine($"output 2: is alive endpoint '{isAlive}'");

            Console.ReadLine();
        }
    }
}