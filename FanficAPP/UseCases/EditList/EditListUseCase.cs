using FanficAPP.Models;
using FanficAPP.UseCases.Getlist;
using Microsoft.EntityFrameworkCore;

namespace FanficAPP.UseCases.EditList;

public class EditListUseCase(
    FanficAPPDbContext ctx
)
{
    public async Task<Result<EditListResponse>> Do(EditListPayload payload)
    {
        var list = await ctx.ReadingLists
            .FirstOrDefaultAsync(l => l.ReadingListID == payload.ReadingListID);

        if (list is null)
            return Result<EditListResponse>.Fail("Lista não Encontrada!");
        
        if (list.UserId != payload.UserID)
            return Result<EditListResponse>.Fail("Lista não é sua!");

        var fanfic = await ctx.Fanfics
            .FirstOrDefaultAsync(f => f.Title == payload.TitleFanfic);
        
        if (fanfic is null)
            return Result<EditListResponse>.Fail("Fanfic não encontrada!");


        list.FanficList.Add(fanfic);

        list.LastModificationDate = DateTime.UtcNow;
        await ctx.SaveChangesAsync();

        return Result<EditListResponse>.Success(null);
    }
}