namespace FanficAPP.UseCases.EditList;

public class EditListUseCase()
{
    public async Task<Result<EditListResponse>> Do(EditListPayload payload)
    {
        return Result<EditListResponse>.Sucess();
    }
}