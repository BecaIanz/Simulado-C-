using FanficAPP.Models;

namespace FanficAPP.Services.Profile;

public interface IProfileService
{
    Task<User> FindByLogin(string login);
    Task<Guid> Create(User profile);
}