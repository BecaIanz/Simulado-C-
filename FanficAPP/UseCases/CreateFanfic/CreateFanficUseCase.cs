using FanficAPP.Models;

namespace FanficAPP.UseCases.CreateFanfic;

public class CreateFanficUseCase(
    FanficAPPDbContext ctx
)
{
    public async Task<Result<CreateFanficResponse>> Do(CreateFanficPayload payload)
    {
        var fanfic = new Fanfic
        {
            UserId = payload.UserID,
            Title = payload.Title,
            Text = payload.Text
        };

        ctx.Fanfics.Add(fanfic);
        await ctx.SaveChangesAsync();

        var response = new CreateFanficResponse(fanfic.FanficID);
        return Result<CreateFanficResponse>.Success(response);
    }
}