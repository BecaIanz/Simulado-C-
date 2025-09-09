using FanficAPP.UseCases.Getlist;

namespace FanficAPP;

public record Result<T>(
    T Data,
    bool IsSuccess,
    string Reason
)
{
    public static Result<T> Success(T data)
        => new(data, true, null);
    
    public static Result<T> Fail(string reason)
        => new(default, false, reason);

    internal static Result<EditListResponse> Sucess(object value)
    {
        throw new NotImplementedException();
    }
}