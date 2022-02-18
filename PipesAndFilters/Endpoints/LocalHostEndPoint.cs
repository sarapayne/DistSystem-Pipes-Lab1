using PipesAndFilters.Messages;

namespace PipesAndFilters.Endpoints
{
    public class LocalHostEndPoint :IEndPoint
    {
        public IMessage Execute(IMessage message)
        {
            Message response = new Message();
            response.Body = $"Hello {ServerEnvironment.CurrentUser.Name}! You sent the message: {message.Body}";
            response.Headers.Add("ResponseFormat", message.Headers["RequestFormat"]);
            return response;
        }
    }
}