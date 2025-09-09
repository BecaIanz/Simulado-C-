namespace FanficAPP.UseCases.DeleteFanfic;

public class DeleteFanficUseCase()
{
    public async Task<Result<DeleteFanficResponse>> Do(DeleteFanficPayload payload)
    {
        return Result<DeleteFanficResponse>.Success(null);
    }
}