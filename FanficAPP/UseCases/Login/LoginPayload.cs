namespace FanficAPP.UseCases.Login;

public record LoginPayload(
    string Login,
    string Password
);