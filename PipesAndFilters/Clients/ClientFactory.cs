using System;
using System.Diagnostics;

namespace PipesAndFilters.Clients
{
    public static class ClientFactory
    {
        public static IClient GetClient(string clientType)
        {
            switch (clientType)
            {
                case "Bytes":
                    return new ClientBytes();
                case "Hex":
                    return new ClientHex();
                case "Binary":
                    return new ClientBinary();
                default:
                    throw new ArgumentException(clientType);
            }
        }
    }
}