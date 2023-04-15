using ModelClasses;
using SOAPSender;
using TestRef1;
namespace SOAPConsumer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var client = new ServiceClient(ServiceClient.EndpointConfiguration.WSHttpBinding_IService, "https://localhost:5001/Service/WSHttps");
            string test = await client.GetDataAsync(1);
            Console.WriteLine(test);
            Console.ReadKey();  
        }
    }
}