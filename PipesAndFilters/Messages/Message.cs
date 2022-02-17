using System.Collections.Generic;

namespace PipesAndFilters.Messages
{
    public class Message : IMessage
    {
        public Message(Dictionary<string, string> headers)
        {
            Headers = headers;
        }
        
        //should there be an empty constructor here too

        //What does it mean by return to default behaviour? if you remove get set it no longer complies with the interface
        public Dictionary<string, string> Headers { get; set; }
        public string Body { get; set; }
    }
}