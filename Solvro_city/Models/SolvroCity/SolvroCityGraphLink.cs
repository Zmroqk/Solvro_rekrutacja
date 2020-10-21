using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solvro_city.Models.SolvroCity
{
    public class SolvroCityGraphLink : SolvroCityLink
    {
        public SolvroCityGraphNode SourceNode { get; set; }
        public SolvroCityGraphNode TargetNode { get; set; }

        public SolvroCityGraphLink() : base() {
            SourceNode = null;
            TargetNode = null;
        }

        public SolvroCityGraphLink(SolvroCityLink solvroCityLink, bool reverse = false) : base(solvroCityLink, reverse)
        {
            SourceNode = null;
            TargetNode = null;
        }
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
