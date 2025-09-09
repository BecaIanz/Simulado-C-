namespace FanficAPP.UseCases.Login;

public class LoginUseCase(
    IJWTService jwtService
)
{
    public async Task<Result<LoginResponse>> Do(LoginPayload payload)
    {
        var user = await ctx.Users.FirstOrDefaultAsync(
            p => p.Username == payload.Login || p.Email == payload.Login
        );

        // Se o usuário for null, retorna Fail com mensagem
        if (user is null)
            return Result<LoginResponse>.Fail("User not found!");

        // Se o computador não der match, envia erro.
        if (payload.Password != user.Password)
            return Result<LoginResponse>.Fail("Wrong Password!");

        // 
        var jwt = jwtService.CreateToken(new(
            user.ID, user.Username, user.SubscriptionID
        ));

        // Se tudo der certo, retorna o JWT
        return Result<LoginResponse>.Success(new LoginResponse(jwt));
    }
}