using Solvro_city.Models.Responses;
using Solvro_city.Models.SolvroCity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solvro_city.Services
{
    /// <summary>
    /// Interface that handles SolvroCity pathfinding
    /// </summary>
    public interface IPathFinding
    {
        /// <summary>
        /// Return list of stops
        /// </summary>
        public List<SolvroCityNode> Stops { get; }
        /// <summary>
        /// Find path between two points
        /// </summary>
        /// <param name="source">Stop at which path should start</param>
        /// <param name="destination">Stop at which path should end</param>
        /// <returns>Path response: List of nodes for found path and length of path</returns>
        public PathResponse FindPath(string source, string destination);
    }
}
