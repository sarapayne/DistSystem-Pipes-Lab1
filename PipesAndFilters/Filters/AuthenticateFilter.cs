using PipesAndFilters.Messages;

namespace PipesAndFilters.Filters
{
    public class AuthenticateFilter : IFilter
    {
        
        public IMessage Run(IMessage message)
        {
            if (message.Headers.ContainsKey("User"))
            {
                if (int.TryParse(message.Headers["User"], out int id))
                {
                    ServerEnvironment.SetCurrentUser(id);
                }
            }

            return message;
        }
    }
}