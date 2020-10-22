using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solvro_city.Models.SolvroCity
{
    /// <summary>
    /// Basic data about node
    /// </summary>
    public class SolvroCityNode //: IEquatable<SolvroCityNode>
    {
        /// <summary>
        /// Id for this node
        /// </summary>
        public uint id { get; set; }
        /// <summary>
        /// Name of this node
        /// </summary>
        public string stop_name { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public SolvroCityNode() {
            id = 0;
            stop_name = "";
        }

        /// <summary>
        /// Create this object from already existing node data
        /// </summary>
        /// <param name="solvroCityNode">Node data from which data should be copied</param>
        public SolvroCityNode(SolvroCityNode solvroCityNode)
        {
            id = solvroCityNode.id;
            stop_name = solvroCityNode.stop_name;
        }

        /*public override bool Equals(object obj)
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
        }*/
    }
}
