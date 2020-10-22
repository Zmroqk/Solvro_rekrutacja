using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solvro_city.Models.Responses
{
    /// <summary>
    /// Default, commonly used HTTP error codes and responses
    /// </summary>
    public static class DefaultJsonResponses
    {
        /// <summary>
        /// Bad request HTTP error code: 400, as json response
        /// </summary>
        public static string BAD_REQUEST = new Response("Bad Request", 400).ToString();
    }
}
