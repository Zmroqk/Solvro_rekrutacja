using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solvro_city.Models.SolvroCity
{
    public class SolvroCityGraphNode : SolvroCityNode
    {
        //public SolvroCityGraphNode prevNode { get; set; }
        public uint weightSum { get; set; }
        public List<SolvroCityGraphLink> Links { get; private set; }
        public bool Checked { get; set; }

        public SolvroCityGraphNode() : base() {
            Checked = false;
            Links = new List<SolvroCityGraphLink>();
            //prevNode = null;
            weightSum = 0;
        }

        public SolvroCityGraphNode(SolvroCityNode solvroCityNode) : base(solvroCityNode)
        {
            //prevNode = null;
            Links = new List<SolvroCityGraphLink>();
            Checked = false;
            weightSum = 0;
        }

        public SolvroCityGraphNode(SolvroCityNode solvroCityNode, List<SolvroCityGraphLink> links) : base(solvroCityNode)
        {
            //prevNode = null;
            Links = links;
            Checked = false;
            weightSum = 0;
        }
    }
}
