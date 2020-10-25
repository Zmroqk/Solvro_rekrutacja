using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solvro_city.Models.SolvroCity
{
    /// <summary>
    /// Solvro city link object for graph structure
    /// </summary>
    public class SolvroCityGraphLink : SolvroCityLink
    {
        /// <summary>
        /// Source node for this link
        /// </summary>
        public SolvroCityGraphNode SourceNode { get; set; }
        /// <summary>
        /// Target node for this link
        /// </summary>
        public SolvroCityGraphNode TargetNode { get; set; }

        /// <summary>
        /// Can be this link used
        /// </summary>
        public bool Available { get; }


        /// <summary>
        /// Default constructor
        /// </summary>
        public SolvroCityGraphLink() : base() {
            Available = true;
            SourceNode = null;
            TargetNode = null;
        }

        /// <summary>
        /// Create object from SolvroCityLink
        /// </summary>
        /// <param name="solvroCityLink">Link to generate this object from</param>
        /// <param name="reverse">Should data be reversed (sorurce as target, target as source)</param>
        /// <param name="available">Should be this link available in path finding algorithm</param>
        public SolvroCityGraphLink(SolvroCityLink solvroCityLink, bool reverse = false, bool available = true) : base(solvroCityLink, reverse)
        {
            Available = available;
            SourceNode = null;
            TargetNode = null;
        }
        /// <summary>
        /// Create object from SolvroCityLink and init graph nodes
        /// </summary>
        /// <param name="solvroCityLink">Link to generate this object from</param>
        /// <param name="sourceNode">Source node</param>
        /// <param name="targetNode">Target node</param>
        /// <param name="reverse">Should data be reversed (sorurce as target, target as source)</param>
        /// <param name="available">Should be this link available in path finding algorithm</param>
        public SolvroCityGraphLink(SolvroCityLink solvroCityLink, SolvroCityGraphNode sourceNode, SolvroCityGraphNode targetNode, bool reverse = false, bool available = true) : base(solvroCityLink, reverse)
        {
            Available = available;
            if (reverse)
            {
                SourceNode = targetNode;
                TargetNode = sourceNode;
            }
            else
            {
                SourceNode = sourceNode;
                TargetNode = targetNode;
            }
        }
    }
}
