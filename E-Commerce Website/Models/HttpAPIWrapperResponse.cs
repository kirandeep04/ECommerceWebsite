using System.Net;

namespace E_Commerce_Website.Models
{
    public class HttpAPIWrapperResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public T data { get; set; }
    }
}
