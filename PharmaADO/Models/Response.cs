using System.Net;

namespace PharmaADO.Models
{
    public class Response
    {
        public string Message { get; set; }
        public HttpStatusCode statusCode { get; set; }
    }
}
