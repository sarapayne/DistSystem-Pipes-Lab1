using System;
using System.Text;
using PipesAndFilters.Clients;
using PipesAndFilters.Filters;
using PipesAndFilters.Messages;
namespace PipesAndFilters
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerEnvironment.Setup();
            IClient client = ClientFactory.GetClient("Hex");
            client.RequestHello();
        }
    }
    
}
