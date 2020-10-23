using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Solvro_city.Models.Responses;
using Solvro_city.Models.SolvroCity;
using Microsoft.AspNetCore.Authorization;
using Solvro_city.Services;

namespace Solvro_city.Controllers
{
    /// <summary>
    /// Solvro city api controller
    /// </summary>
    [Route("/")]
    [ApiController]
    public class SolvroCityController : Controller
    {

        /// <summary>
        /// Service that handles pathfinding
        /// </summary>
        readonly IPathFinding pathFinding;

        /// <summary>
        /// Controller constructor, get injection
        /// </summary>
        /// <param name="pathFinding">Path finding service</param>
        public SolvroCityController(IPathFinding pathFinding)
        {
            this.pathFinding = pathFinding;
        }

        /// <summary>
        /// Returns json list of all stops/nodes in solvro city
        /// </summary>
        /// <returns>Json list of nodes</returns>
        [HttpGet("/stops")]
        [Authorize]
        public IActionResult Stops()
        {
            return Json(pathFinding.Stops);
        }

        /// <summary>
        /// Return json data for pathfinding: list of stops between source and target and distance between them
        /// </summary>
        /// <param name="source">Stop name from which to start pathfinding</param>
        /// <param name="target">Stop name where pathfinding should end</param>
        /// <returns>Json list of nodes and distance between source and target</returns>
        [HttpGet("/path")]
        [Authorize]
        public IActionResult Path([FromQuery(Name = "source")] string source, [FromQuery(Name = "target")] string target)
        {
            if(source == String.Empty || target == String.Empty || source == null || target == null)
            {
                return BadRequest();
            }
            PathResponse pathResponse = pathFinding.FindPath(source, target);
            if(pathResponse.stops.Count == 0)
            {
                return BadRequest();
            }
            return Json(pathResponse);
        }

    }
}
