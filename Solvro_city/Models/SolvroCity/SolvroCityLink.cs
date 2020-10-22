using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solvro_city.Models.SolvroCity
{
    /// <summary>
    /// Basic data about link
    /// </summary>
    public class SolvroCityLink
    {
        /// <summary>
        /// Distance of this link
        /// </summary>
        public uint distance { get; set; }
        /// <summary>
        /// Source node id
        /// </summary>
        public uint source { get; set; }
        /// <summary>
        /// Target node id
        /// </summary>
        public uint target { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public SolvroCityLink() {
            distance = 0;
            source = 0;
            target = 0;
        }

        /// <summary>
        /// Generate link from already existing link
        /// </summary>
        /// <param name="solvroCityLink">Link from where should data be copied</param>
        /// <param name="reverse">Should data be reversed (source as target, target as source)</param>
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
