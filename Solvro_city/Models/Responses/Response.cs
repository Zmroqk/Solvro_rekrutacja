using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Solvro_city.Models.Responses
{
    /// <summary>
    /// Response class for api communication
    /// </summary>
    /// <typeparam name="T">Type of data for Data field of response</typeparam>
    public class Response<T>
    {
        /// <summary>
        /// Status code for response
        /// </summary>
        public int Code { get; private set; }
        /// <summary>
        /// Data for response
        /// </summary>
        public T Data { get; private set; }

        /// <summary>
        /// Response constructor
        /// </summary>
        /// <param name="data">Data to set as data parameter of response</param>
        /// <param name="code">Status code of response</param>
        public Response(T data, int code = 200)
        {
            this.Code = code;
            this.Data = data;
        }

        /// <summary>
        /// Returns object as json string
        /// </summary>
        /// <returns>Object as json string</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    /// <summary>
    /// Default response with data as string
    /// </summary>
    public class Response : Response<string>
    {
        public Response(string data, int code = 200) : base(data, code) { }
    }
}
