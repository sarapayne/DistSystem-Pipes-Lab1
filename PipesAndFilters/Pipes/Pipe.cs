using System.Collections.Generic;
using PipesAndFilters.Filters;
using PipesAndFilters.Messages;

namespace PipesAndFilters.Pipes
{
    public class Pipe : IPipe
    {
        private List<IFilter> _filters;

        public Pipe(List<IFilter> filters)
        {
            _filters = filters;
        }
        
        public void RegisterFilter(IFilter filter)
        {
            _filters.Add(filter);
        }

        public IMessage ProcessMessage(IMessage message)
        {
            IMessage finalMessage = null;
            for (int index = 0; index < _filters.Count; index++)
            {
                finalMessage = _filters[index].Run(message);
            }

            return finalMessage;
        }
    }
}