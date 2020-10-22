using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solvro_city.Models.SolvroCity
{
    /// <summary>
    /// JSON object of solvro city as class
    /// </summary>
    public class SolvroCityData
    {
        /// <summary>
        /// Is graph directed
        /// </summary>
        public bool directed { get; set; }
        /// <summary>
        /// Object for graph?
        /// </summary>
        public object graph { get; set; }
        /// <summary>
        /// List of links between nodes
        /// </summary>
        public List<SolvroCityLink> links {get; set;}
        /// <summary>
        /// Is graph a multigraph
        /// </summary>
        public bool multigraph { get; set; }
        /// <summary>
        /// List of nodes in city
        /// </summary>
        public List<SolvroCityNode> nodes { get; set; }

        /// <summary>
        /// Prevent init.
        /// </summary>
        private SolvroCityData() { }

    }
}
