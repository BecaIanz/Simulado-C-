namespace FanficAPP.UseCases.EditList;

public class EditListUseCase(
    FanficAPPDbContext ctx
)
{
    public async Task<Result<EditListResponse>> Do(EditListPayload payload)
    {
        var user = await ctx.Users
            .Include(u => u.ReadingLists)
            .FirstOrDefault(u => u.UserID == payload.UserID);

        var list = user.ReadingList
            .FirstOrDefault(l => l.ReadingListID == payload.ReadingListID);

        var fanfic = await ctx.Fanfics
            .FirstOrDefaultAsync(f => f.FanficID == payload.FanficID);

        if (user is null)
            return Result<EditListResponse>.Fail("Usuario não Encontrado!");

        if (list is null)
            return Result<EditListResponse>.Fail("Lista não Encontrada!");
        
        if (fanfic is null)
            return Result<EditListResponse>.Fail("Fanfic não encontrada!");

        var fanficList = new FanficReadingList
        {
            FanficID = payload.FanficID,
            ReadingListID = payload.ReadingListID
        };

        ctx.ReadingLists.Add(fanficList);
        
        return Result<EditListResponse>.Sucess(null);
    }
}