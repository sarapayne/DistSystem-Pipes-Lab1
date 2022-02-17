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
                    break;
                case "Hex":
                    return new ClientHex();
                    break;
                case "Binary":
                    return new ClientBinary();
                    break;
                default:
                    throw new ArgumentException(clientType);
                    break;
            }
        }
    }
}