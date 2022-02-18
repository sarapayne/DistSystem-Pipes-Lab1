using PipesAndFilters.Messages;

namespace PipesAndFilters.Endpoints
{
    public interface IEndPoint
    {
        public IMessage Execute(IMessage message);
    }
}