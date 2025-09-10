using Microsoft.EntityFrameworkCore;
using FanficAPP.Models;
using FanficAPP.Services.Profile;

namespace ThePixeler.Services.Profiles;

public class EFProfileService(FanficAPPDbContext ctx) : IProfileService
{
    public async Task<Guid> Create(User profile)
    {
        ctx.Users.Add(profile);
        await ctx.SaveChangesAsync();
        return profile.UserID;
    }

    public async Task<User> FindByLogin(string login)
    {
        var profile = await ctx.Users.FirstOrDefaultAsync(
            p => p.Username == login || p.Email == login
        );
        return profile;
    }
}