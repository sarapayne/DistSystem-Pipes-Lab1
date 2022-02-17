using System;
using System.Globalization;
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
                string[] bodyParts = message.Body.Split('-');
                byte[] bytes = new byte[bodyParts.Length];
                switch (message.Headers["RequestFormat"])
                {
                    case "Bytes":
                        
                        for (int index = 0; index < bodyParts.Length; index++)
                        {
                            bytes[index] = byte.Parse(bodyParts[index]);
                        }
                        break;
                    case "Hex":
                        for (int index = 0; index < bodyParts.Length; index++)
                        {
                            bytes[index] = Convert.ToByte(bodyParts[index], 16);
                        }
                        break;
                    case "Binary":
                        for (int index = 0; index < bodyParts.Length; index++)
                        {
                            bytes[index] = Convert.ToByte(bodyParts[index], 2);
                        }
                        break;
                    default:
                        break;
                }
                message.Body = Encoding.ASCII.GetString(bytes);
            }
            else if (message.Headers.ContainsKey("ResponseFormat"))
            {
                byte[] bytes = Encoding.ASCII.GetBytes(message.Body);
                string messageBody = String.Empty;
                for (int index = 0; index < bytes.Length; index++)
                {
                    switch (message.Headers["ResponseFormat"])
                    {
                        case "Bytes":
                            messageBody += bytes[index].ToString();
                            break;
                        case "Hex":
                            messageBody += Convert.ToString(bytes[index], 16).PadLeft(8, '0');
                            break;
                        case "Binary":
                            messageBody += Convert.ToString(bytes[index], 2).PadLeft(8, '0');
                            break;
                        default:
                            break;
                    }
                    if (index < bytes.Length - 1)
                    {
                        messageBody += "-"; // - symbol is just a delimiter, could be anything
                    }
                }
                message.Body = messageBody;
            }
            return message;
        }
    }
}