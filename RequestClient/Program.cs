using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RequestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Strat emitting 100 requirests to Durable Functions Sample_HttpStart");
            ExecuteAsync().GetAwaiter().GetResult();
            Console.WriteLine("Done");
            Console.ReadLine();
        }

       private static async Task ExecuteAsync()
        {
            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                var tasks = Enumerable.Range(0, 100).Select(async i => {
                    var result = await client.GetAsync("Your Sample_HttpStart end point here");
                    Console.WriteLine(result);
                });
                await Task.WhenAll(tasks);

            }
        }
    }
}
