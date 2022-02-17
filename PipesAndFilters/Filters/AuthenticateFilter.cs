using PipesAndFilters.Messages;

namespace PipesAndFilters.Filters
{
    public class AuthenticateFilter : IFilter
    {
        
        public IMessage Run(IMessage message)
        {
            if (message.Headers.ContainsKey("User"))
            {
                //add code here
            }
            throw new System.NotImplementedException();
        }
    }
}