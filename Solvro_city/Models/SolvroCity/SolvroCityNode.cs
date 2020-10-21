using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solvro_city.Models.SolvroCity
{
    public class SolvroCityNode : IEquatable<SolvroCityNode>
    {
        public uint id { get; set; }
        public string stop_name { get; set; }

        public SolvroCityNode() {
            id = 0;
            stop_name = "";
        }

        public SolvroCityNode(SolvroCityNode solvroCityNode)
        {
            id = solvroCityNode.id;
            stop_name = solvroCityNode.stop_name;
        }

        public override bool Equals(object obj)
        {
            if (obj is SolvroCityNode)
                Equals((SolvroCityNode)obj);
            return false;
        }
        public override int GetHashCode()
        {
            return (int)id;
        }
        public bool Equals(SolvroCityNode node)
        {
            if (id == node.id && stop_name == node.stop_name)
                return true;
            return false;
        }
    }
}
