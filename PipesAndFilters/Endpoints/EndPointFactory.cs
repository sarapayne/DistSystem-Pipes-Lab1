namespace PipesAndFilters.Endpoints
{
    public class EndPointFactory
    {
        public static IEndPoint GetEndpoint(string endpointName)
        {
            switch (endpointName)
            {
                case "HelloWorld":
                    return new HelloWorldEndpoint();
                case "LocalHostEndPoint":
                    return new LocalHostEndPoint();
                default:
                    return new DefaultEndPoint();
                    break;
            }
        }
    }
}