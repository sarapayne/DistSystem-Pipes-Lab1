using System.Text;
using PipesAndFilters.Messages;

namespace PipesAndFilters.Filters
{
    public class TranslateFilter: IFilter
    {
        public IMessage Run(IMessage message)
        {
            if (message.Headers.ContainsKey("RequestFormat"))
            {
                switch (message.Headers["requestFormat"])
                {
                    case "Bytes":
                        
                        break;
                    default:
                        break;
                }
            }

            else if (message.Headers.ContainsKey("ResponseFormat"))
            {
                switch (message.Headers["ResponseFormat"]
                {
                    case "Bytes":
                        
                        break;
                    default:
                        break;
                }
            }
            
            

            return message;
        }
    }
}