using System.Collections.Generic;
using PipesAndFilters.Filters;
using PipesAndFilters.Messages;

namespace PipesAndFilters.Pipes
{
    public class Pipe : IPipe
    {
        private List<IFilter> _filters;

        public Pipe()
        {
            _filters = new List<IFilter>();
        }
        
        public void RegisterFilter(IFilter filter)
        {
            _filters.Add(filter);
        }

        public IMessage ProcessMessage(IMessage message)
        {
            for (int index = 0; index < _filters.Count; index++)
            {
               _filters[index].Run(message);
            }

            return message;
        }
    }
}