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
    [Route("/")]
    [ApiController]
    public class SolvroCityController : ControllerBase
    {
        [HttpGet("/stops")]
        public string Stops()
        {
            return JsonConvert.SerializeObject(SolvroCityGraph.Instance.SolvroCity.nodes);
        }

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
