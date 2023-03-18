namespace Application.Shared.Wrappers.Interfaces
{
    public interface IResponse<T>
    {
        T Data { get; set; }

        List<string> Errors { get; set; }

        string Message { get; set; }

        bool Succeeded { get; set; }
    }
}
