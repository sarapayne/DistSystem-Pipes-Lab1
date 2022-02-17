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
                byte[] bytes = Encoding.ASCII.GetBytes(message.Body);
                string asciiString = "";
                for (int i = 0; i < bytes.Length; i++)
                {
                    asciiString += bytes[i].ToString();
                    if (i + 1 < bytes.Length)
                    {
                        asciiString += "-";
                    }
                }
                message.Body = asciiString;
            }

            if (message.Headers.ContainsKey("ResponseFormat"))
            {
                //how do we know the potential formats? Therefore how is this done?
            }

            return message;
        }
    }
}