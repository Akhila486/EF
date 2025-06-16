using System.Net;

namespace PharmaProject.Models
{
    public class Response
    {
        public string Message { get; set; }
        public HttpStatusCode statusCode{ get; set; }
    }
}
