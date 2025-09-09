namespace FanficAPP.UseCases.GetList;

public class GetListUseCase(
    FanficAPPDbContext ctx
)
{
    public async Task<Result<GetListResponse>> Do(GetListPayload payload)
    {
        var lists = await ctx.ReadingLists.Where(l => l.Title == payload.Title);

        if (lists is null)
            return Result<GetListResponse>.Fail("Lista de Leitura não encontrada!");

        return Result<GetListResponse>.Success(new(lists));
    }
}