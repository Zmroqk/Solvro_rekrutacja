using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solvro_city.Models.Responses
{
    public static class DefaultJsonResponses
    {
        public static string BAD_REQUEST = new Response("Bad Request", 400).ToString();
    }
}
