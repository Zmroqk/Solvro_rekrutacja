using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Solvro_city.Models.Responses;
using Solvro_city.Models.SolvroCity;

namespace Solvro_city.Controllers
{
    /// <summary>
    /// Solvro city api controller
    /// </summary>
    [Route("/")]
    [ApiController]
    public class SolvroCityController : ControllerBase
    {
        /// <summary>
        /// Returns json list of all stops/nodes in solvro city
        /// </summary>
        /// <returns>Json list of nodes</returns>
        [HttpGet("/stops")]
        public string Stops()
        {
            return JsonConvert.SerializeObject(SolvroCityGraph.Instance.SolvroNodes);
        }

        /// <summary>
        /// Return json data for pathfinding: list of stops between source and target and distance between them
        /// </summary>
        /// <param name="source">Stop name from which to start pathfinding</param>
        /// <param name="target">Stop name where pathfinding should end</param>
        /// <returns></returns>
        [HttpGet("/path")]
        public string Path([FromQuery(Name = "source")] string source, [FromQuery(Name = "target")] string target)
        {
            if(source == String.Empty || target == String.Empty || source == null || target == null)
            {
                return DefaultJsonResponses.BAD_REQUEST;
            }
            PathResponse pathResponse = SolvroCityGraph.Instance.FindPath(source, target);
            if(pathResponse.stops.Count == 0)
            {
                return DefaultJsonResponses.BAD_REQUEST;
            }
            return JsonConvert.SerializeObject(pathResponse);
        }

    }
}
