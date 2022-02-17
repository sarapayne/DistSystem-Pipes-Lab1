using System;
using System.Globalization;
using PipesAndFilters.Messages;

namespace PipesAndFilters.Filters
{
    public class TimestampFilter : IFilter
    {
        public IMessage Run(IMessage message)
        {
            message.Headers.Add("Timestamp", DateTime.Now.ToString(CultureInfo.InvariantCulture));
            return message;
        }
    }
}