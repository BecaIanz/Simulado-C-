namespace FanficAPP.UseCases.GetList;

public class GetlistUseCase()
{
    public async Task<Result<GetListResponse>> Do(GetListPayload payload)
    {
        return Result<GetListResponse>.Sucess();
    }
}