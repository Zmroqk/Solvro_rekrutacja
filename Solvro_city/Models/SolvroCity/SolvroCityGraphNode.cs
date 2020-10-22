using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solvro_city.Models.SolvroCity
{
    /// <summary>
    /// Solvro city node object for graph structure
    /// </summary>
    public class SolvroCityGraphNode : SolvroCityNode
    {
        //public SolvroCityGraphNode prevNode { get; set; }
        /// <summary>
        /// Sum for distance in pathfinding algorithm
        /// </summary>
        public uint weightSum { get; set; }
        /// <summary>
        /// List of links this nodes is connected to
        /// </summary>
        public List<SolvroCityGraphLink> Links { get; private set; }

        //public bool Checked { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public SolvroCityGraphNode() : base() {
            //Checked = false;
            Links = new List<SolvroCityGraphLink>();
            //prevNode = null;
            weightSum = 0;
        }

        /// <summary>
        /// Generate this object from basic node data
        /// </summary>
        /// <param name="solvroCityNode">Basic node data</param>
        public SolvroCityGraphNode(SolvroCityNode solvroCityNode) : base(solvroCityNode)
        {
            //prevNode = null;
            Links = new List<SolvroCityGraphLink>();
            //Checked = false;
            weightSum = 0;
        }

        /// <summary>
        /// Generate this object from basic node data and init list of links
        /// </summary>
        /// <param name="solvroCityNode">Basic node data</param>
        /// <param name="links">List of links this node is connected to</param>
        public SolvroCityGraphNode(SolvroCityNode solvroCityNode, List<SolvroCityGraphLink> links) : base(solvroCityNode)
        {
            //prevNode = null;
            Links = links;
            //Checked = false;
            weightSum = 0;
        }
    }
}
