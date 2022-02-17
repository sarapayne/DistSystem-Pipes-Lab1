using System.Collections.Generic;

namespace PipesAndFilters.Messages
{
    public interface IMessage
    {
        public Dictionary<string, string> Headers { get; set; }
        public string Body { get; set; }
    }
}