using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Solvro_city.Models.SolvroCity;

namespace Solvro_city.Models.Responses
{
    /// <summary>
    /// Response class for path finding
    /// </summary>
    public class PathResponse
    {
        /// <summary>
        /// List of nodes of path
        /// </summary>
        public List<SolvroCityNode> stops { get; set; }
        /// <summary>
        /// Distance from source to target
        /// </summary>
        public uint distance { get; set; }

        /// <summary>
        /// Default constructor when path not found
        /// </summary>
        public PathResponse()
        {
            stops = new List<SolvroCityNode>();
            distance = 0;
        }

        /// <summary>
        /// Constructor for path response
        /// </summary>
        /// <param name="stops">List of nodes</param>
        /// <param name="distance">Distance from source to target</param>
        public PathResponse(List<SolvroCityNode> stops, uint distance)
        {
            this.stops = stops;
            this.distance = distance;
        }
    }
}
