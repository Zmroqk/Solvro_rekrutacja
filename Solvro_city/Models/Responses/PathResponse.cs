using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Solvro_city.Models.SolvroCity;

namespace Solvro_city.Models.Responses
{
    public class PathResponse
    {
        public List<SolvroCityNode> stops { get; set; }
        public uint distance { get; set; }

        public PathResponse()
        {
            stops = new List<SolvroCityNode>();
            distance = 0;
        }

        public PathResponse(List<SolvroCityNode> stops, uint distance)
        {
            this.stops = stops;
            this.distance = distance;
        }
    }
}
