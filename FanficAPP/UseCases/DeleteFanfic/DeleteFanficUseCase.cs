using FanficAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace FanficAPP.UseCases.DeleteFanfic;

public class DeleteFanficUseCase(
    FanficAPPDbContext ctx
)
{
    public async Task<Result<DeleteFanficResponse>> Do(DeleteFanficPayload payload)
    {
        var fanfic = await ctx.Fanfics.FirstOrDefaultAsync(f => f.FanficID == payload.FanficID);

        if(fanfic is null)
            return Result<DeleteFanficResponse>.Fail("Fanfic Não encontrada!");
        
        if(fanfic.UserId != payload.UserID)
            return Result<DeleteFanficResponse>.Fail("Você não é dono dessa fanfic!");

        ctx.Fanfics.Remove(fanfic);
        await ctx.SaveChangesAsync();

        return Result<DeleteFanficResponse>.Success(null);
    }
}