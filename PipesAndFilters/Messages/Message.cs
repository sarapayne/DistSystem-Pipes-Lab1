using System.Collections.Generic;

namespace PipesAndFilters.Messages
{
    public class Message : IMessage
    {
        public Message(Dictionary<string, string> headers)
        {
            Headers = headers;
        }

        public Dictionary<string, string> Headers { get; set; }
        public string Body { get; set; }
    }
}