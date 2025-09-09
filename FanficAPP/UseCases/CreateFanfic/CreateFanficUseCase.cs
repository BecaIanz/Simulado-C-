namespace FanficAPP.UseCases.CreateFanfic;

public class CreateFanficUseCase()
{
    public async Task<Result<CreateFanficResponse>> Do(CreateFanficPayload payload)
    {
        return Result<CreateFanficResponse>.Success(null);
    }
}