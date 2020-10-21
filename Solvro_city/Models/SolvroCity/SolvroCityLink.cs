using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solvro_city.Models.SolvroCity
{
    public class SolvroCityLink
    {
        public uint distance { get; set; }
        public uint source { get; set; }
        public uint target { get; set; }

        public SolvroCityLink() {
            distance = 0;
            source = 0;
            target = 0;
        }

        public SolvroCityLink(SolvroCityLink solvroCityLink, bool reverse = false)
        {
            if (!reverse)
            {
                source = solvroCityLink.source;
                target = solvroCityLink.target;
                distance = solvroCityLink.distance;
            }
            else
            {
                source = solvroCityLink.target;
                target = solvroCityLink.source;
                distance = solvroCityLink.distance;
            }
        }
    }
}
