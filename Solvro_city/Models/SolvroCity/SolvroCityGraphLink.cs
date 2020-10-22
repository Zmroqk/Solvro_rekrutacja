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
        /// Default constructor
        /// </summary>
        public SolvroCityGraphLink() : base() {
            SourceNode = null;
            TargetNode = null;
        }

        /// <summary>
        /// Create object from SolvroCityLink
        /// </summary>
        /// <param name="solvroCityLink">Link to generate this object from</param>
        /// <param name="reverse">Should data be reversed (sorurce as target, target as source)</param>
        public SolvroCityGraphLink(SolvroCityLink solvroCityLink, bool reverse = false) : base(solvroCityLink, reverse)
        {
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
        public SolvroCityGraphLink(SolvroCityLink solvroCityLink, SolvroCityGraphNode sourceNode, SolvroCityGraphNode targetNode, bool reverse = false) : base(solvroCityLink, reverse)
        {
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
