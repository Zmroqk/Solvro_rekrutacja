using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solvro_city.Models.SolvroCity
{
    public class SolvroCityData
    {
        public bool directed { get; set; }
        public object graph { get; set; }
        public List<SolvroCityLink> links {get; set;}
        public bool multigraph { get; set; }
        public List<SolvroCityNode> nodes { get; set; }

        private SolvroCityData() { }

    }
}
