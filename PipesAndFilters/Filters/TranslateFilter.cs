using System;
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
                        string[] byteStrings = message.Body.Split('-');
                        byte[] bytes = new byte[byteStrings.Length];
                        for (int index = 0; index < byteStrings.Length; index++)
                        {
                            bytes[index] = byte.Parse(byteStrings[index]);
                        }

                        message.Body = Encoding.ASCII.GetString(bytes);
                        break;
                    default:
                        break;
                }
            }
            else if (message.Headers.ContainsKey("ResponseFormat"))
            {
                switch (message.Headers["ResponseFormat"])
                {
                    case "Bytes":
                        byte[] bytes = Encoding.ASCII.GetBytes(message.Body);
                        string messageBody = String.Empty;
                        for (int index = 0; index < bytes.Length; index++)
                        {
                            messageBody += bytes[index].ToString();
                            
                            if (index < bytes.Length - 1)
                            {
                                messageBody += "-"; // - symbol is just a delimiter, could be anything
                            }
                        }
                        message.Body = messageBody;
                        break;
                    default:
                        break;
                }
            }
            return message;
        }
    }
}