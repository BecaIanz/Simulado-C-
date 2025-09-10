using FanficAPP.Models;
using FanficAPP.Services.JWT;
using FanficAPP.Services.Profile;
using Microsoft.EntityFrameworkCore;

namespace FanficAPP.UseCases.Login;

public class LoginUseCase(
    FanficAPPDbContext ctx,
    IJWTService jwtService,
    IProfileService profileService
)
{
    public async Task<Result<LoginResponse>> Do(LoginPayload payload)
    {
        var user = await profileService.FindByLogin(payload.Login);     

        // Se o usuário for null, retorna Fail com mensagem
        if (user is null)
            return Result<LoginResponse>.Fail("User not found!");

        // Se o computador não der match, envia erro.
        if (payload.Password != user.Password)
            return Result<LoginResponse>.Fail("Wrong Password!");

        // 
        var jwt = jwtService.CreateToken(new(
            user.UserID, user.Username, user.Email
        ));

        // Se tudo der certo, retorna o JWT
        return Result<LoginResponse>.Success(new LoginResponse(jwt));
    }
}