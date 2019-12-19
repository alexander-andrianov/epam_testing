using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Models
{
    public class Route
    {
        public string OriginSurrogate { get; set; }
        public string DestinationSurrogate { get; set; }

        public Route(string originSurrogate, string destinationSurrogate)
        {
            this.OriginSurrogate = originSurrogate;
            this.DestinationSurrogate = destinationSurrogate;
        }
    }
}
