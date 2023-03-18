using Application.Shared.Wrappers.Interfaces;

namespace Application.Shared.Wrappers.Implementations
{
    public class Response<T> : IResponse<T>
    {
        public bool Succeeded { get; set; }

        public string Message { get; set; }

        public List<string> Errors { get; set; }

        public T Data { get; set; }

        public Response()
        {
        }

        public Response(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        public Response(string message)
        {
            Succeeded = false;
            Message = message;
        }

        public Response(List<string> messages)
        {
            Succeeded = false;
            Errors = messages;
            Message = "View detail in Errors";
        }
    }
}
